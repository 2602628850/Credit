using System.ComponentModel;

namespace Data.Commons.Enums;

/// <summary>
///  资金钱包变动枚举
///  0 充值
///  100 提款
/// </summary>
public enum WalletSourceEnums
{
    /// <summary>
    ///  充值
    /// </summary>
    [Description("充值")]
    Recharge = 0,
    
    /// <summary>
    ///  充值申请
    /// </summary>
    [Description("充值申请")]
    RechargeApply = 10,
    
    /// <summary>
    ///  提款
    /// </summary>
    [Description("提款")]
    Withdrawal = 100,
    /// <summary>
    ///  提款退回
    /// </summary>
    [Description("提款退回")]
    WithdrawalReturn = 110,
    
    /// <summary>
    ///  提款申请
    /// </summary>
    [Description("提款申请")]
    WithdrawalApply = 120,
}

/// <summary>
///  钱包资金变动类型
///  0 入账
///  10 支出
/// </summary>
public enum WalletChangeEnums
{
    /// <summary>
    ///  入账
    /// </summary>
    [Description("入账")] 
    In = 0,
     
    /// <summary>
    ///  支出
    /// </summary>
    [Description("支出")]  
    Out = 10,
}

/// <summary>
///  资金变动操作类型
/// </summary>
public enum WalletOperateEnums
{
    /// <summary>
    ///  系统
    /// </summary>
    [Description("系统")]
    Sytem = 0,
    
    /// <summary>
    ///  管理员
    /// </summary>
    [Description("管理员")]
    Admin = 10,
    
    /// <summary>
    ///  用户
    /// </summary>
    [Description("用户")]
    User = 20
}