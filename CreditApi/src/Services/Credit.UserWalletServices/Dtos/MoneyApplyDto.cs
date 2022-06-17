using Data.Commons.Enums;

namespace Credit.UserWalletServices.Dtos;

/// <summary>
///  资金变动申请输入
/// </summary>
public class MoneyApplyInput : UserMoneyApplyInput
{
    /// <summary>
    ///  收支来源  0 充值  10 提款
    /// </summary>
    public WalletSourceEnums WalletSource { get; set; }
}

/// <summary>
///  用户资金变动输入
/// </summary>
public class UserMoneyApplyInput
{
    /// <summary>
    ///  三方支付Id
    /// </summary>
    public long PaymentInfoId { get; set; }

    /// <summary>
    ///   payment 线上支付   bankcard 线下支付
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    ///  金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///  备注
    /// </summary>
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    ///  收款卡号Id
    /// </summary>
    public long PayeeCardId { get; set; }
}

public class MoneyApplyAuditInput
{
    /// <summary>
    ///  申请Id
    /// </summary>
    public long MoneyApplyId { get; set; }

    /// <summary>
    ///  审核状态
    /// </summary>
    public AuditStatusEnums Status { get; set; }

    /// <summary>
    ///   审核消息
    /// </summary>
    public string AuditText { get; set; } = string.Empty;

    /// <summary>
    ///   三方Id
    /// </summary>
    public long PayementInfoId { get; set; }
}

/// <summary>
///  资金变动输出DTO
/// </summary>
public class MoneyApplyDto : UserMoneyApplyInput
{
    /// <summary>
    ///    申请id
    /// </summary>
    public long ApplyId { get; set; }
    
    /// <summary>
    ///  收支来源  0 充值  10 提款
    /// </summary>
    public WalletSourceEnums WalletSource { get; set; }
    
    /// <summary>
    ///   支付信息
    /// </summary>
    public string PayText { get; set; } = string.Empty;

    /// <summary>
    ///  审核信息
    /// </summary>
    public string AuditText { get; set; } = string.Empty;
    
    /// <summary>
    ///   审核状态
    /// </summary>
    public AuditStatusEnums AuditStatus { get; set; }
    
    /// <summary>
    ///  审核人员Id
    /// </summary>
    public long AuditUserId { get; set; }

    /// <summary>
    ///  申请人Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  用户名
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///  用户昵称
    /// </summary>
    public string Nickname { get; set; } = string.Empty;

    /// <summary>
    ///  审核时间
    /// </summary>
    public long AuditAt { get; set; }

    /// <summary>
    ///  审核用户名
    /// </summary>
    public string AuditUsername { get; set; } = string.Empty;

    /// <summary>
    ///  审核用户昵称
    /// </summary>
    public string AuditNickname { get; set; } = string.Empty;

    /// <summary>
    ///  申请时间
    /// </summary>
    public long CreateAt { get; set; }

    /// <summary>
    ///  三方接口
    /// </summary>
    public string PaymentInfoName { get; set; } = string.Empty;
}