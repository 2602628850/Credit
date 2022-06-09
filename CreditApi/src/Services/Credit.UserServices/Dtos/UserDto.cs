﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Data.Commons.Helpers;

namespace Credit.UserServices.Dtos
{
    /// <summary>
    ///  用户登录输入
    /// </summary>
    public class UserLoginInput
    {
        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///  密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    ///  用户登录信息
    /// </summary>
    public class UserLoginDto : UserLoginInput,ITokenUser
    {
        /// <summary>
        ///  用户id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        ///  头像
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;
        
        /// <summary>
        ///  是否管理员
        /// </summary>
        public int IsAdmin { get; set; }
    }

    /// <summary>
    ///  用户登录输出
    /// </summary>
    public class UserLoginOutput
    {
        /// <summary>
        ///   登录token
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        ///  用户信息
        /// </summary>
        public UserLoginDto User { get; set; } = new UserLoginDto();
    }

    /// <summary>
    ///  注册用户输入
    /// </summary>
    public class RegisterUserInput : UserLoginInput
    {
        /// <summary>
        ///  确认密码
        /// </summary>
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class UserInput : UserLoginInput
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
    }

    /// <summary>
    ///  用户信息
    /// </summary>
    public class UserDto : UserInput
    {

    }
}
