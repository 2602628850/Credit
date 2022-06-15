using System.ComponentModel;

namespace Data.Commons.Enums;

/// <summary>
///  审核状态枚举
///  0 默认
///  10 处理中
///  20 成功
///  30 失败
/// </summary>
public enum AuditStatusEnums
{
    /// <summary>
    ///  默认
    /// </summary>
    [Description("默认")]
    Default = 0,
       
    /// <summary>
    ///  处理中
    /// </summary>
    [Description("处理中")]
    Ing = 10,
    
    /// <summary>
    ///  成功
    /// </summary>
    [Description("成功")]
    Success = 20,
    
    /// <summary>
    ///  失败
    /// </summary>
    [Description("失败")]
    Fail = 30,
}