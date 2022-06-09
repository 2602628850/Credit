using System.Data;

namespace Data.Commons.Caching;

public class CacheManager : ICacheManager
{
    /// <summary>
    ///  获取缓存
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T Get<T>(string key)
    {
        return RedisHelper.Get<T>(key);
    }
    
    /// <summary>
    ///   获取缓存
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> GetAsync<T>(string key)
    {
        return await RedisHelper.GetAsync<T>(key);
    }
    
    /// <summary>
    ///   设置缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="cacheTime"></param>
    public void Set(string key, object data, TimeSpan cacheTime)
    {
        RedisHelper.Set(key,data,Convert.ToInt32(cacheTime));
    }

    /// <summary>
    ///  设置缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="cacheTime"></param>
    /// <returns></returns>
    public async Task SetAsync(string key, object data, TimeSpan cacheTime)
    {
        await RedisHelper.SetAsync(key, data, Convert.ToInt32(cacheTime));
    }
    
    /// <summary>
    ///  key是否存在
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsSet(string key)
    {
        return RedisHelper.Exists(key);
    }

    /// <summary>
    ///  删除key
    /// </summary>
    /// <param name="key"></param>
    public void Remove(string key)
    {
        RedisHelper.Del(key);
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}