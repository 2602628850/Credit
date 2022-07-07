using Microsoft.AspNetCore.Mvc;
using Credit.TeamServices;
using Credit.TeamServices.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;

namespace Credit.Api.Controllers;

/// <summary>
///  团队管理
/// </summary>
public class TeamController : BaseUserController
{
    private readonly ITeamService _teamService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="teamService"></param>
    public TeamController(ITokenManager tokenManager
    ,ITeamService teamService) : base(tokenManager)
    {
        _teamService = teamService;
    }

    /// <summary>
    ///  获取所有团队等级
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<TeamLevelDto>> GetAllTeamLevels()
    {
        return await _teamService.GetAllTeamLevels();
    }
}