using Data.Commons.Dtos;

namespace Credit.ProductServices.Dtos;

/// <summary>
///  理财产品分页输入
/// </summary>
public class FinancilProductPagedInput : PagedInput
{
    /// <summary>
    ///  产品名称
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    ///  启用状态 1 已启用  0 未启用
    /// </summary>
    public int? IsEnable { get; set; }
}