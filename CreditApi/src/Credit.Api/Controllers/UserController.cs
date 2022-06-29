﻿using Credit.UserBankCardServices;
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


        /// <summary>
        ///  获取用户充值记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<UserWalletRecordDto>> GetUserRechargePagedList(WalletRecordPagedInput input)
        {
            input.UserId = CurrentUser.UserId;
            input.WalletSource = WalletSourceEnums.Recharge;
            return await _walletService.GetUserWalletRecordPagedList(input);
        }
        
        /// <summary>
        ///  获取用户提款记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<UserWalletRecordDto>> GetUserWithdrawalPagedList(WalletRecordPagedInput input)
        {
            input.UserId = CurrentUser.UserId;
            input.WalletSource = WalletSourceEnums.Withdrawal;
            return await _walletService.GetUserWalletRecordPagedList(input);
        }
        
        /// <summary>
        ///  获取用户资金明细列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<UserWalletRecordDto>> GetUserWalletRecordPagedList(WalletRecordPagedInput input)
        {
            input.UserId = CurrentUser.UserId;
            return await _walletService.GetUserWalletRecordPagedList(input);
        }
        /// <summary>
        ///  用户积分转余额
        /// </summary>[FromBody]RegisterUserInput input
        /// <returns></returns>
        [HttpGet]
        public async Task<string> ExchangeIntegral(UserDto input )
        {

            //转换率,呢个以后在后台设置,现在写死
            decimal exchangeRate = 0.1M;
            UserDto user = await _userService.GetUserById(CurrentUser.UserId);
            if (input.Integral > user.Integral)
            {
                return "1";
            }
            user.Balance = user.Balance + (input.Integral * exchangeRate);
            user.Integral = user.Integral - input.Integral;
            _userService.ExchangeIntegral(user);
            return "0";

        }
    }
}
