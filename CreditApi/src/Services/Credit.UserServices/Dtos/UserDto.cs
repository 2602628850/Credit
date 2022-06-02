using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.UserServices.Dtos
{
    public class UserInput
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///  密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; }
    }

    internal class UserDto
    {
    }
}
