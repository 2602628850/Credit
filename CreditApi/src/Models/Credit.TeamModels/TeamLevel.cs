using Data.Commons.Models;

namespace Credit.TeamModels;

/// <summary>
///  团队等级
/// </summary>
public class TeamLevel : BaseModel
{
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