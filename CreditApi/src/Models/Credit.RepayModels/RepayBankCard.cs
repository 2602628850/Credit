using Data.Commons.Enums;
using Data.Commons.Models;

namespace Credit.RepayModels;

/// <summary>
///  还款卡号
/// </summary>
public class RepayBankCard : BaseModel
{
    /// <summary>
    ///  还款等级Id
    /// </summary>
    public long RepayLevelId { get; set; }

    /// <summary>
    ///  还款类型
    /// </summary>
    public RepayTypeEnums RepayType { get; set; }

    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }

    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  绑定用户
    /// </summary>
    public string BindUser { get; set; } = string.Empty;

    /// <summary>
    ///  还款金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///   启用/停用
    /// </summary>
    public int IsEnable { get; set; }
}