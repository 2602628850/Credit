namespace Data.Commons.Caching;

public interface ICacheManager
{
    /// <summary>
    ///  获取缓存
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T Get<T>(string key);
    
    /// <summary>
    ///  获取缓存异步
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> GetAsync<T>(string key);

    /// <summary>
    ///  设置缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="cacheTime"></param>
    void Set(string key,object data,TimeSpan cacheTime);
    
    /// <summary>
    ///  设置缓存异步
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="cacheTime"></param>
    /// <returns></returns>
    Task SetAsync(string key,object data,TimeSpan cacheTime);

    /// <summary>
    ///  key是否设置缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool IsSet(string key);

    /// <summary>
    ///  移除缓存
    /// </summary>
    /// <param name="key"></param>
    void Remove(string key);

    /// <summary>
    ///  清空所有缓存
    /// </summary>
    void Clear();
}