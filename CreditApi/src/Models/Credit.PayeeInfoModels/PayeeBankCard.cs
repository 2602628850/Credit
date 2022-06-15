using Data.Commons.Models;

namespace Credit.PayeeInfoModels;

/// <summary>
///  收款卡号
/// </summary>
public class PayeeBankCard : BaseModel
{
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
    ///  银行卡绑定姓名
    /// </summary>
    public string BindRealName { get; set; } = string.Empty;

    /// <summary>
    ///   开户行地址
    /// </summary>
    public string BankAddress { get; set; } = string.Empty;

    /// <summary>
    ///  最低收款金额
    /// </summary>
    public decimal MinPayeeAmount { get; set; }

    /// <summary>
    ///  最高收款金额
    /// </summary>
    public decimal MaxPayeeAmount { get; set; }

    /// <summary>
    ///   开启时间
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    ///   关闭时间
    /// </summary>
    public TimeSpan EndTime { get; set; }

    /// <summary>
    ///  是否启动
    /// </summary>
    public int IsEnable { get; set; }
}