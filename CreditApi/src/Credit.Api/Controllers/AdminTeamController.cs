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
}