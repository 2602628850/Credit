using Credit.SettingServices.Dtos;

namespace Credit.SettingServices;

/// <summary>
///  配置接口方法定义
/// </summary>
public interface ISettingService
{
    /// <summary>
    /// 保存配置
    /// </summary>
    /// <returns></returns>
    Task SetSetting<TSetting>(TSetting setting) where TSetting : ISetting, new();

    /// <summary>
    /// 获取配置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> GetSetting<T>() where T : ISetting, new();
}