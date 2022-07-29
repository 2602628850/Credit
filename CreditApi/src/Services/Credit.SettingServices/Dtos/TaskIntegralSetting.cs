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
    ///  信用卡代还积分
    /// </summary>
    public int CardRepayIntegral { get; set; }

    /// <summary>
    ///  贷款代还积分
    /// </summary>
    public int LoanRepayIntegral { get; set; }

    /// <summary>
    ///  邀请用户积分
    /// </summary>
    public int InvitationIntegral { get; set; }

    /// <summary>
    ///  信用卡代还积分次数限制
    /// </summary>
    public int CardRepayIntegralCountLimit { get; set; }

    /// <summary>
    ///  贷款代还积分次数限制
    /// </summary>
    public int LoanRepayIntegralCountLimit { get; set; }
    /// <summary>
    ///  每日任务信用值
    /// </summary>
    public int TaskCreditValue { get; set; }

    /// <summary>
    ///  每日信用值任务次数
    /// </summary>
    public int TaskCountLimit { get; set; }
    /// <summary>
    ///  每周任务信用值
    /// </summary>
    public int WeekTaskCreditValue { get; set; }

    /// <summary>
    ///  每周信用值任务次数
    /// </summary>
    public int WeekTaskCountLimit { get; set; }
}