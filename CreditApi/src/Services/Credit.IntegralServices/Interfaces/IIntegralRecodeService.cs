using Credit.IntegralServices.Dtos;

namespace Credit.IntegralServices;
public interface IIntegralRecodeService
{
    /// <summary>
    ///  获取用户积记录列表
    /// </summary>
    /// <returns></returns>
    Task<List<IntegralRecodeDto>> GentntegralRecodeList(long userid);
}

