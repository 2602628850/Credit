using Data.Commons.Enums;

namespace Credit.RepayServices.Dtos;

/// <summary>
///  还款等级
/// </summary>
public class RepayLevelDto : RepayLevelInput
{
    /// <summary>
    ///  创建时间
    /// </summary>
    public long CreateAt { get; set; }
}

/// <summary>
///  还款等级输入
/// </summary>
public class RepayLevelInput
{
    /// <summary>
    ///  主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;
    
    /// <summary>
    ///  还款类型
    /// </summary>
    public RepayTypeEnums RepayType { get; set; }

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
    public string Introduction { get; set; } = string.Empty;
    
    /// <summary>
    ///  是否启用
    /// </summary>
    public int IsEnable { get; set; }
}

