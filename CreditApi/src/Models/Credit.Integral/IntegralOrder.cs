using Data.Commons.Models;

namespace Credit.IntegralModels;

public class IntegralOrder:BaseModel
{
    /// <summary>
    /// 用户id
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// 兑换了多少积分
    /// </summary>
    public decimal Integral { get; set; }
    /// <summary>
    /// 当前兑换了多少余额
    /// </summary>
    public decimal Balance { get; set; }
    /// <summary>
    /// 兑换后总余额
    /// </summary>
    public decimal BalanceCount { get; set; }
    /// <summary>
    /// 兑换率
    /// </summary>
    public decimal RateOfExchange { get; set; }
}

