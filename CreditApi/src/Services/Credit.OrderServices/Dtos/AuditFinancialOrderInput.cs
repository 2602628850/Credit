using Data.Commons.Enums;

namespace Credit.OrderServices.Dtos;

/// <summary>
///  审核理财订单输入
/// </summary>
public class AuditFinancialOrderInput
{
    /// <summary>
    ///  订单Id
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    ///  审核状态
    /// </summary>
    public AuditStatusEnums Status { get; set; }

    /// <summary>
    ///  审核文字
    /// </summary>
    public string AuditText { get; set; } = string.Empty;
}