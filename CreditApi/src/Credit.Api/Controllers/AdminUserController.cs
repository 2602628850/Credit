using Credit.UserBankCardServices;
using Credit.UserBankCardServices.Dtos;
using Credit.UserServices.Dtos;
using Credit.UserServices;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;
using Microsoft.AspNetCore.Mvc;
using Data.Core.Controllers;
using Credit.IntegralServices;
using Credit.IntegralServices.Dtos;
using Credit.IntegralServices.Implements;
using Credit.PayeeBankCardServices;
using Credit.PayeeBankCardServices.Dtos;
using Credit.BankModels;

namespace Credit.Api.Controllers
{
    /// <summary>
    ///  用户接口管理
    /// </summary>
    public class AdminUserController : BaseUserController
    {
        private readonly IUserService _userService;
        private readonly IUserWalletService _walletService;
        private readonly IUserBankCardService _userBankCardService;
        private readonly IIntegralOrderService _integralOrderService;
        private readonly IIntegralRecodeService _integralRecodeService;
        private readonly IPayeeBankCardService _payeeBankCardService;

        /// <summary>
        /// 
        /// </summary>
        public AdminUserController(
            ITokenManager tokenManager
            , IUserService userService
            , IUserWalletService walletService
            , IUserBankCardService userBankCardService,
            IIntegralOrderService integralOrderService,
            IIntegralRecodeService integralRecodeService,
            IPayeeBankCardService payeeBankCardService) : base(tokenManager)
        {
            _userService = userService;
            _walletService = walletService;
            _userBankCardService = userBankCardService;
            _integralOrderService = integralOrderService;
            _integralRecodeService = integralRecodeService;
            _payeeBankCardService = payeeBankCardService;
        }

        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task CreateAdminUser([FromBody] AdminUserDto input)
        {
            await _userService.CreateAdminUser(input);
        }

        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task<string> UpdateAdminUser([FromBody] AdminUserDto input)
        {
            input.Id = CurrentUser.UserId;
            return await _userService.UpdateAdminUser(input);
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
        ///  银行删除
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task AdminUserDelete([FromBody] IdInput input)
        {
            await _userService.UserDelete(input.Id,CurrentUser.UserId);
        }
        /// <summary>
        ///  获取管理员列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<AdminUserDto>> GetAdminUserPagedList([FromQuery] UserPagedInput input)
        {
            return await _userService.GetAdminUserPagedList(input);
        }
    }
}
