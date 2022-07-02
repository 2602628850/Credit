using Credit.SettingModels;
using Credit.SettingServices.Dtos;
using Data.Commons.Helpers;

namespace Credit.SettingServices;

/// <summary>
///  配置接口方法实现
/// </summary>
public class SettingService : ISettingService
{
    private readonly IFreeSql _freeSql;

    public SettingService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  保存设置
    /// </summary>
    /// <param name="setting"></param>
    /// <typeparam name="TSetting"></typeparam>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SetSetting<TSetting>(TSetting setting) where TSetting : ISetting, new()
    {
        var classes = setting.GetType();
        var oldList = await _freeSql.Select<SysSettings>().Where(s => s.Classes == classes.FullName).ToListAsync();
        await _freeSql.Delete<SysSettings>(oldList).ExecuteAffrowsAsync();

        var propertys = classes.GetProperties();

        var list = new List<SysSettings>();
        foreach (var p in propertys)
        {
            var input = new SysSettings
            {
                Id = IdHelper.GetId(),
                Classes = classes.FullName,
                Key = p.Name,
                Value = JsonHelper.SerializeObject(p.GetValue(setting))
            };
            list.Add(input);
        }

        await _freeSql.Insert(list).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取设置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public async Task<T> GetSetting<T>() where T : ISetting, new()
    {
        var t = new T();
        var classes = t.GetType();
        var settings = await _freeSql.Select<SysSettings>().Where(s => s.Classes == classes.FullName).ToListAsync();
        var propertys = t.GetType().GetProperties();

        foreach (var p in propertys)
        {
            var s = settings.FirstOrDefault(k => k.Key == p.Name);
            if (s != null && s.Value != null)
            {
                p.SetValue(t, Convert.ChangeType(JsonHelper.DeserializeObject<object>(s.Value), p.PropertyType));
            }
        }
        return t;
    }
}