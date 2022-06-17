using Data.Commons.Enums;
using Data.Commons.Models;

namespace Credit.UserWalletModels;

/// <summary>
///  用户资金记录
/// </summary>
public class UserWalletRecord : BaseModel
{
    /// <summary>
    ///  用户Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///  操作类型  0 系统  10 管理员  20 用户
    /// </summary>
    public WalletOperateEnums operationType { get; set; }
    
    /// <summary>
    ///  改变类型  0 入账  10 出账
    /// </summary>
    public WalletChangeEnums ChangeType { get; set; }

    /// <summary>
    ///  来源类型 0 充值
    /// </summary>
    public WalletSourceEnums SourceType { get; set; }

    /// <summary>
    ///  操作人UserId
    /// </summary>
    public long OperateUserId { get; set; }
}