namespace Credit.UserWalletServices.Dtos;

/// <summary>
///  申请未处理数量统计
/// </summary>
public class ApplyDefaultCountDto
{
    /// <summary>
    ///  充值数量
    /// </summary>
    public int RechargeCount { get; set; }

    /// <summary>
    ///  提款数量
    /// </summary>
    public int WithdrawalCount { get; set; }

    /// <summary>
    ///  信用卡代还数量
    /// </summary>
    public int CardRepayCount { get; set; }

    /// <summary>
    ///  贷款代还数量
    /// </summary>
    public int LoanRepayCount { get; set; }
}