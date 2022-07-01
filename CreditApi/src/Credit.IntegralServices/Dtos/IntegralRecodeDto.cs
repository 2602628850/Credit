namespace Credit.IntegralServices.Dtos;


    public class IntegralRecodeDto: IntegralRecodeParent
{
    /// <summary>
    /// 用户id
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// 产品类型(0:完成查卡,1完成贷还,2邀请好友)
    /// </summary>
    public int ProductType { get; set; }
    //获得积分
    public decimal Integral { get; set; }
}
public class IntegralRecodeParent
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

