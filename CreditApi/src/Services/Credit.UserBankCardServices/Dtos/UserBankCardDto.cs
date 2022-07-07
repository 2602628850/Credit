using Data.Commons.Extensions;

namespace Credit.UserBankCardServices.Dtos;

public class UserBankCardDto : BindBankCardInput
{
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNoText
    {
        get { return CardNo.CardNoText1(); }
    }
}

/// <summary>
///  绑定银行卡
/// </summary>
public class BindBankCardInput
{
    /// <summary>
    /// id
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }

    /// <summary>
    ///  支行
    /// </summary>
    public string BankBranch { get; set; } = string.Empty;

    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  绑定用户
    /// </summary>
    public string BindUser { get; set; } = string.Empty;
}
