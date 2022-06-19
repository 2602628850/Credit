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

namespace Credit.Api.Controllers
{
    /// <summary>
    ///  用户接口管理
    /// </summary>
    public class UserController : BaseUserController
    {
        private readonly IUserService _userService;
        private readonly IUserWalletService _walletService;
        private readonly IUserBankCardService _userBankCardService;

        /// <summary>
        /// 
        /// </summary>
        public UserController(
            ITokenManager tokenManager
            ,IUserService userService
            ,IUserWalletService walletService
            ,IUserBankCardService userBankCardService) : base(tokenManager)
        {
            _userService = userService;
            _walletService = walletService;
            _userBankCardService = userBankCardService;
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
                SourceType = WalletSourceEnums.RechargeApply,
                Type = input.Type,
                PayeeBankCardId = input.PayeeBankCardId,
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
                SourceType = WalletSourceEnums.WithdrawalApply,
                PayeeBankCardId = input.PayeeBankCardId,
                PaymentInfoId = input.PaymentInfoId,
                Remark = input.Remark
            },CurrentUser.UserId);
        }

        /// <summary>
        ///  绑定银行卡
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task BindBankCard([FromBody]BindBankCardInput input)
        {
            await _userBankCardService.UserBankCardCreate(input, CurrentUser.UserId);
        }

        /// <summary>
        ///  银行卡删除
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task DeleteBankCard([FromBody]IdInput input)
        {
            await _userBankCardService.UserBankCardDelete(input.Id, CurrentUser.UserId);
        }

        /// <summary>
        ///   获取用户绑定银行卡
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UserBankCardDto>> GetUserBindCardList()
        {
            return await _userBankCardService.GetUserBankCardList(CurrentUser.UserId);
        }
    }
}
