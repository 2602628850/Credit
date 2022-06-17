using Credit.PamentInfoModels;
using Credit.PayeeBankCardServices;
using Credit.PayeeInfoModels;
using Credit.UserModels;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    /// <param name="payeeBankCardService"></param>
    public UserWalletService(IFreeSql freeSql,
        IPayeeBankCardService payeeBankCardService)
    {
        _freeSql = freeSql;
        _payeeBankCardService = payeeBankCardService;
    }

   /// <summary>
   /// 资金变动申请创建
   /// </summary>
   /// <param name="input"></param>
   /// <param name="userId"></param>
   /// <exception cref="MyException"></exception>
   public async Task MoneyApplyCreate(MoneyApplyInput input,long userId)
    {
        if (input.Amount <= 0)
            throw new MyException("Please enter the amount");
        var user = await _freeSql.Select<Users>()
            .Where(s => s.IsDeleted == 0 && s.IsAdmin == 0)
            .Where(s => s.Id == userId)
            .ToOneAsync();
        if (user == null)
            throw new MyException("login expired");
        //当前时间
        var year = DateTimeOffset.UtcNow.Year;
        //查看用户是否存在还未完成的申请
        var userMoneyApply = await _freeSql.Select<UserMoneyApply>().AsTable((type, table) => $"{table}_{year}")
            .Where(s => s.UserId == userId && s.IsDeleted == 0)
            .Where(s => s.AuditStatus == AuditStatusEnums.Default || s.AuditStatus == AuditStatusEnums.Ing)
            .Where(s => s.SourceType == input.WalletSource)
            .ToListAsync();
        if (userMoneyApply.Count > 0)
            throw new MyException("There are still unfulfilled orders");
        //充值
        if (input.WalletSource == WalletSourceEnums.Recharge)
        {
            //线下支付
            if (input.Type?.ToLower() == PayTypeConsts.BankCard)
            {
                if (input.PayeeCardId == 0)
                    throw new MyException("Please contact customer service");
                //查找对应收款卡
                var bankCard = await _payeeBankCardService.GetAvailablePayeeBankCards(bankCardId:input.PayeeCardId);
                if (bankCard == null)
                    throw new MyException("Please contact customer service");
                var payText = string.Empty;
                if (input.WalletSource == WalletSourceEnums.Recharge)
                    payText = $"卡号：{bankCard.CardNo} 收到充值款{input.Amount}.";
                if (input.WalletSource == WalletSourceEnums.Withdrawal)
                    payText = $"用户申请提款{input.Amount}.";
                var moneyApply = input.MapTo<UserMoneyApply>();
                moneyApply.Id = IdHelper.GetId();
                moneyApply.PayText = payText;
                moneyApply.AuditStatus = AuditStatusEnums.Default;
                moneyApply.ChangeType = WalletChangeEnums.In;
                await _freeSql.Insert(moneyApply).InsertTableTime(TableTimeFormat.Year).ExecuteAffrowsAsync();
            }
            //线上支付
            else if (input.Type?.ToLower() == PayTypeConsts.Payment)
            {
            
            }
            else
            {
                throw new MyException("Wrong payment type");
            }
        }
        //提款
        else if (input.WalletSource == WalletSourceEnums.WithdrawalApply)
        {
            //提款金额
            if (input.Amount > user.Balance)
                throw new MyException("Insufficient balance");
            
            //查找用户银行卡
            
            
            //添加提款申请
            var moneyApply = input.MapTo<UserMoneyApply>();
            moneyApply.Id = IdHelper.GetId();
            moneyApply.AuditStatus = AuditStatusEnums.Default;
            moneyApply.ChangeType = WalletChangeEnums.Out;
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
        }
        else
        {
                
        }
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
                PayeeCardId = s.PayeeBankCardId,
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
       var changeType = WalletChangeEnums.In;
       if (input.SourceType == WalletSourceEnums.Recharge
           || input.SourceType == WalletSourceEnums.WithdrawalReturn)
       {
           user.Balance += input.Amount;
           if (input.SourceType == WalletSourceEnums.WithdrawalReturn)
               user.FreezeFunds -= input.Amount;
       }
       else if (input.SourceType == WalletSourceEnums.WithdrawalApply)
       {
           if (input.Amount >= user.Balance)
               throw new MyException("Insufficient balance");
           user.Balance -= input.Amount;
           user.FreezeFunds += input.Amount;
           changeType = WalletChangeEnums.Out;
       }
       else if (input.SourceType == WalletSourceEnums.Withdrawal)
       {
           user.FreezeFunds -= input.Amount;
           changeType = WalletChangeEnums.Out;
       }
       else
       {
           
       }

       var newRecord = new UserWalletRecord
       {
           Id = IdHelper.GetId(),
           SourceType = input.SourceType,
           UserId = input.UserId,
           Amount = input.Amount,
           ChangeType = changeType,
           operationType = input.OperateType,
           OperateUserId = input.OperateUserId
       };
       _freeSql.Transaction(() =>
       {
           //修改用户余额信息
           _freeSql.Update<Users>(user).ExecuteAffrows();
           //添加资金变动记录
           _freeSql.Insert(newRecord).InsertTableTime(TableTimeFormat.Month).ExecuteAffrows();
       });
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
       moneyApply.AuditAt = utcNow;
       moneyApply.AuditUserId = auditUserId;
       moneyApply.AuditText = auditText;
       moneyApply.AuditStatus = AuditStatusEnums.Ing;
       await _freeSql.Update<UserMoneyApply>(moneyApply).AsTable(table => $"{table}_{tableYear}").ExecuteAffrowsAsync();
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
       moneyApply.AuditAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       moneyApply.AuditText = auditText;
       moneyApply.AuditUserId = auditUserId;
       moneyApply.AuditStatus = AuditStatusEnums.Fail;
       _freeSql.Transaction(() =>
       {
           //更新修改申请信息
           _freeSql.Update<UserMoneyApply>(moneyApply).UpdateTableTime(TableTimeFormat.Year,moneyApply.CreateAt)
               .ExecuteAffrows();
           //添加用户资金记录
           if (moneyApply.SourceType == WalletSourceEnums.WithdrawalApply)
           {
               WalletRecordCreate(new UserWalletRecordInput
               {
                    UserId = moneyApply.UserId,
                    SourceType = WalletSourceEnums.Withdrawal,
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
       moneyApply.AuditAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
       moneyApply.AuditStatus = AuditStatusEnums.Success;
       moneyApply.AuditText = auditText;
       moneyApply.AuditUserId = auditUserId;
       _freeSql.Transaction(() =>
       {
           //修改资金申请信息
           _freeSql.Update<UserMoneyApply>(moneyApply).ExecuteAffrows();
           //添加用户充值流水
           if (moneyApply.SourceType == WalletSourceEnums.Recharge)
           {
               WalletRecordCreate(new UserWalletRecordInput
               {
                   Amount = moneyApply.Amount,
                   SourceType = WalletSourceEnums.Recharge,
                   OperateUserId = auditUserId,
                   UserId = moneyApply.UserId
               });
           }
       });
   }
}