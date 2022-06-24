using Credit.ProductModels;
using Credit.ProductServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.ProductServices;

/// <summary>
///  理财产品方法实现
/// </summary>
public class FinancialProductService : IFinancialProductService
{
    private readonly IFreeSql _freeSql;

    public FinancialProductService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  理财产品基础信息验证
    /// </summary>
    /// <param name="input"></param>
    private void ProductVerify(FinancialProductInput input)
    {
        if (string.IsNullOrEmpty(input.ProductName))
            throw new MyException("Please input the product name");
        if (string.IsNullOrEmpty(input.ProductIntroduction))
            throw new MyException("Please input the product introduction");
        if (input.DailyRate <= 0)
            throw new MyException("Product revenue ratio must be greater than 0");
        if (input.Cycle <= 0)
            throw new MyException("Product revenue cycle must be greater than 0");
        if (input.Price <= 0)
            throw new MyException("Product unit price must be greater than 0");
        if (input.BuyMinUnit <= 0)
            throw new MyException("The minimum number of purchases of the product must be greater than 0");
        if (input.BuyMaxUnit < input.BuyMinUnit)
            throw new MyException("The maximum number of purchases of the product must be greater than the minimum number of purchases");
    }

    /// <summary>
    ///  理财产品添加
    /// </summary>
    /// <param name="input"></param>
    public async Task ProductCreate(FinancialProductInput input)
    {
        //产品信息验证
        ProductVerify(input);
        var product = input.MapTo<FinancialProduct>();
        product.Id = IdHelper.GetId();
        await _freeSql.Insert(product).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  理财产品编辑
    /// </summary>
    /// <param name="input"></param>
    public async Task ProductUpdate(FinancialProductInput input)
    {
        //产品信息验证
        ProductVerify(input);
        var product = await _freeSql.Select<FinancialProduct>()
            .Where(s => s.Id == input.Id)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (product == null)
            throw new MyException("Edit information does not exist");
        product.ProductName = input.ProductName;
        product.CoverImage = input.CoverImage;
        product.ProductIntroduction = input.ProductIntroduction;
        product.DailyRate = input.DailyRate;
        product.Cycle = input.Cycle;
        product.BuyMinUnit = input.BuyMinUnit;
        product.BuyMaxUnit = input.BuyMaxUnit;
        product.IsEnable = input.IsEnable;
        product.UpdateAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<FinancialProduct>(product.Id)
            .SetSource(product)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  理财产品删除
    /// </summary>
    /// <param name="productIds"></param>
    /// <param name="deleteUserId"></param>
    public async Task ProductDelete(List<long> productIds, long deleteUserId)
    {
        var products = await _freeSql.Select<FinancialProduct>()
            .Where(s => productIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var uctNow = DateTimeHelper.UtcNow();
        products.ForEach(item =>
        {
            item.UpdateAt = uctNow;
            item.IsDeleted = 1;
            item.DeleteUserId = deleteUserId;
        });
        await _freeSql.Update<FinancialProduct>()
            .SetSource(products)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  理财产品上架
    /// </summary>
    /// <param name="productIds"></param>
    public async Task ProductTakeOn(List<long> productIds)
    {
        var products = await _freeSql.Select<FinancialProduct>()
            .Where(s => productIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var uctNow = DateTimeHelper.UtcNow();
        products.ForEach(item =>
        {
            item.UpdateAt = uctNow;
            item.IsEnable = 1;
        });
        await _freeSql.Update<FinancialProduct>()
            .SetSource(products)
            .ExecuteAffrowsAsync();
    }
    /// <summary>
    ///  产品下架
    /// </summary>
    /// <param name="productIds"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task ProductTakeDown(List<long> productIds)
    {
        var products = await _freeSql.Select<FinancialProduct>()
            .Where(s => productIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var uctNow = DateTimeHelper.UtcNow();
        products.ForEach(item =>
        {
            item.UpdateAt = uctNow;
            item.IsEnable = 0;
        });
        await _freeSql.Update<FinancialProduct>()
            .SetSource(products)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取理财产品信息
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<FinancialProductDto> GetFinancialProduct(long productId)
    {
        var product = await _freeSql.Select<FinancialProduct>()
            .Where(s => s.Id == productId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();

        return product.MapTo<FinancialProductDto>();
    }

    /// <summary>
    ///   获取理财产品列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<FinancialProductDto>> GetProductPagedList(FinancialProductPagedInput input)
    {
        var list = await _freeSql.Select<FinancialProduct>()
            .WhereIf(input.IsEnable.HasValue, s => s.IsEnable == input.IsEnable)
            .WhereIf(!string.IsNullOrEmpty(input.ProductName), s => s.ProductName.Contains(input.ProductName))
            .Where(s => s.IsDeleted == 0)
            .Count(out long totalCount)
            .OrderByDescending(s => s.Sort)
            .OrderByDescending(s => s.UpdateAt)
            .Page(input.PageSize, input.PageIndex)
            .ToListAsync();
        var output = new PagedOutput<FinancialProductDto>()
        {
            TotalCount = totalCount,
            Items = list.MapToList<FinancialProductDto>()
        };
        return output;
    }
}