using Data.Commons.Dtos;

namespace Credit.RepayServices.Dtos;

/// <summary>
///  还款等级分页输入
/// </summary>
public class RepayLevelPagedInput : PagedInput
{
    /// <summary>
    ///  等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;
}