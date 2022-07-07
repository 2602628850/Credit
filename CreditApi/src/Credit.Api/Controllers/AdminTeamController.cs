using Credit.TeamServices;
using Credit.TeamServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  管理员团队管理
/// </summary>
public class AdminTeamController : BaseAdminController
{
    private readonly ITeamService _teamService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="teamService"></param>
    public AdminTeamController(ITokenManager tokenManager
        ,ITeamService teamService) : base(tokenManager)
    {
        _teamService = teamService;
    }

    #region 团队等级

    /// <summary>
    ///  团队等级添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamLevelCreate([FromBody]TeamLevelInput input)
    {
        await _teamService.TeamLevelCreate(input);
    }
    
    /// <summary>
    ///  团队等级编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamLevelUpdate([FromBody]TeamLevelInput input)
    {
        await _teamService.TeamLevelUpdate(input);
    }
    
    /// <summary>
    ///  团队等级删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamLevelDelete([FromBody]IdInput input)
    {
        await _teamService.TeamLevelDelete(input.Id,CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取团队等级
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<TeamLevelDto> GetTeamLevel([FromQuery]IdInput input)
    {
        return await _teamService.GetTeamLevel(input.Id);
    }

    /// <summary>
    ///  获取团队等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<TeamLevelDto>> GetTeamLevelPagedList(TeamLevelPagedInput input)
    {
        return await _teamService.GetTeamLevelPagedList(input);
    }

    /// <summary>
    ///  更新用户团队等级
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task UpdateTeamLevel(UserIdInput input)
    {
        await _teamService.UpdateTeamLevel(input.UserId);
    }

    #endregion

    #region 团队分润

    /// <summary>
    ///  团队分润层级添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamProfitCreate([FromBody]TeamBuyProfitSettingInput input)
    {
        await _teamService.TeamProfitCreate(input);
    }
    
    /// <summary>
    ///  团队分润层级编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamProfitUpdate([FromBody]TeamBuyProfitSettingInput input)
    {
        await _teamService.TeamProfitUpdate(input);
    }

    /// <summary>
    ///  团队分润层级删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task TeamProfitDelete([FromBody]IdInput input)
    {
        await _teamService.TeamProfitDelete(input.Id, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取团队分润层级
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<TeamBuyProfitSettingDto> GetTeamProfit([FromQuery]IdInput input)
    {
        return await _teamService.GetTeamProfit(input.Id);
    }

    /// <summary>
    ///  获取团队分润层级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<TeamBuyProfitSettingDto>> GetTeamProfitPagedList([FromQuery]PagedInput input)
    {
        return await _teamService.GetTeamProfitPagedList(input);
    }

    #endregion
}