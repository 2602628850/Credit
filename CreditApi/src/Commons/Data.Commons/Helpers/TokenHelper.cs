using Data.Commons.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commons.Helpers
{
    /// <summary>
    /// Token User
    /// </summary>
    public interface ITokenUser
    {
        /// <summary>
        /// 用户id
        /// </summary>
        long UserId { get; set; }
    }

    /// <summary>
    /// Token Admin
    /// </summary>
    public interface ITokenAdmin : ITokenUser
    {
        /// <summary>
        /// 是否是管理员
        /// </summary>
        int IsAdmin { get; set; }
    }

    /// <summary>
    /// Token
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expireSeconds">过期(秒单位)</param>
        /// <returns></returns>
        Task<string> GenerateToken(ITokenUser value, int expireSeconds = -1);

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<string> GetToken(ITokenUser value);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<T> GetUserInfo<T>(long userId);

        /// <summary>
        /// 清除token
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task ClearToken(ITokenUser value);

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<T> DeserializeToken<T>(string token) where T : ITokenUser;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TokenManager : ITokenManager
    {
        /// <summary>
        /// 清除token
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task ClearToken(ITokenUser value)
        {
            var useridKey = string.Format(BaseRedisKeys.USER_GET_TOKEN_BY_USERID, value.UserId);

            var token = await RedisHelper.GetAsync<string>(useridKey);
            var tokenKey = string.Format(BaseRedisKeys.USER_GET_USERID_BY_TOKEN, token);
            var userinfoKey = string.Format(BaseRedisKeys.USER_GET_USERINFO_BY_USERID, value.UserId);

            await RedisHelper.DelAsync(useridKey);
            await RedisHelper.DelAsync(tokenKey);
            await RedisHelper.DelAsync(userinfoKey);
        }

        /// <summary>
        /// 解析token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<T> DeserializeToken<T>(string token) where T : ITokenUser
        {
            var tokenKey = string.Format(BaseRedisKeys.USER_GET_USERID_BY_TOKEN, token);
            var userid = await RedisHelper.GetAsync<string>(tokenKey);

            var userinfoKey = string.Format(BaseRedisKeys.USER_GET_USERINFO_BY_USERID, userid);
            return await RedisHelper.GetAsync<T>(userinfoKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expireSeconds">过期(秒单位)</param>
        /// <returns></returns>
        public async Task<string> GenerateToken(ITokenUser value, int expireSeconds = -1)
        {
            var token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            var tokenKey = string.Format(BaseRedisKeys.USER_GET_USERID_BY_TOKEN, token);
            var useridKey = string.Format(BaseRedisKeys.USER_GET_TOKEN_BY_USERID, value.UserId);
            var userinfoKey = string.Format(BaseRedisKeys.USER_GET_USERINFO_BY_USERID, value.UserId);

            await RedisHelper.SetAsync(tokenKey, value.UserId, expireSeconds);
            await RedisHelper.SetAsync(useridKey, token, expireSeconds);
            await RedisHelper.SetAsync(userinfoKey, value, expireSeconds);

            return token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<string> GetToken(ITokenUser value)
        {
            var useridKey = string.Format(BaseRedisKeys.USER_GET_TOKEN_BY_USERID, value.UserId);
            return RedisHelper.GetAsync<string>(useridKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<T> GetUserInfo<T>(long userId)
        {
            var userinfoKey = string.Format(BaseRedisKeys.USER_GET_USERINFO_BY_USERID, userId);
            return RedisHelper.GetAsync<T>(userinfoKey);
        }
    }
}

