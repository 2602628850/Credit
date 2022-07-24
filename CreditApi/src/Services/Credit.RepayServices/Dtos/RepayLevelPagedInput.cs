using Data.Commons.Dtos;
using Data.Commons.Enums;

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
    
    /// <summary>
    ///  还款类型
    /// </summary>
    public RepayTypeEnums? RepayType { get; set; }
}