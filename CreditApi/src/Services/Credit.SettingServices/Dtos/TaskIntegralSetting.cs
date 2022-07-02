namespace Credit.SettingServices.Dtos;

/// <summary>
///  任务积分设置
/// </summary>
public class TaskIntegralSetting : ISetting
{
    /// <summary>
    ///  购买产品积分
    /// </summary>
    public int BuyProductIntegral { get; set; }

    /// <summary>
    ///  代还积分
    /// </summary>
    public int RepaymentIntegral { get; set; }
}