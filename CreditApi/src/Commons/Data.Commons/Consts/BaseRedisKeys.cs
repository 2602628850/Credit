using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commons.Consts
{
    /// <summary>
    /// redis 
    /// </summary>
    public static class BaseRedisKeys
    {
        /// <summary>
        /// 获取用户id
        /// 0: token
        /// </summary>
        public const string USER_GET_USERID_BY_TOKEN = "user:tokens:{0}";
        /// <summary>
        /// 获取用户token
        /// 0: userid
        /// </summary>
        public const string USER_GET_TOKEN_BY_USERID = "user:tokens:userid:{0}";
        /// <summary>
        /// 获取用户信息
        /// 0: userid
        /// </summary>
        public const string USER_GET_USERINFO_BY_USERID = "user:tokens:userinfo:{0}";
        /// <summary>
        /// 用户名锁
        /// 0: username
        /// </summary>
        public const string LOCK_USER_USERNAME = "lock:user:username:{0}";
        /// <summary>
        /// 邀请码锁
        /// </summary>
        public const string LOCK_INVITATION_CODE = "lock:user:invitation_code";
    }
}
