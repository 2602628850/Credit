using Data.Commons.Enums;

namespace Credit.UserWalletServices.Dtos;

public class UserWalletRecordDto
{
    
}

/// <summary>
///  资金变动记录输入
/// </summary>
public class UserWalletRecordInput
{
    /// <summary>
    ///  用户Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  资金
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///  操作类型
    /// </summary>
    public WalletOperateEnums OperateType { get; set; }

    /// <summary>
    ///  资金变动类型
    /// </summary>
    public WalletSourceEnums SourceType { get; set; }

    /// <summary>
    ///  操作用户
    /// </summary>
    public long OperateUserId { get; set; }
}