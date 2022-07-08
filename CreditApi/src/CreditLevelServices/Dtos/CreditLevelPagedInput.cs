using Data.Commons.Dtos;

namespace Credit.TeamServices.Dtos;

public class CreditLevelPagedInput : PagedInput
{
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;
}