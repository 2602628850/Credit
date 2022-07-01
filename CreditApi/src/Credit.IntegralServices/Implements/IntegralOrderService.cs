using Credit.IntegralModels;
using Credit.IntegralServices.Dtos;
using Data.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.IntegralServices.Implements;

public class IntegralOrderService : IIntegralOrderService
{
    private readonly IFreeSql _freeSql;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    public IntegralOrderService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  获取积分订单
    /// </summary>
    /// <returns></returns>
    public async Task<List<IntegralOrderDto>> GentIntegralOrderList(long userid)
    {
        var list = await _freeSql.Select<IntegralOrder>()
            .Where(s => s.IsDeleted == 0).
            Where(s=>s.UserId==userid)
            .ToListAsync(s => new IntegralOrderDto
            {
                UserId = s.UserId,
                Integral = s.Integral,
                Balance = s.Balance,
                BalanceCount = s.BalanceCount,
                CreateAt = s.CreateAt,
                RateOfExchange=s.RateOfExchange
            });
        if (list.Count > 0)
        {
            list.ForEach(m => m.Todate = DateTimeHelper.UnixTimeToDateTime(m.CreateAt).ToString("yyyy-MM-dd HH:mm")
            );
        }
        return list;
    }
}
