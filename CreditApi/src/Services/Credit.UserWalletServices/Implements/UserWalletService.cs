using Credit.PayeeBankCardServices;
using Credit.PayeeInfoModels;
using Credit.UserModels;
using Credit.UserWalletModels;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Consts;
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
                await _freeSql.Insert(moneyApply).AsTable(table => $"{table}_{year}").ExecuteAffrowsAsync();
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
        else if (input.WalletSource == WalletSourceEnums.Withdrawal)
        {
            //提款金额
            if (input.Amount > user.Balance)
                throw new MyException("Insufficient balance");
            //冻结用户资金
            user.Balance = user.Balance - input.Amount;
            user.FreezeFunds = user.FreezeFunds + input.Amount;
            
            //查找用户银行卡
            
            
            //添加提款申请
            var moneyApply = input.MapTo<UserMoneyApply>();
            moneyApply.Id = IdHelper.GetId();
            moneyApply.AuditStatus = AuditStatusEnums.Default;
            moneyApply.ChangeType = WalletChangeEnums.Out;
            await _freeSql.Insert(moneyApply).AsTable(table => $"{table}_{year}").ExecuteAffrowsAsync();
        }
        else
        {
                
        }
    }
}