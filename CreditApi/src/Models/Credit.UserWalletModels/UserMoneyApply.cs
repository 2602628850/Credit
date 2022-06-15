using System.Security.Cryptography;
using Data.Commons.Enums;
using Data.Commons.Models;

namespace Credit.UserWalletModels;

/// <summary>
///  用户资金申请
/// </summary>
public class UserMoneyApply : BaseModel
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
    ///  变动类型
    /// </summary>
    public WalletChangeEnums ChangeType { get; set; }

    /// <summary>
    ///   变动来源
    /// </summary>
    public WalletSourceEnums SourceType { get; set; }

    /// <summary>
    ///   审核状态
    /// </summary>
    public AuditStatusEnums AuditStatus { get; set; }
    
    /// <summary>
    ///   三方接口Id
    /// </summary>
    public long PaymentInfoId { get; set; }

    /// <summary>
    ///  收款银行卡Id
    /// </summary>
    public long PayeeBankCardId { get; set; }

    /// <summary>
    ///   支付信息
    /// </summary>
    public string PayText { get; set; } = string.Empty;

    /// <summary>
    ///   备注
    /// </summary>
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    ///  审核信息
    /// </summary>
    public string AuditText { get; set; } = string.Empty;

    /// <summary>
    ///  审核人员Id
    /// </summary>
    public long AuditUserId { get; set; }

    /// <summary>
    ///  审核时间
    /// </summary>
    public long AuditAt { get; set; }
}