using Credit.OrderModels;
using Credit.OrderServices.Dtos;
using Credit.ProductModels;
using Credit.UserModels;
using Credit.UserWalletModels;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.OrderServices.Implements;

/// <summary>
///  理财订单方法实现
/// </summary>
public class FinancilOrderService : IFinancilOrderService
{
    private readonly IFreeSql _freeSql;

    private readonly IUserWalletService _userWalletService;

    /// <summary>
    ///  
    /// </summary>
    public FinancilOrderService(IFreeSql freeSql
    ,IUserWalletService userWalletService)
    {
        _freeSql = freeSql;
        _userWalletService = userWalletService;
    }

    /// <summary>
    ///  理财订单提交
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <exception cref="MyException"></exception>
    public async Task OrderCreate(FinancilOrderInput input,long userId)
    {
        if (input.UnitCount <= 0)
            throw new MyException("Please enter purchase share");
        //理财产品验证
        var product = await _freeSql.Select<FinancialProduct>()
            .Where(s => s.Id == input.ProductId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (product == null)
            throw new MyException("Please select a new product");
        if (product.IsEnable == 0)
            throw new MyException("Product has been discontinued");
        //用户验证
        var user = await _freeSql.Select<Users>()
            .Where(s => s.Id == userId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (user == null)
            throw new MyException("Please login again");
        var amount = product.Price * input.UnitCount;
        if (user.Balance < amount)
            throw new MyException("Insufficient balance");
        //购买份数验证
        if (input.UnitCount < product.BuyMinUnit)
            throw new MyException($"Purchase at least {product.BuyMinUnit} copies");
        var productOrder = await _freeSql.Select<FinancilOrder>()
            .Where(s => s.ProductId == input.ProductId && s.UserId == userId)
            .Where(s => s.IsDeleted == 0 && s.IsFinished == 0
                                         && s.Status != AuditStatusEnums.Default && s.Status != AuditStatusEnums.Ing)
            .ToListAsync();
        var buyUnitCount = productOrder.Sum(s => s.UnitCount);
        if (buyUnitCount + input.UnitCount > product.BuyMaxUnit)
            throw new MyException($"Only {product.BuyMaxUnit - buyUnitCount} copies can be purchased");

        var today = DateTime.UtcNow.Date.ToString("yyyyMMdd");
        var newOrder = new FinancilOrder
        {
            Id = IdHelper.GetId(),
            ProductId = product.Id,
            UserId = userId,
            Price = product.Price,
            DailyRate = product.DailyRate,
            UnitCount = input.UnitCount,
            TotalAmount = amount,
            Cycle = product.Cycle,
            BuyDate = today,
            Status = AuditStatusEnums.Default,
            SettledCount = 0,
            IsFinished = 0,
            NextSettledDate = string.Empty
        };
        _freeSql.Transaction(() =>
        {
            //用户产生订单流水
            _userWalletService.WalletRecordCreate(new UserWalletRecordInput
            {
                UserId = userId,
                SourceType = WalletSourceEnums.BuyFinancil,
                OperateUserId = userId,
                Amount = amount,
                OperateType = WalletOperateEnums.User,
            });
            //创建订单
            _freeSql.Insert(newOrder).ExecuteAffrows();
        });
    }
}