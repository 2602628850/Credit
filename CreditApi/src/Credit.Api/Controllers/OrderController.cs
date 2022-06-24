using Credit.OrderServices;
using Credit.OrderServices.Dtos;
using Credit.ProductServices;
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
    ///  理财订单提交
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinancilOrderSubmit([FromBody]FinancilOrderInput input)
    {
        await _financilOrderService.OrderCreate(input, CurrentUser.UserId);
    }
}