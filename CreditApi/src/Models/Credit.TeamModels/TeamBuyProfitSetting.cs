using Data.Commons.Models;

namespace Credit.TeamModels;

/// <summary>
///  团队分润设置
/// </summary>
public class TeamBuyProfitSetting : BaseModel
{
    /// <summary>
    ///  利润比例
    /// </summary>
    public decimal BuyProfitRate { get; set; }

    /// <summary>
    ///  利润层级
    /// </summary>
    public int Hierarchy { get; set; }
}