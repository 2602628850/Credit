namespace Credit.IntegralServices.Dtos;
public class IntegralOrderDto : IntegralOrderParent
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
public class IntegralOrderParent
{
    /// <summary>
    ///  删除 0 未删除  1 已删除
    /// </summary>
    public int IsDeleted { get; set; } = 0;
    /// <summary>
    ///  创建时间
    /// </summary>
    public long CreateAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    /// <summary>
    /// 转换后的时间
    /// </summary>
    public string Todate { get; set; }

}

