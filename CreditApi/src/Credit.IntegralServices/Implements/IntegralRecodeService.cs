using Credit.IntegralModels;
using Credit.IntegralServices.Dtos;
using Data.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.IntegralServices.Implements;

public class IntegralRecodeService: IIntegralRecodeService
{
    private readonly IFreeSql _freeSql;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    public IntegralRecodeService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  获取积分记录
    /// </summary>
    /// <returns></returns>
    public async Task<List<IntegralRecodeDto>> GentntegralRecodeList(long userid)
    {
        var list = await  _freeSql.Select<IntegralRecode>()
            .Where(s => s.IsDeleted == 0).
            Where(s => s.UserId == userid)
            .ToListAsync(s => new IntegralRecodeDto
            {
                UserId = s.UserId,
                ProductType = s.ProductType,
                Integral = s.Integral,
                CreateAt = s.CreateAt


            });
        if (list.Count > 0)
        {
            list.ForEach(m => m.Todate = DateTimeHelper.UnixTimeToDateTime(m.CreateAt).ToString("yyyy-MM-dd HH:mm")
            );
        }
        return list;
    }
}
