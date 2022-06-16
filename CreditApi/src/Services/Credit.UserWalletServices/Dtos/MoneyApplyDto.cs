using Data.Commons.Enums;

namespace Credit.UserWalletServices.Dtos;

/// <summary>
///  资金变动申请输入
/// </summary>
public class MoneyApplyInput : UserMoneyApplyInput
{
    /// <summary>
    ///  收支来源  0 充值  10 提款
    /// </summary>
    public WalletSourceEnums WalletSource { get; set; }
}

/// <summary>
///  用户资金变动输入
/// </summary>
public class UserMoneyApplyInput
{
    /// <summary>
    ///  三方支付Id
    /// </summary>
    public long PaymentInfoId { get; set; }

    /// <summary>
    ///   payment 线上支付   bankcard 线下支付
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    ///  金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///  备注
    /// </summary>
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    ///  收款卡号Id
    /// </summary>
    public long PayeeCardId { get; set; }
}

public class MoneyApplyDto
{
    
}