namespace Credit.SettingServices.Dtos;

/// <summary>
///  任务信用值设置
/// </summary>
public class TaskCreditSetting : ISetting
{
    /// <summary>
    ///  每日任务信用
    /// </summary>
    public int TaskCreditValue { get; set; } 

    /// <summary>
    ///  每日任务次数
    /// </summary>
    public int TaskCountLimit { get; set; }
}