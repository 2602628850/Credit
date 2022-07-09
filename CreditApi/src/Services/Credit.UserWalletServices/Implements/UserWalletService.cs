using Credit.PamentInfoModels;
using Credit.PayeeBankCardServices;
using Credit.RepayModels;
using Credit.UserBankCardServices;
using Credit.UserModels;
using Credit.UserServices;
using Credit.UserWalletModels;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Consts;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.UserWalletServices;

/// <summary>
///  用户钱包资金变动方法实现
/// </summary>
public class UserWalletService : IUserWalletService
{
    private readonly IFreeSql _freeSql;

    private readonly IPayeeBankCardService _payeeBankCardService;
    private readonly IUserBankCardService _userBankCardService;
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    /// <param name="payeeBankCardService"></param>
    /// <param name="userBankCardService"></param>
    /// <param name="userService"></param>
    public UserWalletService(IFreeSql freeSql,
        IPayeeBankCardService payeeBankCardService,
        IUserBankCardService userBankCardService,
        IUserService userService)
    {
        _freeSql = freeSql;
        _payeeBankCardService = payeeBankCardService;
        _userBankCardService = userBankCardService;
        _userService = userService;
    }

    /// <summary>
    /// 资金变动申请创建
    /// throw new MyException
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <exception cref="MyException"></exception>
    public async Task<string> MoneyApplyCreate(MoneyApplyInput input,long userId)
    {
        if (input.Amount <= 0)
            return "Please enter the amount";
        var user = await _freeSql.Select<Users>()
            .Where(s => s.IsDeleted == 0 && s.IsAdmin == 0)
            .Where(s => s.Id == userId)
            .ToOneAsync();
        if (user == null)
            return "login expired";
        //当前时间
        var year = DateTimeOffset.UtcNow.Year;
        //查看用户是否存在还未完成的申请
        var userMoneyApply = await _freeSql.Select<UserMoneyApply>().AsTable((type, table) => $"{table}_{year}")
            .Where(s => s.UserId == userId && s.IsDeleted == 0)
            .Where(s => s.AuditStatus == AuditStatusEnums.Default || s.AuditStatus == AuditStatusEnums.Ing)
            .Where(s => s.SourceType == input.SourceType)
            .ToListAsync();
        if (userMoneyApply.Count > 0)
            return "There are still unfulfilled orders";
        //充值
        if (input.SourceType == WalletSourceEnums.RechargeApply)
        {
            //线下支付
            if (input.Type?.ToLower() == PayTypeConsts.BankCard)
            {
                if (input.PayeeBankCardId == 0)
                    return "Please contact customer service";
                //查找对应收款卡
                var bankCard = await _payeeBankCardService.GetAvailablePayeeBankCards(bankCardId:input.PayeeBankCardId);
                if (bankCard == null)
                    return "Please contact customer service";
                var payText = $"卡号：{bankCard.CardNo}, 收到充值款{input.Amount}.";
                var moneyApply = input.MapTo<UserMoneyApply>();
                moneyApply.Id = IdHelper.GetId();
                moneyApply.PayText = payText;
                moneyApply.AuditStatus = AuditStatusEnums.Ing;
                moneyApply.ChangeType = WalletChangeEnums.In;
                moneyApply.UserId = userId;
                moneyApply.AuditText = "用户充值";
                moneyApply.Remark = $"充值${input.Amount}";
                await _freeSql.Insert(moneyApply).InsertTableTime(TableTimeFormat.Year).ExecuteAffrowsAsync();
                return "recharge_success";
            }
            //线上支付
            else if (input.Type?.ToLower() == PayTypeConsts.Payment)
            {
            
            }
            else
            {
                return "Wrong payment type";
            }
        }
        //提款
        else if (input.SourceType == WalletSourceEnums.WithdrawalApply)
        {
            //提款金额
            if (input.Amount > user.Balance)
                return "Insufficient balance";
            
            //查找用户银行卡
            var userBankCard = await _userBankCardService.GetUserBankCardList(userId, input.PayeeBankCardId);
            if (userBankCard.Count == 0)
                return "Please select the receiving bank card";
            //添加提款申请
            var moneyApply = input.MapTo<UserMoneyApply>();
            moneyApply.Id = IdHelper.GetId();
            moneyApply.AuditStatus = AuditStatusEnums.Ing;
            moneyApply.ChangeType = WalletChangeEnums.Out;
            moneyApply.PayText = $"提款：{input.Amount}, 提款卡号：{userBankCard.First().CardNo}.";
            moneyApply.UserId = userId;
            _freeSql.Transaction(() =>
            {
                //添加申请
                _freeSql.Insert(moneyApply).InsertTableTime(TableTimeFormat.Year).ExecuteAffrows();
                WalletRecordCreate(new UserWalletRecordInput
                {
                    UserId = userId,
                    SourceType = WalletSourceEnums.WithdrawalApply,
                    OperateUserId = userId,
                    Amount = input.Amount,
                    OperateType = WalletOperateEnums.User
                });
            });
            return "without_success";
        }
        //代还
        else if (input.SourceType == WalletSourceEnums.RepayApply)
        {
            //线下支付
            if (input.Type?.ToLower() == PayTypeConsts.BankCard)
            {
                if (input.PayeeBankCardId == 0)
                    return "Please contact customer service";
                //查找对应收款卡
                var bankCard = await _freeSql.Select<RepayBankCard>()
                    .Where(s => s.Id == input.PayeeBankCardId)
                    .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
                    .ToOneAsync();
                if (bankCard == null)
                    return "Please contact customer service";
                if (input.Amount != bankCard.Amount)
                    return "Please check the repayment amount";
                var repayLevel = await _freeSql.Select<RepayLevel>()
                    .Where(s => s.Id == bankCard.RepayLevelId)
                    .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
                    .ToOneAsync();
                if (repayLevel == null || repayLevel.UnlockBalance > user.Balance)
                    return "Please contact customer service";
                var payText = $"卡号：{bankCard.CardNo}, 收到代还金额{input.Amount}.";
                var moneyApply = input.MapTo<UserMoneyApply>();
                moneyApply.Id = IdHelper.GetId();
                moneyApply.PayText = payText;
                moneyApply.AuditStatus = AuditStatusEnums.Ing;
                moneyApply.ChangeType = WalletChangeEnums.In;
                moneyApply.UserId = userId;
                moneyApply.AuditText = "代理还款";
                moneyApply.Remark = $"还款：${input.Amount}";
                await _freeSql.Insert(moneyApply).InsertTableTime(TableTimeFormat.Year).ExecuteAffrowsAsync();
                return "repay_success";
            }
            //线上支付
            else if (input.Type?.ToLower() == PayTypeConsts.Payment)
            {
            
            }
            else
            {
                return "Wrong payment type";
            }
        }
        else
        {
            return "Parameter error";
        }
        return "0";
    }

   /// <summary>
   ///  获取资金变动申请列表
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   public async Task<PagedOutput<MoneyApplyDto>> GetMoneyApplyPagedList(MoneyApplyPagedInput input)
   {
       if (!input.StartTime.HasValue)
           input.StartTime = new DateTimeOffset(DateTime.UtcNow.Date).ToUnixTimeMilliseconds();
       if (!input.EndTime.HasValue)
           input.EndTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       var list = await _freeSql.Select<UserMoneyApply>()
           .WhereTableTime(TableTimeFormat.Year, input.StartTime.Value, input.EndTime.Value)
           .WhereIf(input.UserId.HasValue, s => s.UserId == input.UserId)
           .WhereIf(!string.IsNullOrEmpty(input.Username),
               s => _freeSql.Select<Users>()
                   .Where(u => u.Username.Contains(input.Username) || u.Nickname.Contains(input.Username))
                   .ToList(u => u.Id).Contains(s.UserId))
           .WhereIf(input.Source.HasValue, s => s.SourceType == input.Source)
           .WhereIf(input.Status.HasValue, s => s.AuditStatus == input.Status)
           .Where(s => s.CreateAt >= input.StartTime.Value && s.CreateAt <= input.EndTime.Value)
           .Where(s => s.IsDeleted == 0)
           .OrderByDescending(s => s.CreateAt)
           .Count(out long totalCount)
           .Page(input.PageIndex, input.PageSize)
           .ToListAsync(s => new MoneyApplyDto
           {
                ApplyId = s.Id,
                Amount = s.Amount,
                UserId = s.UserId,
                AuditStatus = s.AuditStatus,
                AuditUserId = s.AuditUserId,
                WalletSource = s.SourceType,
                AuditAt = s.AuditAt,
                AuditText = s.AuditText,
                PayeeBankCardId = s.PayeeBankCardId,
                PaymentInfoId = s.PaymentInfoId,
                PayText = s.PayText,
                Remark = s.Remark,
                CreateAt = s.CreateAt
           });
       var userIds = list.Select(s => s.UserId);
       var auditUserIds = list.Select(s => s.AuditUserId);
       var paymentInfoIds = list.Select(s => s.PaymentInfoId);
       var users = await _freeSql.Select<Users>().Where(s => userIds.Contains(s.Id)).ToListAsync();
       var auditUsers = await _freeSql.Select<Users>().Where(s => auditUserIds.Contains(s.Id)).ToListAsync();
       var paymentInfos = await _freeSql.Select<PaymentInfos>().Where(s => paymentInfoIds.Contains(s.Id)).ToListAsync();
       list.ForEach(item =>
       {
           item.Username = users.FirstOrDefault(s => s.Id == item.UserId)?.Username ?? String.Empty;
           item.Nickname = users.FirstOrDefault(s => s.Id == item.UserId)?.Nickname ?? String.Empty;
           item.AuditUsername = auditUsers.FirstOrDefault(s => s.Id == item.AuditUserId)?.Username ?? string.Empty;
           item.AuditNickname = auditUsers.FirstOrDefault(s => s.Id == item.AuditUserId)?.Nickname ?? string.Empty;
           item.PaymentInfoName = paymentInfos.FirstOrDefault(s => s.Id == item.PaymentInfoId)?.DisplayName ?? string.Empty;
           
       });

       var output = new PagedOutput<MoneyApplyDto>
       {
           TotalCount = totalCount,
           Items = list
       };

       return output;
   }
    

        /// <summary>
        ///  资金变动审核
        /// </summary>
        /// <param name="input"></param>
        /// <param name="auditUserId"></param>
        /// <returns></returns>
        public async Task MoneyApplyAudit(MoneyApplyAuditInput input, long auditUserId)
   {
       if (input.Status == AuditStatusEnums.Ing)
       {
           await MoneyApplyAuditIng(input.MoneyApplyId,input.AuditText,auditUserId);
       }
       else if (input.Status == AuditStatusEnums.Success)
       {
           await MoneyApplyAuditSuccess(input.MoneyApplyId,input.AuditText,auditUserId);
       }
       else if (input.Status == AuditStatusEnums.Fail)
       {
           await MoneyApplyAuditFail(input.MoneyApplyId,input.AuditText,auditUserId);
       }
       else
       {
           throw new MyException("Review status error");
       }
   }

   /// <summary>
   ///  资金变动记录添加
   /// </summary>
   /// <param name="input"></param>
   public void WalletRecordCreate(UserWalletRecordInput input)
   {
       var user = _freeSql.Select<Users>()
           .Where(s => s.IsDeleted == 0 && s.Id == input.UserId)
           .ToOne();
       if (user == null)
           throw new MyException("Data error");
       WalletChangeEnums changeType = WalletChangeEnums.In;

       #region 余额变动

       if (input.SourceType == WalletSourceEnums.Recharge
           || input.SourceType == WalletSourceEnums.WithdrawalReturn
           || input.SourceType == WalletSourceEnums.WithdrawalUnFreeze
           || input.SourceType == WalletSourceEnums.BuyFinancilReturn
           || input.SourceType == WalletSourceEnums.SoldFinancil
           || input.SourceType == WalletSourceEnums.Repayment
           || input.SourceType == WalletSourceEnums.RepayProfit
           || input.SourceType == WalletSourceEnums.FinancilProfit)
       {
           user.Balance += input.Amount;
       }
       else if (input.SourceType == WalletSourceEnums.WithdrawalApply
                || input.SourceType == WalletSourceEnums.Withdrawal
                || input.SourceType == WalletSourceEnums.BuyFinancil)
       {
           if (input.Amount >= user.Balance)
               throw new MyException("Insufficient balance");
           user.Balance -= input.Amount;
           changeType = WalletChangeEnums.Out;
       }
       else
       {
           throw new MyException("Wallet source error");
       }

       #endregion

       #region 冻结资金变动

       if (input.SourceType == WalletSourceEnums.WithdrawalApply)
       {
           user.FreezeFunds += input.Amount;
       }

       if (input.SourceType == WalletSourceEnums.WithdrawalUnFreeze)
       {
           user.FreezeFunds -= input.Amount;
       }

       #endregion
   
       var newRecord = new UserWalletRecord
       {
           Id = IdHelper.GetId(),
           SourceType = input.SourceType,
           UserId = input.UserId,
           Amount = input.Amount,
           ChangeType = changeType,
           OperationType = input.OperateType,
           OperateUserId = input.OperateUserId
       };
       _freeSql.Transaction(() =>
       {
           //修改用户余额信息
           _freeSql.Update<Users>(user.Id)
               .SetDto(new {FreezeFunds = user.FreezeFunds,Balance = user.Balance}).ExecuteAffrows();
           //添加资金变动记录
           _freeSql.Insert(newRecord).InsertTableTime(TableTimeFormat.Month).ExecuteAffrows();
       });
   }

   /// <summary>
   ///  获取资金变动明细列表
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   /// <exception cref="NotImplementedException"></exception>
   public async Task<PagedOutput<UserWalletRecordDto>> GetUserWalletRecordPagedList(WalletRecordPagedInput input)
   {
       if (input.StartTime == 0)
           input.StartTime = DateTimeHelper.DayStart();
       if (input.EndTime == 0)
           input.StartTime = DateTimeHelper.UtcNow();
       var list = await _freeSql.Select<UserWalletRecord>()
           .WhereTableTime(TableTimeFormat.Month, input.StartTime, input.EndTime)
           .WhereIf(input.UserId.HasValue, s => s.UserId == input.UserId)
           .WhereIf(input.WalletSource.HasValue, s => s.SourceType == input.WalletSource)
           .Where(s => s.CreateAt >= input.StartTime && s.CreateAt <= input.EndTime)
           .Where(s => s.IsDeleted == 0)
           .Count(out long totalCount)
           .Page(input.PageIndex,input.PageSize)
           .ToListAsync();
       var items = list.MapToList<UserWalletRecordDto>();
       var userIds = list.Select(s => s.UserId).Union(list.Select(s => s.OperateUserId));
       var users = await _freeSql.Select<Users>()
           .Where(s => userIds.Contains(s.Id))
           .ToListAsync();
       
       items.ForEach(item =>
       {
           item.Username = users.FirstOrDefault(s => s.Id == item.UserId)?.Username ?? string.Empty;
           item.Nickname = users.FirstOrDefault(s => s.Id == item.UserId)?.Nickname ?? string.Empty;
           item.OperateNickname = users.FirstOrDefault(s => s.Id == item.OperateUserId)?.Nickname ?? string.Empty;
           item.OperateUsername = users.FirstOrDefault(s => s.Id == item.OperateUserId)?.Username ?? string.Empty;
           item.OperateTypeText = EnumHelper.GetDescription(item.OperateType);
           item.SourceTypeText = EnumHelper.GetDescription(item.SourceType);
       });
       
       var output = new PagedOutput<UserWalletRecordDto>
       {
           TotalCount = totalCount,
           Items = items
       };
       return output;
   }

   /// <summary>
   ///  获取资金申请（最多可获取一年前的数据）
   /// </summary>
   /// <param name="moneyApplyId"></param>
   /// <returns></returns>
   private async Task<UserMoneyApply> GetMoneyApply(long moneyApplyId)
   {
       //数据跨年查一次防止跨年数据
       var timeStart = new DateTimeOffset(DateTime.UtcNow.AddYears(-1)).ToUnixTimeMilliseconds();
       var timeEnd = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       var moneyApply = await _freeSql.Select<UserMoneyApply>()
           .WhereTableTime(TableTimeFormat.Year, timeStart, timeEnd)
           .Where(s => s.Id == moneyApplyId)
           .Where(s => s.IsDeleted == 0)
           .ToOneAsync();
       return moneyApply;
   }

   /// <summary>
   ///  资金变动申请标记审核中
   /// </summary>
   /// <param name="moneyApplyId"></param>
   /// <param name="auditText"></param>
   /// <param name="auditUserId"></param>
   public async Task MoneyApplyAuditIng(long moneyApplyId,string auditText,long auditUserId)
   {
       var moneyApply = await GetMoneyApply(moneyApplyId);
       if (moneyApply == null)
           throw new MyException("Application does not exist");
       if (moneyApply.AuditStatus == AuditStatusEnums.Ing)
           throw new MyException("Review status has not changed");
       if (moneyApply.AuditStatus != AuditStatusEnums.Default)
           throw new MyException("Has been reviewed");
       var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       //数据分表年份
       var tableYear = DateTimeOffset.FromUnixTimeMilliseconds(moneyApply.CreateAt).Year;
       //更新数据
       await _freeSql.Update<UserMoneyApply>(moneyApply).UpdateTableTime(TableTimeFormat.Year,moneyApply.CreateAt)
           .SetDto(new
           {
               AuditAt = utcNow,
               AuditStatus = AuditStatusEnums.Ing,
               AuditText = auditText,
               AuditUserId = auditUserId,
               UpdateAt = utcNow
           }).ExecuteAffrowsAsync();
   }

   /// <summary>
   ///  资金变动申请标记失败
   /// </summary>
   /// <param name="moneyApplyId"></param>
   /// <param name="auditText"></param>
   /// <param name="auditUserId"></param>
   public async Task MoneyApplyAuditFail(long moneyApplyId,string auditText,long auditUserId)
   {
       var moneyApply = await GetMoneyApply(moneyApplyId);
       if (moneyApply == null)
           throw new MyException("Application does not exist");
       if (moneyApply.AuditStatus == AuditStatusEnums.Fail)
           throw new MyException("Review status has not changed");
       if (moneyApply.AuditStatus != AuditStatusEnums.Default && moneyApply.AuditStatus != AuditStatusEnums.Ing)
           throw new MyException("Has been reviewed");
       if (string.IsNullOrEmpty(auditText))
           throw new MyException("Please fill in the reason for failure");
       //如果提款审核失败，需要解冻用户资金
       var user = await _freeSql.Select<Users>().Where(s => s.Id == moneyApply.UserId)
           .Where(s => s.IsDeleted == 0)
           .ToOneAsync();
       //修改申请数据
       var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       _freeSql.Transaction(() =>
       {
           //更新修改申请信息
           _freeSql.Update<UserMoneyApply>(moneyApply.Id).UpdateTableTime(TableTimeFormat.Year,moneyApply.CreateAt)
               .SetDto(new
                   {
                       AuditAt = utcNow,
                       AuditStatus = AuditStatusEnums.Fail,
                       AuditText = auditText,
                       AuditUserId = auditUserId,
                       UpdateAt = utcNow
                   })
               .ExecuteAffrows();
           //添加用户资金记录
           if (moneyApply.SourceType == WalletSourceEnums.WithdrawalApply)
           {
               WalletRecordCreate(new UserWalletRecordInput
               {
                    UserId = moneyApply.UserId,
                    SourceType = WalletSourceEnums.WithdrawalReturn,
                    OperateUserId = auditUserId,
                    Amount = moneyApply.Amount,
                    OperateType = WalletOperateEnums.Admin
               });
           }
       });
       
   }

   /// <summary>
   ///  资金变动申请标记成功
   /// </summary>
   /// <param name="moneyApplyId"></param>
   /// <param name="auditText"></param>
   /// <param name="auditUserId"></param>
   public async Task MoneyApplyAuditSuccess(long moneyApplyId,string auditText,long auditUserId)
   {
       var moneyApply = await GetMoneyApply(moneyApplyId);
       if (moneyApply == null)
           throw new MyException("Application does not exist");
       if (moneyApply.AuditStatus == AuditStatusEnums.Success)
           throw new MyException("Review status has not changed");
       if (moneyApply.AuditStatus != AuditStatusEnums.Default && moneyApply.AuditStatus != AuditStatusEnums.Ing)
           throw new MyException("Has been reviewed");
       var user = await _freeSql.Select<Users>()
           .Where(s => s.Id == moneyApply.UserId && s.IsDeleted == 0)
           .ToOneAsync();
       var repayProfitAmount = 0m;
       if (moneyApply.SourceType == WalletSourceEnums.RepayApply)
       {
           var repayCard = await _freeSql.Select<RepayBankCard>()
               .Where(s => s.Id == moneyApply.PayeeBankCardId)
               .ToOneAsync();
           var repayLevel = await _freeSql.Select<RepayLevel>()
               .Where(s => s.Id == repayCard.RepayLevelId)
               .ToOneAsync();
           repayProfitAmount = moneyApply.Amount * repayLevel.ProfitRate * 0.01m;
       }

       var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       _freeSql.Transaction(() =>
       {
           //修改资金申请信息
           _freeSql.Update<UserMoneyApply>(moneyApply.Id).UpdateTableTime(TableTimeFormat.Year,moneyApply.CreateAt)
               .SetDto(new
               {
                   AuditAt = utcNow,
                   AuditStatus = AuditStatusEnums.Success,
                   AuditText = auditText,
                   AuditUserId = auditUserId,
                   UpdateAt = utcNow
               }).ExecuteAffrows();
           //添加用户充值流水
           if (moneyApply.SourceType == WalletSourceEnums.RechargeApply)
           {
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = moneyApply.Amount,
                   SourceType = WalletSourceEnums.Recharge,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
           }

           if (moneyApply.SourceType == WalletSourceEnums.WithdrawalApply)
           {
               //解冻资金
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = moneyApply.Amount,
                   SourceType = WalletSourceEnums.WithdrawalUnFreeze,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
               //提款
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = moneyApply.Amount,
                   SourceType = WalletSourceEnums.Withdrawal,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
           }

           if (moneyApply.SourceType == WalletSourceEnums.RepayApply)
           {
               //添加代还流水
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = moneyApply.Amount,
                   SourceType = WalletSourceEnums.Repayment,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
               //添加还款收益流水
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = repayProfitAmount,
                   SourceType = WalletSourceEnums.RepayProfit,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
               //更新用户为团队成员
               _userService.UserBecomeTeamUser(moneyApply.UserId);
           }
       });
       
   }
    /// <summary>
    ///  获取当前用户当年的所有提现记录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<List<MoneyApplyDto>> GetMoneyApplyRecode(long userid)
    {
        var user = await _freeSql.Select<Users>()
                   .Where(s => s.Id == userid)
                   .ToOneAsync();
        var year = DateTimeOffset.UtcNow.Year;
        var userMoneyApply = await _freeSql.Select<UserMoneyApply>().AsTable((type, table) => $"{table}_{year}")
            .Where(s => s.UserId == userid && s.IsDeleted == 0)
            .Where(s => s.SourceType == WalletSourceEnums.WithdrawalApply).OrderByDescending(m => m.CreateAt)
            .ToListAsync<MoneyApplyDto>();
        foreach (var item in userMoneyApply)
        {
            item.WalletSourceName = item.WalletSource.ToDescriptionOrString();
            item.Balance = user.Balance;
            if (item.WalletSource== WalletSourceEnums.Recharge) 
                item.ChangeName = "+ $" + item.Amount; 
            if (item.WalletSource == WalletSourceEnums.Withdrawal)
                item.ChangeName = "- $" + item.Amount;

        }
        return userMoneyApply;
    }
}