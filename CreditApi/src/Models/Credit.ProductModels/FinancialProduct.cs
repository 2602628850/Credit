using Data.Commons.Models;

namespace Credit.ProductModels;

/// <summary>
///  理财产品
/// </summary>
public class FinancialProduct : BaseModel
{
    /// <summary>
    ///  产品名称
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    ///  封面图片
    /// </summary>
    public string CoverImage { get; set; } = string.Empty;

    /// <summary>
    ///  日收益比例
    /// </summary>
    public decimal DailyRate { get; set; }

    /// <summary>
    ///  收益周期
    /// </summary>
    public int Cycle { get; set; }

    /// <summary>
    ///  单价
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///  购买最低限制（份）
    /// </summary>
    public int BuyMinUnit { get; set; }

    /// <summary>
    ///  购买最高限制（份）
    /// </summary>
    public int BuyMaxUnit { get; set; }

    /// <summary>
    ///  产品介绍
    /// </summary>
    public string ProductIntroduction { get; set; } = string.Empty;

    /// <summary>
    ///  启用  0 未启用  1 启用
    /// </summary>
    public int IsEnable { get; set; }

    /// <summary>
    ///  排序 数字越大 排序越靠前
    /// </summary>
    public int Sort { get; set; }
}