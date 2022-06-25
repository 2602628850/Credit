using Credit.ProductServices;
using Credit.ProductServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  管理员产品管理
/// </summary>
public class AdminProductController : BaseAdminController
{
    private readonly IFinancilProductService _financialProductService;

    /// <summary>
    /// 
    /// </summary>
    public AdminProductController(ITokenManager tokenManager
            ,IFinancilProductService financialProductService) : base(tokenManager)
    {
        _financialProductService = financialProductService;
    }

    /// <summary>
    ///  理财产品添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinanacialProductCreate([FromBody]FinancilProductInput input)
    {
        await _financialProductService.ProductCreate(input);
    }
    
    /// <summary>
    ///  理财产品编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinanacialProductUpdate([FromBody]FinancilProductInput input)
    {
        await _financialProductService.ProductUpdate(input);
    }

    /// <summary>
    ///  理财产品删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinancialProductDelete([FromBody]ListIdInput input)
    {
        await _financialProductService.ProductDelete(input.Ids, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  理财产品上架
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinancialProductTakeOn([FromBody]ListIdInput input)
    {
        await _financialProductService.ProductTakeOn(input.Ids);
    }

    /// <summary>
    ///  理财产品下架
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task FinancialProductTakeDown([FromBody]ListIdInput input)
    {
        await _financialProductService.ProductTakeDown(input.Ids);
    }

    /// <summary>
    ///  获取理财产品
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<FinancilProductDto> GetFinancialProduct([FromQuery]long productId)
    {
        return await _financialProductService.GetFinancialProduct(productId);
    }

    /// <summary>
    ///  获取理财产品列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<FinancilProductDto>> GetProductPagedList([FromQuery]FinancilProductPagedInput input)
    {
        return await _financialProductService.GetProductPagedList(input);
    }
}