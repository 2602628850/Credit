using Credit.IntegralServices.Dtos;

namespace Credit.IntegralServices;


public interface IIntegralOrderService
{
    /// <summary>
    ///  获取用户积分订单列表
    /// </summary>
    /// <returns></returns>
    Task<List<IntegralOrderDto>> GentIntegralOrderList(long userid);
}

