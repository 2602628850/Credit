
using Data.Commons.Models;
namespace Credit.IntegralModels;
public class IntegralRecode : BaseModel
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

