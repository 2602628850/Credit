using Data.Commons.Dtos;

namespace Credit.TeamServices.Dtos;

public class TeamLevelPagedInput : PagedInput
{
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;
}