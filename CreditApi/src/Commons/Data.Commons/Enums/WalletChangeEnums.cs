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
    ///  提款
    /// </summary>
    [Description("充值")]
    Withdrawal = 100,
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