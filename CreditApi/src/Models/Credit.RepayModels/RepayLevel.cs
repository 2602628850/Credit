using Data.Commons.Models;
using FreeSql.DataAnnotations;

namespace Credit.RepayModels;

/// <summary>
///  还款等级
/// </summary>
public class RepayLevel : BaseModel
{
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;

    /// <summary>
    ///  封面图片
    /// </summary>
    public string CoverImage { get; set; } = string.Empty;

    /// <summary>
    ///  余额限制
    /// </summary>
    public decimal UnlockBalance { get; set; }

    /// <summary>
    ///  收益
    /// </summary>
    public decimal ProfitRate { get; set; }

    /// <summary>
    ///  最低还款限制
    /// </summary>
    public decimal MinRepayAmount { get; set; }

    /// <summary>
    ///  最高还款限制
    /// </summary>
    public decimal MaxRepayAmount { get; set; }

    /// <summary>
    ///   产品介绍
    /// </summary>
    [Column(StringLength = 1024)]
    public string Introduction { get; set; } = string.Empty;

    /// <summary>
    ///  是否启用
    /// </summary>
    public int IsEnable { get; set; }

}