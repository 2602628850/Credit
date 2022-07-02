using Data.Commons.Models;
using FreeSql.DataAnnotations;

namespace Credit.SettingModels;

/// <summary>
///  系统设置
/// </summary>
public class SysSettings : BaseModel
{
    /// <summary>
    /// 类名
    /// </summary>
    public string Classes { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Key { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    [Column(DbType = "longtext")]
    public string Value { get; set; } = string.Empty;
}