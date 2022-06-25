using Credit.ProductServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.ProductServices;

/// <summary>
///  理财产品方法定义
/// </summary>
public interface IFinancilProductService
{
    /// <summary>
    ///  理财产品添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task ProductCreate(FinancialProductInput input);

    /// <summary>
    ///  理财产品更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task ProductUpdate(FinancialProductInput input);

    /// <summary>
    ///  理财产品批量删除
    /// </summary>
    /// <param name="productIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task ProductDelete(List<long> productIds,long deleteUserId);

    /// <summary>
    ///  理财产品上架
    /// </summary>
    /// <param name="productIds"></param>
    /// <returns></returns>
    Task ProductTakeOn(List<long> productIds);

    /// <summary>
    ///  理财产品下架
    /// </summary>
    /// <param name="productIds"></param>
    /// <returns></returns>
    Task ProductTakeDown(List<long> productIds);

    /// <summary>
    ///  Id获取理财产品信息
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<FinancialProductDto> GetFinancialProduct(long productId);

    /// <summary>
    ///   获取理财产品分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<FinancialProductDto>> GetProductPagedList(FinancialProductPagedInput input);
}