using Data.Commons.Models;

namespace Credit.BankModels;

/// <summary>
///  银行信息
/// </summary>
public class BankInfo : BaseModel
{
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  银行编码
    /// </summary>
    public string BankCode { get; set; } = string.Empty;

    /// <summary>
    ///  是否启用 0 未启用 1 已启用
    /// </summary>
    public int IsEnable { get; set; }
}