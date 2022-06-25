using Data.Commons.Enums;
using Data.Commons.Models;

namespace Credit.OrderModels;

/// <summary>
///  理财订单
/// </summary>
public class FinancilOrder : BaseModel
{
    /// <summary>
    ///  理财产品Id
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    ///  用户Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  份数
    /// </summary>
    public int UnitCount { get; set; }

    /// <summary>
    ///  购买单价
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///  购买总额
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    ///  日收益
    /// </summary>
    public decimal DailyRate { get; set; }

    /// <summary>
    ///  购买日期
    /// </summary>
    public string BuyDate { get; set; } = string.Empty;

    /// <summary>
    ///  周期
    /// </summary>
    public int Cycle { get; set; }

    /// <summary>
    ///  下次结算时间
    /// </summary>
    public string NextSettledDate { get; set; } = string.Empty;

    /// <summary>
    ///  结算次数
    /// </summary>
    public int SettledCount { get; set; }

    /// <summary>
    ///  审核状态
    /// </summary>
    public AuditStatusEnums Status { get; set; }

    /// <summary>
    ///  是否结束
    /// </summary>
    public int IsFinished { get; set; }
}