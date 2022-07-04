using Credit.OrderModels;
using Credit.OrderServices.Dtos;
using Credit.ProductModels;
using Credit.UserModels;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Extensions;
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
    public async Task BuyFinancilProduct(FinancilOrderInput input,long userId)
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
            .Where(s => s.IsDeleted == 0 && s.IsSold == 0
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
            IsSold = 0,
            SoldStatus = null,
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
            //创建订单 表按年分表
            _freeSql.Insert(newOrder).InsertTableTime(TableTimeFormat.Year).ExecuteAffrows();
        });
    }

    /// <summary>
    ///  获取理财订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<FinancilOrderDto> GetOrder(long orderId, long userId = 0)
    {
        var order = await _freeSql.Select<FinancilOrder>()
            .WhereTableTime(TableTimeFormat.Year)
            .WhereIf(userId > 0, s => s.UserId == userId)
            .Where(s => s.Id == orderId)
            .ToOneAsync();
        var output = new FinancilOrderDto();
        if (order != null)
        {
            output = order.MapTo<FinancilOrderDto>();
            var orderUser = await _freeSql.Select<Users>()
                .Where(s => s.Id == order.UserId)
                .ToOneAsync();
            var orderProduct = await _freeSql.Select<FinancialProduct>()
                .Where(s => s.Id == order.ProductId)
                .ToOneAsync();
            output.Username = orderUser?.Username ?? string.Empty;
            output.Nickname = orderUser?.Nickname ?? string.Empty;
            output.ProductName = orderProduct?.ProductName ?? string.Empty;
            output.StatusText = EnumHelper.GetDescription(order.Status);
            if (order.SoldStatus != null)
                output.SoldStatusText = EnumHelper.GetDescription(order.SoldStatus);
        }

        return output;
    }

    /// <summary>
    ///  订单购买审核
    /// </summary>
    /// <param name="input"></param>
    /// <param name="auditUserId"></param>
    public async Task AuditBuyOrder(AuditFinancialOrderInput input, long auditUserId)
    {
        if (input.Status == AuditStatusEnums.Success)
        {
            await BuyAuditSuccess(input.OrderId, input.AuditText, auditUserId);
        }
        else if (input.Status == AuditStatusEnums.Fail)
        {
            await BuyAuditFail(input.OrderId, input.AuditText, auditUserId);
        }
        else if (input.Status == AuditStatusEnums.Ing)
        {
            await BuyAuditIng(input.OrderId, input.AuditText, auditUserId);
        }
        else
        {
            throw new MyException("Review status error");
        }
    }

    /// <summary>
    ///  主键获取理财订单
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    private async Task<FinancilOrder> Get(long orderId)
    {
        return await _freeSql.Select<FinancilOrder>()
            .WhereTableTime(TableTimeFormat.Year)
            .Where(s => s.Id == orderId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
    }

    /// <summary>
    ///  购买审核通过
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task BuyAuditSuccess(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 1)
            throw new MyException("It has been sold");
        if (order.Status == AuditStatusEnums.Fail || order.Status == AuditStatusEnums.Success)
            throw new MyException("Order reviewed");
        //修改订单信息
        order.Status = AuditStatusEnums.Success;
        order.AuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        //修改下次结算时间
        var settleTimeDate = DateTime.UtcNow.AddDays(1).Date.AddDays(order.Cycle).AddDays(-1);
        var nextSettleDate = settleTimeDate.ToString("yyyyMMdd");
        order.NextSettledDate = nextSettleDate;
        await _freeSql.Update<FinancilOrder>()
            .UpdateTableTime(TableTimeFormat.Year,order.CreateAt)
            .SetSource(order)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  购买审核失败
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task BuyAuditFail(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 1)
            throw new MyException("It has been sold");
        if (order.Status == AuditStatusEnums.Fail || order.Status == AuditStatusEnums.Success)
            throw new MyException("Order reviewed");
        if (string.IsNullOrEmpty(auditText))
            throw new MyException("Please enter a reason");
        //修改订单信息
        order.Status = AuditStatusEnums.Fail;
        order.AuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        _freeSql.Transaction(() =>
        {
            //退回用户购买订单流水
            _userWalletService.WalletRecordCreate(new UserWalletRecordInput
            {
                UserId = order.UserId,
                SourceType = WalletSourceEnums.BuyFinancilReturn,
                OperateUserId = auditUserId,
                OperateType = WalletOperateEnums.Admin,
                Amount = order.TotalAmount
            });
            //修改订单审核信息
            _freeSql.Update<FinancilOrder>()
                .UpdateTableTime(TableTimeFormat.Year,order.CreateAt)
                .SetSource(order)
                .ExecuteAffrows();
        });
    }

    /// <summary>
    ///  购买审核中
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task BuyAuditIng(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 1)
            throw new MyException("It has been sold");
        if (order.Status != AuditStatusEnums.Default)
            throw new MyException("Order reviewed");
        //修改订单信息
        order.Status = AuditStatusEnums.Ing;
        order.AuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<FinancilOrder>()
            .UpdateTableTime(TableTimeFormat.Year,order.CreateAt)
            .SetSource(order)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  理财产品出售
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="userId"></param>
    public async Task OrderSold(long orderId, long userId)
    {
        var order = await Get(orderId);
        if (order == null || order.UserId != userId)
            throw new MyException("Order does not exist");
        if (order.IsSold == 1)
            throw new MyException("It has been sold");
        order.IsSold = 1;
        order.UpdateAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<FinancilOrder>()
            .UpdateTableTime(TableTimeFormat.Year,order.CreateAt)
            .SetSource(order)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///   理财产品出售审核
    /// </summary>
    /// <param name="input"></param>
    /// <param name="auditUserId"></param>
    /// <returns></returns>
    public async Task AuditSoldOrder(AuditFinancialOrderInput input, long auditUserId)
    {
        if (input.Status == AuditStatusEnums.Success)
        {
            await SoldSuccess(input.OrderId, input.AuditText, auditUserId);
        }
        else if (input.Status == AuditStatusEnums.Fail)
        {
            await SoldFail(input.OrderId, input.AuditText, auditUserId);
        }
        else if (input.Status == AuditStatusEnums.Ing)
        {
            await SoldIng(input.OrderId, input.AuditText, auditUserId);
        }
        else
        {
            throw new MyException("Review status error");
        }
    }

    /// <summary>
    ///  出售成功
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task SoldSuccess(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 0)
            throw new MyException("Not sold");
        if (order.SoldStatus == AuditStatusEnums.Fail || order.SoldStatus == AuditStatusEnums.Success)
            throw new MyException("Order reviewed");
        order.SoldStatus = AuditStatusEnums.Success;
        order.SoldAuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        _freeSql.Transaction(() =>
        {
            //用户产生出售理财产品流水
            _userWalletService.WalletRecordCreate(new UserWalletRecordInput
            {
                Amount = order.TotalAmount,
                UserId = order.UserId,
                SourceType = WalletSourceEnums.SoldFinancil,
                OperateUserId = auditUserId,
                OperateType = WalletOperateEnums.Admin
            });
            //修改订单信息
            _freeSql.Update<FinancilOrder>()
                .UpdateTableTime(TableTimeFormat.Year,order.CreateAt)
                .SetSource(order)
                .ExecuteAffrows();
        });
    }

    /// <summary>
    ///  出售失败
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task SoldFail(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 0)
            throw new MyException("Not sold");
        if (order.SoldStatus == AuditStatusEnums.Fail || order.SoldStatus == AuditStatusEnums.Success)
            throw new MyException("Order reviewed");
        if (string.IsNullOrEmpty(auditText))
            throw new MyException("Please enter a reason");
        order.SoldStatus = AuditStatusEnums.Fail;
        order.SoldAuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<FinancilOrder>()
            .SetSource(order)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  出售审核中
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="auditText"></param>
    /// <param name="auditUserId"></param>
    private async Task SoldIng(long orderId,string auditText,long auditUserId)
    {
        var order = await Get(orderId);
        if (order == null)
            throw new MyException("Order does not exist");
        if (order.IsSold == 0)
            throw new MyException("Not sold");
        if (order.SoldStatus != AuditStatusEnums.Default)
            throw new MyException("Order reviewed");
       
        order.SoldStatus = AuditStatusEnums.Ing;
        order.SoldAuditText = auditText;
        order.AuditUserId = auditUserId;
        order.AuditAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<FinancilOrder>()
            .SetSource(order)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取理财产品列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<FinancilOrderDto>> GetOrderPagedList(FinancilOrderPagedInput input)
    {
        var list = await _freeSql.Select<FinancilOrder>()
            .WhereTableTime(TableTimeFormat.Year, input.StartTime, input.EndTime)
            .WhereIf(input.UserId.HasValue, s => s.UserId == input.UserId)
            .WhereIf(!string.IsNullOrEmpty(input.UserKey),
                s => _freeSql.Select<Users>()
                    .Where(u => u.Username.Contains(input.UserKey) || u.Nickname.Contains(input.UserKey))
                    .ToList(u => u.Id).Contains(s.UserId))
            .WhereIf(input.Status.HasValue, s => s.Status == input.Status)
            .WhereIf(input.SoldStatus.HasValue, s => s.SoldStatus == input.SoldStatus)
            .WhereIf(input.IsSold.HasValue, s => s.IsSold == input.IsSold)
            .WhereIf(input.ProductId.HasValue, s => s.ProductId == input.ProductId)
            .WhereIf(!string.IsNullOrEmpty(input.ProductKey), s =>
                _freeSql.Select<FinancialProduct>().Where(p => p.ProductName.Contains(input.ProductKey))
                    .ToList(p => p.Id).Contains(s.ProductId))
            .Where(s => s.IsDeleted == 0)
            .OrderByDescending(s => s.CreateAt)
            .Count(out long totalCount)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var items = list.MapToList<FinancilOrderDto>();
        var userIds = list.Select(s => s.UserId).Distinct();
        var productIds = list.Select(s => s.ProductId).Distinct();
        var usersTask = _freeSql.Select<Users>().Where(s => userIds.Contains(s.Id)).ToListAsync();
        var productTask = _freeSql.Select<FinancialProduct>().Where(s => productIds.Contains(s.Id)).ToListAsync();
        var users = await usersTask;
        var products = await productTask;
        items.ForEach(item =>
        {
            var itemUser = users.FirstOrDefault(s => s.Id == item.UserId);
            var itemProduct = products.FirstOrDefault(s => s.Id == item.ProductId);
            item.Username = itemUser?.Username ?? string.Empty;
            item.Nickname = itemUser?.Nickname ?? string.Empty;
            item.ProductName = itemProduct?.ProductName ?? string.Empty;
            item.StatusText = EnumHelper.GetDescription(item.Status);
            if (item.SoldStatus.HasValue)
                item.SoldStatusText = EnumHelper.GetDescription(item.SoldStatus);
        });
        var output = new PagedOutput<FinancilOrderDto>
        {
            TotalCount = totalCount,
            Items = items
        };
        return output;
    }

    /// <summary>
    ///  结算理财订单
    /// </summary>
    public async Task SettleOrders()
    {
        var utcNowDate = DateTime.UtcNow.ToString("yyyyMMdd");
        //获取所有需要结算的订单信息
        var orders = await _freeSql.Select<FinancilOrder>()
            .Where(s => s.NextSettledDate == utcNowDate)
            .Where(s => s.IsDeleted == 0 && s.IsSold == 0)
            .ToListAsync();
        foreach (var order in orders)
        {
            //计算订单下次结算时间和结算次数
            var nextSettledDate = DateTime.UtcNow.AddDays(order.Cycle).ToString("yyyyMMdd");
            var settledCount = order.SettledCount + 1;
            var amount = order.TotalAmount * order.DailyRate * 0.01m * order.Cycle;
            try
            {
                _freeSql.Transaction(() =>
                {
                    //更新订单结算信息
                    _freeSql.Update<FinancilOrder>(order.Id)
                        .SetDto(new {NextSettledDate = nextSettledDate, SettledCount = settledCount})
                        .ExecuteAffrows();
                    //增加用户理财收益流水
                    _userWalletService.WalletRecordCreate(new UserWalletRecordInput
                    {
                        UserId = order.UserId,
                        Amount = amount,
                        SourceType = WalletSourceEnums.FinancilProfit,
                        OperateType = WalletOperateEnums.Sytem,
                        OperateUserId = 0
                    });
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
        }
    }
}