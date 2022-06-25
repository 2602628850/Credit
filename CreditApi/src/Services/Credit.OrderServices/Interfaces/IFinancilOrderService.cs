using Credit.OrderServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.OrderServices;

/// <summary>
///  理财订单方法定义
/// </summary>
public interface IFinancilOrderService
{
    /// <summary>
    ///  理财订单提交
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task BuyFinancilProduct(FinancilOrderInput input,long userId);

    /// <summary>
    ///  获取理财订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<FinancilOrderDto> GetOrder(long orderId,long userId = 0);

    /// <summary>
    ///  审核理财订单
    /// </summary>
    /// <param name="input"></param>
    /// <param name="auditUserId"></param>
    /// <returns></returns>
    Task AuditBuyOrder(AuditFinancialOrderInput input,long auditUserId);

    /// <summary>
    ///  售出理财订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task OrderSold(long orderId,long userId);

    /// <summary>
    ///  售出理财订单审核
    /// </summary>
    /// <param name="input"></param>
    /// <param name="auditUserId"></param>
    /// <returns></returns>
    Task AuditSoldOrder(AuditFinancialOrderInput input,long auditUserId);
    
    /// <summary>
    ///  获取理财订单列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<FinancilOrderDto>> GetOrderPagedList(FinancilOrderPagedInput input);
}