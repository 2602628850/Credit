namespace Credit.RepayServices.Dtos;

/// <summary>
///  还款银行卡DTO
/// </summary>
public class RepayBankCardDto : RepayBankCardInput
{
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  还款等级名称
    /// </summary>
    public string LevelName { get; set; } = string.Empty;

    /// <summary>
    ///  添加时间
    /// </summary>
    public long CreateAt { get; set; }
}
public class LeavesInput
{
    public long Leaveid { get; set; } = 0;
}
/// <summary>
///  还款银行卡输入
/// </summary>
public class RepayBankCardInput
{
    /// <summary>
    ///  还款银行卡Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  还款等级Id
    /// </summary>
    public long RepayLevelId { get; set; }

    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }

    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  绑定用户
    /// </summary>
    public string BindUser { get; set; } = string.Empty;

    /// <summary>
    ///  还款金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///  启用/停用
    /// </summary>
    public int IsEnable { get; set; }
}