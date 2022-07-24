namespace Credit.SettingServices.Dtos;

/// <summary>
///  每周任务
/// </summary>
public class WeekTaskCreditSetting : ISetting
{
    /// <summary>
    ///  任务信用值
    /// </summary>
    public int TaskCreditValue { get; set; } 

    /// <summary>
    ///  每周任务次数
    /// </summary>
    public int TaskCountLimit { get; set; }
}