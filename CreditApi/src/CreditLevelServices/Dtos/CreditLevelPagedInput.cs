using Data.Commons.Dtos;

namespace Credit.CreditLevelServices.Dtos;

public class CreditLevelPagedInput : PagedInput
{
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;
}