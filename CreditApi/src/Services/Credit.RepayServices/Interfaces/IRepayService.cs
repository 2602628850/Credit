using Credit.RepayServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.RepayServices;

/// <summary>
///  还款管理方法定义
/// </summary>
public interface IRepayService
{
    /// <summary>
    ///  还款等级添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayLevelCreate(RepayLevelInput input);

    /// <summary>
    ///  还款等级更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayLevelUpdate(RepayLevelInput input);

    /// <summary>
    ///  还款等级删除
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task RepayLevelDelete(List<long> repayLevelIds,long deleteUserId);

    /// <summary>
    ///  还款等级启用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    Task RepayLevelEnable(List<long> repayLevelIds);

    /// <summary>
    ///  还款等级禁用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    Task RepayLevelDisable(List<long> repayLevelIds);

    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    Task<RepayLevelDto> GetRepayLevel(long repayLevelId);

    /// <summary>
    ///  获取还款等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<RepayLevelDto>> GetRepayLevelPagedList(RepayLevelPagedInput input);
}