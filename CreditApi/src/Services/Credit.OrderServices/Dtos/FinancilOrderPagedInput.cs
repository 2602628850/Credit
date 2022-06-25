using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;

namespace Credit.OrderServices.Dtos;

/// <summary>
///  理财订单分页输入DTO
/// </summary>
public class FinancilOrderPagedInput : PagedInput
{
    /// <summary>
    ///  用户Id
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    ///  用户关键字（模糊查询）
    /// </summary>
    public string UserKey { get; set; } = string.Empty;

    /// <summary>
    ///  购买状态
    /// </summary>
    public AuditStatusEnums? Status { get; set; }

    /// <summary>
    ///  出售状态
    /// </summary>
    public AuditStatusEnums? SoldStatus { get; set; }

    /// <summary>
    ///  产品Id
    /// </summary>
    public long? ProductId { get; set; }
 
    /// <summary>
    ///  产品关键字（模糊查询）
    /// </summary>
    public string ProductKey { get; set; } = string.Empty;

    /// <summary>
    ///  是否出售
    /// </summary>
    public int? IsSold { get; set; }

    /// <summary>
    ///  开始时间
    /// </summary>
    public long StartTime { get; set; } = DateTimeHelper.DayStart();

    /// <summary>
    ///  结束时间 
    /// </summary>
    public long EndTime { get; set; } = DateTimeHelper.UtcNow();
}