using Credit.SettingServices;
using Credit.SettingServices.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  系统配置
/// </summary>
public class SettingController : BaseUserController
{
    private readonly ISettingService _settingService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="settingService"></param>
    public SettingController(ITokenManager tokenManager
        ,ISettingService settingService)
        : base(tokenManager)
    {
        _settingService = settingService;
    }

    /// <summary>
    ///  获取任务积分配置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<TaskIntegralSetting> GetTaskIntegralSetting()
    {
        return await _settingService.GetSetting<TaskIntegralSetting>();
    }

}