﻿using Credit.UserServices.Dtos;
using Credit.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers
{
    /// <summary>
    ///  用户管理
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("CreateUser")]
        public void CreateUser([FromBody] UserInput input)
        { 
            _userService.CreateUser(input);
        }


        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public object GetUserInfo()
        {
            return new { name = "111111" };
        }
    }
}
