using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;

namespace Credit.UserWalletServices.Dtos;

/// <summary>
///   资金变动分页输入
/// </summary>
public class WalletRecordPagedInput : PagedInput
{
    /// <summary>
    ///  用户Id
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    ///  变动类型
    /// </summary>
    public WalletSourceEnums? WalletSource { get; set; }

    /// <summary>
    ///  开始时间
    /// </summary>
    public long StartTime { get; set; } = DateTimeHelper.DayStart();

    /// <summary>
    ///  结束时间
    /// </summary>
    public long EndTime { get; set; } = DateTimeHelper.UtcNow();
}