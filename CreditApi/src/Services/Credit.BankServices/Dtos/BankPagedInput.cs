using Data.Commons.Dtos;

namespace Credit.BankServices.Dtos;

/// <summary>
///  银行分页输入
/// </summary>
public class BankPagedInput : PagedInput
{
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  是否启用 0 禁用 1 启用
    /// </summary>
    public int? IsEnable { get; set; }
}