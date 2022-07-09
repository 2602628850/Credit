namespace Credit.ProductServices.Dtos;

/// <summary>
///  理财产品输出DTO
/// </summary>
public class FinancilProductDto : FinancilProductInput
{
    /// <summary>
    ///  添加时间
    /// </summary>
    public long CreateAt { get; set; }

    /// <summary>
    ///  最后修改时间
    /// </summary>
    public long UpdateAt { get; set; }
}

/// <summary>
///  理财产品输入
/// </summary>
public class FinancilProductInput
{
    /// <summary>
    ///  产品Id
    /// </summary>
    public long Id { get; set; }
    
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
    ///  收益周期（天）
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
    /// 产品介绍
    /// </summary>
    public string Introduction { get; set; }
    /// <summary>
    ///  启用  0 未启用  1 启用
    /// </summary>
    public int IsEnable { get; set; }

    /// <summary>
    ///  排序 数字越大 排序越靠前
    /// </summary>
    public int Sort { get; set; }
}