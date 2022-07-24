namespace Credit.UserServices.Dtos;

/// <summary>
///  用户任务完成次数
/// </summary>
public class UserTaskCompletedCountDto
{
    /// <summary>
    ///   今日信用卡还款次数
    /// </summary>
    public long DayCardRepayCount { get; set; }

    /// <summary>
    ///  本周贷款还款次数
    /// </summary>
    public long WeekLoanRepayCount { get; set; }
}