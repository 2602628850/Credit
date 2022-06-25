using Credit.OrderServices.Dtos;

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
    Task OrderCreate(FinancilOrderInput input,long userId);
}