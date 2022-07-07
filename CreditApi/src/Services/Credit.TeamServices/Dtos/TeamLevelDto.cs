namespace Credit.TeamServices.Dtos;

public class TeamLevelDto : TeamLevelInput
{
    /// <summary>
    ///  添加时间
    /// </summary>
    public long CreateAt { get; set; }
}

/// <summary>
///  团队等级输入
/// </summary>
public class TeamLevelInput
{
    /// <summary>
    ///  主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  团队等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;

    /// <summary>
    ///  邀请人数
    /// </summary>
    public int InviteCount { get; set; }

    /// <summary>
    ///  团队还款分润比例
    /// </summary>
    public decimal TeamRepayRate { get; set; }

    /// <summary>
    ///  团队购买理财分润比例
    /// </summary>
    public decimal TeamBuyRate { get; set; }
    
    /// <summary>
    ///  团队等级
    /// </summary>
    public int LevelSort { get; set; }
}