using Credit.UserServices.Dtos;
using Credit.UserServices;
using Microsoft.AspNetCore.Mvc;
using Data.Core.Controllers;

namespace Credit.Api.Controllers
{
    /// <summary>
    ///  用户管理
    /// </summary>
    [Route("v1/[controller]/[action]")]
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
        [HttpPost]
        public async Task CreateUser([FromBody] UserInput input)
        { 
            await _userService.CreateUser(input);
        }


        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetUserInfo()
        {
            return new { name = "111111" };
        }
    }
}
