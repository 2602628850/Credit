using Data.Commons.Enums;

namespace Credit.UserWalletServices.Dtos;

public class UserWalletRecordDto : UserWalletRecordInput
{
    /// <summary>
    ///  记录Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///  创建时间
    /// </summary>
    public long CreateAt { get; set; }
    
    /// <summary>
    ///  变动后余额
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    ///  用户账号
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///  用户昵称
    /// </summary>
    public string Nickname { get; set; } = string.Empty;

    /// <summary>
    ///  操作人账号
    /// </summary>
    public string OperateUsername { get; set; } = string.Empty;

    /// <summary>
    ///  操作人昵称
    /// </summary>
    public string OperateNickname { get; set; } = string.Empty;

    /// <summary>
    ///  操作类型
    /// </summary>
    public WalletOperateEnums OperateType { get; set; }

    /// <summary>
    ///  操作类型
    /// </summary>
    public string OperateTypeText { get; set; } = string.Empty;
    
    /// <summary>
    ///  来源类型 0 充值
    /// </summary>
    public WalletSourceEnums SourceType { get; set; }

    /// <summary>
    ///  来源
    /// </summary>
    public string SourceTypeText { get; set; } = string.Empty;
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