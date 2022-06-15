using Credit.UserServices.Dtos;
using Credit.UserServices;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;
using Microsoft.AspNetCore.Mvc;
using Data.Core.Controllers;

namespace Credit.Api.Controllers
{
    /// <summary>
    ///  用户接口管理
    /// </summary>
    public class UserController : BaseUserController
    {
        private readonly IUserService _userService;
        private readonly IUserWalletService _walletService;

        /// <summary>
        /// 
        /// </summary>
        public UserController(
            ITokenManager tokenManager
            ,IUserService userService
            ,IUserWalletService walletService) : base(tokenManager)
        {
            _userService = userService;
            _walletService = walletService;
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
        public async Task<UserDto> GetUserInfo()
        {
            return await _userService.GetUserById(CurrentUser.UserId);
        }
        
        /// <summary>
        ///  获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<UserDto>> GetUserPagedList([FromQuery]PagedInput input)
        {
            return await _userService.GetUserPagedList(input);
        }

        /// <summary>
        /// 用户充值
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task UserRecharge([FromBody]UserMoneyApplyInput input)
        {
            await _walletService.MoneyApplyCreate(new MoneyApplyInput
            {
                Amount = input.Amount,
                WalletSource = WalletSourceEnums.Recharge,
                Type = input.Type,
                PayeeCardId = input.PayeeCardId,
                PaymentInfoId = input.PaymentInfoId,
                Remark = input.Remark
            },CurrentUser.UserId);
        }

        /// <summary>
        ///  用户提款
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task UserWithdrawal([FromBody]UserMoneyApplyInput input)
        {
            await _walletService.MoneyApplyCreate(new MoneyApplyInput
            {
                Amount = input.Amount,
                WalletSource = WalletSourceEnums.Withdrawal,
                PayeeCardId = input.PayeeCardId,
                PaymentInfoId = input.PaymentInfoId,
                Remark = input.Remark
            },CurrentUser.UserId);
        }
    }
}
