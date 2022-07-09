using Credit.CreditLevelModels;
using Credit.CreditLevelServices.Dtos;
using Credit.CreditLevelServices.Interfaces;
using Credit.UserModels;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.CreditLevelServices;


public class CreditLevelService : ICreditLevelService
{
    private readonly IFreeSql _freeSql;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    /// <param name="userService"></param>
    /// <param name="userWalletService"></param>
    public CreditLevelService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }
    #region 信用等级
    /// <summary>
    ///  信用等级信息验证
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="MyException"></exception>
    private void CreditLevelVerify(CreditLevelInput input)
    {
        if (string.IsNullOrEmpty(input.LevelName))
            throw new MyException("Please enter a class name");
        if (input.CreditValue == 0)
            throw new MyException("Please enter the number of creditvalue");
        if (input.ChakaNum < 0 )
            throw new MyException("Please input the card checking times correctly");
        if (input.Profit < 0 || input.Profit >= 100)
            throw new MyException("Please input the income proportion correctly");

    }
    /// <summary>
    /// 添加信用等级
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task CreditLevelCreate(CreditLevelInput input)
    {
        CreditLevelVerify(input); 

        var creditLevel = input.MapTo<CreditLevel>();
        creditLevel.Id = IdHelper.GetId();

        await _freeSql.Insert(creditLevel).ExecuteAffrowsAsync();
    }

    /// <summary>
    /// 信用等级修改
    /// </summary>
    /// <param name="input"></param>
    public async Task CreditLevelUpdate(CreditLevelInput input)
    {
        CreditLevelVerify(input);
        var creditLevel = await _freeSql.Select<CreditLevel>()
            .Where(s => s.Id == input.Id)
            .ToOneAsync();
        if (creditLevel == null)
            throw new MyException("Data error");
        creditLevel.LevelName = input.LevelName;
        creditLevel.ChakaNum = input.ChakaNum;
        creditLevel.Profit = input.Profit;
        creditLevel.UpdateAt = DateTimeHelper.UtcNow();
        creditLevel.LevelSort = input.LevelSort;
        creditLevel.CreditValue = input.CreditValue;

        await _freeSql.Update<CreditLevel>(creditLevel.Id)
            .SetSource(creditLevel)
            .ExecuteAffrowsAsync();
    }


    /// <summary>
    ///  信用等级删除
    /// </summary>
    /// <param name="levelId"></param>
    /// <param name="deleteUserId"></param>
    public async Task CreditLevelDelete(long levelId, long deleteUserId)
    {
        var CreditLevel = await _freeSql.Select<CreditLevel>()
            .Where(s => s.IsDeleted == 0)
            .Where(s => s.Id == levelId)
            .ToOneAsync();
        if (CreditLevel == null)
            throw new MyException("Data error");

        var userCount = await _freeSql.Select<Users>()
            .Where(s => s.Level == levelId)
            .Where(s => s.IsDeleted == 0)
            .CountAsync();
        if (userCount > 0)
            throw new MyException("Please contact customer service");
        CreditLevel.IsDeleted = 1;
        CreditLevel.DeleteUserId = deleteUserId;
        await _freeSql.Update<CreditLevel>(CreditLevel.Id)
            .SetSource(CreditLevel)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取信用等级
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    public async Task<CreditLevelDto> GetCreditLevel(long levelId)
    {
        var CreditLevel = await _freeSql.Select<CreditLevel>()
            .Where(s => s.Id == levelId)
            .ToOneAsync();
        return CreditLevel.MapTo<CreditLevelDto>();
    }

    /// <summary>
    ///  获取所有信用等级
    /// </summary>
    /// <returns></returns>
    public async Task<List<CreditLevelDto>> GetAllCreditLevels()
    {
        var CreditLevels = await _freeSql.Select<CreditLevel>()
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        return CreditLevels.MapToList<CreditLevelDto>();
    }

    /// <summary>
    ///  获取信用等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<CreditLevelDto>> GetCreditLevelPagedList(CreditLevelPagedInput input)
    {
        var list = await _freeSql.Select<CreditLevel>()
            .WhereIf(!string.IsNullOrEmpty(input.LevelName), s => s.LevelName.Contains(input.LevelName))
            .Where(s => s.IsDeleted == 0)
            .OrderBy(s => s.LevelSort)
            .Count(out long totalCount)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<CreditLevelDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<CreditLevelDto>()
        };

        return output;
    }
     


    #endregion
}
