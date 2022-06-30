using Credit.RepayModels;
using Credit.RepayServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.RepayServices;

/// <summary>
///  还款管理方法实现
/// </summary>
public class RepayService : IRepayService
{
    private readonly IFreeSql _freeSql;

    public RepayService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  还款等级信息验证
    /// </summary>
    /// <param name="input"></param>
    private void RepayLevelVerify(RepayLevelInput input)
    {
        if (string.IsNullOrEmpty(input.LevelName))
            throw new MyException("Please enter a name");
        if (input.UnlockBalance < 0)
            throw new MyException("Unlock balance must be greater than or equal to 0");
        if (input.ProfitRate < 0)
            throw new MyException("Profit ratio must be greater than or equal to 0");
        if (input.MinRepayAmount <= 0)
            throw new MyException("Minimum repayment amount must be greater than 0");
        if (input.MaxRepayAmount <= input.MinRepayAmount)
            throw new MyException("The maximum repayment amount must be greater than the minimum repayment amount");
        if (string.IsNullOrEmpty(input.Introduction))
            throw new MyException("Please enter an introduction");
    }

    /// <summary>
    ///  还款等级添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task RepayLevelCreate(RepayLevelInput input)
    {
        RepayLevelVerify(input);
        var level = input.MapTo<RepayLevel>();
        level.Id = IdHelper.GetId();
        await _freeSql.Insert(level).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级编辑
    /// </summary>
    /// <param name="input"></param>
    public async Task RepayLevelUpdate(RepayLevelInput input)
    {
        RepayLevelVerify(input);
        var level = await _freeSql.Select<RepayLevel>()
            .Where(s => s.Id == input.Id)
            .ToOneAsync();
        if (level == null)
            throw new MyException("No data found");
        level.LevelName = input.LevelName;
        level.UnlockBalance = input.UnlockBalance;
        level.Introduction = input.Introduction;
        level.MinRepayAmount = input.MinRepayAmount;
        level.CoverImage = input.CoverImage;
        level.MaxRepayAmount = input.MaxRepayAmount;
        level.ProfitRate = input.ProfitRate;
        level.IsEnable = input.IsEnable;
        level.UpdateAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<RepayLevel>().SetSource(level).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级删除
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    public async Task RepayLevelDelete(List<long> repayLevelIds, long deleteUserId)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsDeleted = 1;
            item.DeleteUserId = deleteUserId;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级启用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    public async Task RepayLevelEnable(List<long> repayLevelIds)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsEnable = 1;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级禁用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    public async Task RepayLevelDisable(List<long> repayLevelIds)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsEnable = 0;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    public async Task<RepayLevelDto> GetRepayLevel(long repayLevelId)
    {
        var level = await _freeSql.Select<RepayLevel>()
            .Where(s => s.Id == repayLevelId)
            .ToOneAsync();
        return level.MapTo<RepayLevelDto>();
    }

    /// <summary>
    ///   获取还款等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<RepayLevelDto>> GetRepayLevelPagedList(RepayLevelPagedInput input)
    {
        var list = await _freeSql.Select<RepayLevel>()
            .WhereIf(!string.IsNullOrEmpty(input.LevelName), s => s.LevelName.Contains(input.LevelName))
            .Where(s => s.IsDeleted == 0)
            .Count(out long totalCount)
            .OrderByDescending(s => s.CreateAt)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<RepayLevelDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<RepayLevelDto>()
        };

        return output;
    }
}