using Credit.SettingServices;
using Credit.SettingServices.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  管理员系统配置
/// </summary>
public class AdminSettingController : BaseAdminController
{
    private readonly ISettingService _settingService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="settingService"></param>
    public AdminSettingController(ITokenManager tokenManager
    , ISettingService settingService)
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

    /// <summary>
    ///  任务积分设置
    /// </summary>
    /// <param name="taskIntegral"></param>
    [HttpPost]
    public async Task TaskIntegralSetting([FromBody] TaskIntegralSetting taskIntegral)
    {
        await _settingService.SetSetting(taskIntegral);
    }
     
    /// <summary>
    ///  获取阿里巴巴服务设置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<AlibabaCloudSetting> GetAlibabaCloudSetting()
    {
        return await _settingService.GetSetting<AlibabaCloudSetting>();
    }

    /// <summary>
    ///  阿里巴巴服务设置
    /// </summary>
    /// <param name="alibabaCloud"></param>
    [HttpPost]
    public async Task AlibabaCloudSetting([FromBody] AlibabaCloudSetting alibabaCloud)
    {
        await _settingService.SetSetting(alibabaCloud);
    }
}