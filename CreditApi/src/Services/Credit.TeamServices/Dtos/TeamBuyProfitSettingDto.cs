namespace Credit.TeamServices.Dtos;

public class TeamBuyProfitSettingInput
{
    /// <summary>
    ///  主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  利润比例
    /// </summary>
    public decimal BuyProfitRate { get; set; }

    /// <summary>
    ///  利润层级
    /// </summary>
    public int Hierarchy { get; set; }
}

public class TeamBuyProfitSettingDto : TeamBuyProfitSettingInput
{
    
}

/// <summary>
///  团队用户及相对层级
/// </summary>
public class TeamUserDto
{
    /// <summary>
    ///  用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  层级 1 
    /// </summary>
    public int Hierarchy { get; set; }
}