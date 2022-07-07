using Credit.TeamModels;
using Credit.TeamServices.Dtos;
using Credit.UserModels;
using Credit.UserServices;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.TeamServices;

/// <summary>
///  团队方法实现
/// </summary>
public class TeamService : ITeamService
{
    private readonly IFreeSql _freeSql;

    private readonly IUserService _userService;
    private readonly IUserWalletService _userWalletService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    /// <param name="userService"></param>
    /// <param name="userWalletService"></param>
    public TeamService(IFreeSql freeSql
    ,IUserService userService
    ,IUserWalletService userWalletService)
    {
        _freeSql = freeSql;
        _userService = userService;
        _userWalletService = userWalletService;
    }

    #region 团队等级

    /// <summary>
    ///  团队等级信息验证
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="MyException"></exception>
    private void TeamLevelVerify(TeamLevelInput input)
    {
        if (string.IsNullOrEmpty(input.LevelName))
            throw new MyException("Please enter a class name");
        if (input.InviteCount == 0)
            throw new MyException("Please enter the number of invitees");
        if (input.TeamBuyRate < 0 || input.TeamBuyRate >= 100)
            throw new MyException("Please enter the team purchase profit sharing ratio correctly");
        if (input.TeamRepayRate < 0 || input.TeamRepayRate >= 100)
            throw new MyException("Please enter the team repayment and profit sharing ratio correctly");

    }

    /// <summary>
    ///  团队等级添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task TeamLevelCreate(TeamLevelInput input)
    {
        TeamLevelVerify(input);

        var teamLevel = input.MapTo<TeamLevel>();
        teamLevel.Id = IdHelper.GetId();

        await _freeSql.Insert(teamLevel).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  团队等级修改
    /// </summary>
    /// <param name="input"></param>
    public async Task TeamLevelUpdate(TeamLevelInput input)
    {
        TeamLevelVerify(input);
        var teamLevel = await _freeSql.Select<TeamLevel>()
            .Where(s => s.Id == input.Id)
            .ToOneAsync();
        if (teamLevel == null)
            throw new MyException("Data error");
        teamLevel.LevelName = input.LevelName;
        teamLevel.TeamBuyRate = input.TeamBuyRate;
        teamLevel.TeamRepayRate = input.TeamRepayRate;
        teamLevel.UpdateAt = DateTimeHelper.UtcNow();
        teamLevel.LevelSort = input.LevelSort;
        teamLevel.InviteCount = input.InviteCount;
        
        await _freeSql.Update<TeamLevel>(teamLevel.Id)
            .SetSource(teamLevel)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  团队等级删除
    /// </summary>
    /// <param name="levelId"></param>
    /// <param name="deleteUserId"></param>
    public async Task TeamLevelDelete(long levelId, long deleteUserId)
    {
        var teamLevel = await _freeSql.Select<TeamLevel>()
            .Where(s => s.IsDeleted == 0)
            .Where(s => s.Id == levelId)
            .ToOneAsync();
        if (teamLevel == null)
            throw new MyException("Data error");

        var userCount = await _freeSql.Select<Users>()
            .Where(s => s.TeamLevel == levelId)
            .Where(s => s.IsDeleted == 0)
            .CountAsync();
        if (userCount > 0)
            throw new MyException("Please contact customer service");
        teamLevel.IsDeleted = 1;
        teamLevel.DeleteUserId = deleteUserId;
        await _freeSql.Update<TeamLevel>(teamLevel.Id)
            .SetSource(teamLevel)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取团队等级
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    public async Task<TeamLevelDto> GetTeamLevel(long levelId)
    {
        var teamLevel = await _freeSql.Select<TeamLevel>()
            .Where(s => s.Id == levelId)
            .ToOneAsync();
        return teamLevel.MapTo<TeamLevelDto>();
    }

    /// <summary>
    ///  获取所有团队等级
    /// </summary>
    /// <returns></returns>
    public async Task<List<TeamLevelDto>> GetAllTeamLevels()
    {
        var teamLevels = await _freeSql.Select<TeamLevel>()
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        return teamLevels.MapToList<TeamLevelDto>();
    }

    /// <summary>
    ///  获取团队等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<TeamLevelDto>> GetTeamLevelPagedList(TeamLevelPagedInput input)
    {
        var list = await _freeSql.Select<TeamLevel>()
            .WhereIf(!string.IsNullOrEmpty(input.LevelName), s => s.LevelName.Contains(input.LevelName))
            .Where(s => s.IsDeleted == 0)
            .OrderBy(s => s.LevelSort)
            .Count(out long totalCount)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<TeamLevelDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<TeamLevelDto>()
        };

        return output;
    }


   

    #endregion

    #region 团队分润

    /// <summary>
    ///  信息验证
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="MyException"></exception>
    private async Task TeamProfitVerify(TeamBuyProfitSettingInput input)
    {
        if (input.BuyProfitRate <= 0)
            throw new MyException("Please enter the profit sharing ratio");
        if (input.Hierarchy <= 0)
            throw new MyException("Please enter the number of upper layers");
        
        //查看是否存在相同层级的设置
        var hierarchyAny = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.Hierarchy == input.Hierarchy)
            .Where(s => s.Id != input.Id)
            .AnyAsync();
        if (hierarchyAny)
            throw new MyException("There are settings at the same level");
    }

    /// <summary>
    ///  团队分润设置添加
    /// </summary>
    /// <param name="input"></param>
    public async Task TeamProfitCreate(TeamBuyProfitSettingInput input)
    {
        await TeamProfitVerify(input);
        var teamProfitSetting = input.MapTo<TeamBuyProfitSetting>();
        teamProfitSetting.Id = IdHelper.GetId();

        await _freeSql.Insert(teamProfitSetting).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  团队分润设置编辑
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task TeamProfitUpdate(TeamBuyProfitSettingInput input)
    {
        await TeamProfitVerify(input);
        var teamProfitSetting = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.Id == input.Id && s.IsDeleted == 0)
            .ToOneAsync();
        if (teamProfitSetting == null)
            throw new MyException("Data error");
        teamProfitSetting.Hierarchy = input.Hierarchy;
        teamProfitSetting.BuyProfitRate = input.BuyProfitRate;
        teamProfitSetting.UpdateAt = DateTimeHelper.UtcNow();

        await _freeSql.Update<TeamBuyProfitSetting>()
            .SetSource(teamProfitSetting)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  团队分润删除
    /// </summary>
    /// <param name="profitId"></param>
    /// <param name="deleteUserId"></param>
    public async Task TeamProfitDelete(long profitId, long deleteUserId)
    {
        var teamProfitSetting = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.Id == profitId && s.IsDeleted == 0)
            .ToOneAsync();
        if (teamProfitSetting == null)
            throw new MyException("Data error");
        teamProfitSetting.IsDeleted = 1;
        teamProfitSetting.DeleteUserId = deleteUserId;
        await _freeSql.Update<TeamBuyProfitSetting>()
            .SetSource(teamProfitSetting)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    /// 获取团队分润
    /// </summary>
    /// <param name="profitId"></param>
    /// <returns></returns>
    public async Task<TeamBuyProfitSettingDto> GetTeamProfit(long profitId)
    {
        var teamProfitSetting = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.Id == profitId && s.IsDeleted == 0)
            .ToOneAsync();

        return teamProfitSetting.MapTo<TeamBuyProfitSettingDto>();
    }

    /// <summary>
    ///  获取团队分润列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<TeamBuyProfitSettingDto>> GetTeamProfitPagedList(PagedInput input)
    {
        var list = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.IsDeleted == 0)
            .Count(out long totalCount)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<TeamBuyProfitSettingDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<TeamBuyProfitSettingDto>()
        };

        return output;
    }

    /// <summary>
    ///  用户团队成员返润
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="amount"></param>
    public async Task UserTeamMemberProfit(long userId, decimal amount)
    {
        var teamProfits = await _freeSql.Select<TeamBuyProfitSetting>()
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var maxSort = teamProfits.Max(s => s.Hierarchy);
        var teamParentMembers = await _userService.GetUserTeamParentMembers(userId, maxSort);
        foreach (var tp in teamProfits)
        {
            var parentUser = teamParentMembers.FirstOrDefault(s => s.LevelSort == tp.Hierarchy);
            if (parentUser == null)
                continue;
            //添加返佣流水
            var commissionAmount = amount * tp.BuyProfitRate * 0.01m;
            if (commissionAmount > 0)
            {
                _userWalletService.WalletRecordCreate(new UserWalletRecordDto
                {
                    UserId = userId,
                    Amount = commissionAmount,
                    SourceType = WalletSourceEnums.FianncilCommission,
                    OperateType = WalletOperateEnums.Sytem,
                    OperateUserId = 0
                });
            }
        }
    }

    #endregion
}