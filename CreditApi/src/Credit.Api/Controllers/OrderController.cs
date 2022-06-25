using Credit.OrderServices;
using Credit.OrderServices.Dtos;
using Credit.ProductServices;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  订单管理接口
/// </summary>
public class OrderController : BaseUserController
{
    private readonly IFinancilOrderService _financilOrderService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="financilOrderService"></param>
    public OrderController(ITokenManager tokenManager
    ,IFinancilOrderService financilOrderService) : base(tokenManager)
    {
        _financilOrderService = financilOrderService;
    }

    /// <summary>
    ///  购买理财
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task BuyFinancilProduct([FromBody]FinancilOrderInput input)
    {
        await _financilOrderService.BuyFinancilProduct(input, CurrentUser.UserId);
    }

    /// <summary>
    ///  出售理财
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task SoldFinancilProduct([FromBody]IdInput input)
    {
        await _financilOrderService.OrderSold(input.Id, CurrentUser.UserId);
    }
    
    /// <summary>
    ///  获取订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<FinancilOrderDto> GetOrder([FromQuery]long orderId)
    {
        return await _financilOrderService.GetOrder(orderId,CurrentUser.UserId);
    }

    /// <summary>
    ///  获取用户理财订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<FinancilOrderDto>> GetOrderPagedList([FromQuery]FinancilOrderPagedInput input)
    {
        input.UserId = CurrentUser.UserId;
        return await _financilOrderService.GetOrderPagedList(input);
    }
}