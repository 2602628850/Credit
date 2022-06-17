using Data.Commons.Dtos;
using Data.Commons.Enums;

namespace Credit.UserWalletServices.Dtos;

/// <summary>
///  申请列表查询输入
/// </summary>
public class MoneyApplyPagedInput : PagedInput
{
    /// <summary>
    ///  用户名称
    /// </summary>
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    ///  来源
    /// </summary>
    public WalletSourceEnums? Source { get; set; }

    /// <summary>
    ///  审核状态
    /// </summary>
    public AuditStatusEnums? Status { get; set; }
    
    /// <summary>
    ///  开始时间
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    ///  结束时间
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    ///  用户Id
    /// </summary>
    public long? UserId { get; set; }
}