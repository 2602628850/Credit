using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Commons.Helpers;

namespace Credit.UserServices.Dtos
{
    public class AdminUserDto
    { 
        /// <summary>
       /// 
       /// </summary>
        public long Id { get; set; }
        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        ///  头像
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;
        /// <summary>
        ///  确认密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
