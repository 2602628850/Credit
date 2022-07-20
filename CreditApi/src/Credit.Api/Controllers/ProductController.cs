using Credit.ProductServices;
using Credit.ProductServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

public class ProductController : BaseUserController
{
    private readonly IFinancilProductService _financialProductService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="financialProductService"></param>
    public ProductController(ITokenManager tokenManager
        ,IFinancilProductService financialProductService) : base(tokenManager)
    {
        _financialProductService = financialProductService;
    }
    
    /// <summary>
    ///  获取理财产品
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<FinancilProductDto> GetFinancialProduct([FromQuery]FinancilProductDto product)
    {
        return await _financialProductService.GetFinancialProduct(product.Id);
    }

    /// <summary>
    ///  获取理财产品列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<FinancilProductDto>> GetProductPagedList([FromQuery]FinancilProductPagedInput input)
    {
        input.IsEnable = 1;
        return await _financialProductService.GetProductPagedList(input);
    }
}