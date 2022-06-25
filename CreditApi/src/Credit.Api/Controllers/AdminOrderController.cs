using Credit.BankServices;
using Credit.OrderServices;
using Credit.OrderServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  管理员订单管理
/// </summary>
public class AdminOrderController : BaseAdminController
{
    private readonly  IFinancilOrderService _financilOrderService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="financilOrderService"></param>
    public AdminOrderController(ITokenManager tokenManager,
        IFinancilOrderService financilOrderService) : base(tokenManager)
    {
        _financilOrderService = financilOrderService;
    }

    /// <summary>
    ///  获取理财订单列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<FinancilOrderDto>> GetOrderPagedList([FromQuery]FinancilOrderPagedInput input)
    {
        return await _financilOrderService.GetOrderPagedList(input);
    }

    /// <summary>
    ///  审核购买订单
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task AuditBuyOrder([FromBody]AuditFinancialOrderInput input)
    {
        await _financilOrderService.AuditBuyOrder(input,CurrentAdmin.UserId);
    }

    /// <summary>
    ///  审核售出订单
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task AuditSoldOrder([FromBody]AuditFinancialOrderInput input)
    {
        await _financilOrderService.AuditSoldOrder(input, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<FinancilOrderDto> GetOrder([FromQuery]long orderId)
    {
        return await _financilOrderService.GetOrder(orderId);
    }
}