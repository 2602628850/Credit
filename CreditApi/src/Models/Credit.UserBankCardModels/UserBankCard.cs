using Data.Commons.Models;

namespace Credit.UserBankCardModels;

public class UserBankCard : BaseModel
{
    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }

    /// <summary>
    ///  用户Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  支行名称
    /// </summary>
    public string BankBranch { get; set; } = string.Empty;

    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  绑定用户名称
    /// </summary>
    public string BindUser { get; set; } = string.Empty;
    /// <summary>
    /// 用户手机号
    /// </summary>
    public string Phone { get; set; } = string.Empty;
    /// <summary>
    /// 国家
    /// </summary>
    public string CountryName { get; set; } = string.Empty;

}