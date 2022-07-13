using Data.Commons.Enums;
using Data.Commons.Helpers;

namespace Credit.OrderServices.Dtos;

/// <summary>
///  理财订单输出DTO
/// </summary>
public class FinancilOrderDto
{
    /// <summary>
    ///  订单Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  理财产品Id
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    ///  产品名称
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    ///  用户Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  用户账号
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///  用户昵称
    /// </summary>
    public string Nickname { get; set; } = string.Empty;

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
    ///  审核状态
    /// </summary>
    public string StatusText { get; set; } = string.Empty;

    /// <summary>
    ///  审核人
    /// </summary>
    public long AuditUserId { get; set; }

    /// <summary>
    ///  是否结束
    /// </summary>
    public int IsSold { get; set; }
    
    /// <summary>
    ///  审核时间
    /// </summary>
    public long AuditAt { get; set; }
    /// <summary>
    /// 审核时间
    /// </summary>
    public string ToAuditAt
    {
        get
        {
            return DateTimeHelper.UnixTimeToDateTime(AuditAt).ToString("yyyy-MM-dd HH:mm");
        }
    }

    /// <summary>
    ///  审核文字
    /// </summary>
    public string AuditText { get; set; }
    
    /// <summary>
    ///  售出审核状态
    /// </summary>
    public AuditStatusEnums? SoldStatus { get; set; }

    /// <summary>
    ///  售出审核状态
    /// </summary>
    public string SoldStatusText { get; set; } = string.Empty;
    
    /// <summary>
    ///  售出审核文字
    /// </summary>
    public string SoldAuditText { get; set; } = string.Empty;

    /// <summary>
    ///  购买时间
    /// </summary>
    public long CreateAt { get; set; }
    /// <summary>
    ///  购买时间
    /// </summary>
    public string TodateTime
    {
        get
        {
            return DateTimeHelper.UnixTimeToDateTime(CreateAt).ToString("yyyy-MM-dd HH:mm");
        }
    }
}

/// <summary>
///  理财订单输入
/// </summary>
public class FinancilOrderInput
{
    /// <summary>
    ///  理财产品Id
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    ///  购买份数
    /// </summary>
    public int UnitCount { get; set; }
}