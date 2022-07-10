using Credit.UserServices;
using Credit.UserServices.Dtos;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  账号管理
/// </summary>
//[Route("v1/[controller]/[action]")]
public class AccountController : BaseController
{
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    ///  账号注册
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task<string> RegisterAccount([FromBody]RegisterUserInput input)
    {
      return  await _userService.RegisterUser(input);
    }

    /// <summary>
    ///  用户登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UserLoginOutput> UserLogin([FromBody]UserLoginInput input)
    {
        return await _userService.UserLogin(input);
    }

    /// <summary>
    ///  管理员登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UserLoginOutput> AdminUserLogin([FromBody]UserLoginInput input)
    {
        return await _userService.AdminUserLogin(input);
    }   
}