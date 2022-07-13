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
        private readonly IIntegralOrderService _integralOrderService;
        private readonly IIntegralRecodeService _integralRecodeService;
        private readonly IPayeeBankCardService _payeeBankCardService;

        /// <summary>
        /// 
        /// </summary>
        public UserController(
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
        ///  获取用户信用等级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserCreditDto> GetCreditLevleById()
        {
            return await _userService.GetCreditLevleById(CurrentUser.UserId);
        }
        /// <summary>
        ///  获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<UserDto>> GetUserPagedList([FromQuery] PagedInput input)
        {
            return await _userService.GetUserPagedList(input);
        }

        /// <summary>
        /// 用户充值
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task<string> UserRecharge([FromBody] UserMoneyApplyInput input)
        {
            PayeeBankCardSelectDto payeeBankCard = await _payeeBankCardService.GetAvailablePayeeBankCards(input.Amount);
            long payeeBankCardId = payeeBankCard.Id;//收款卡id
            return await _walletService.MoneyApplyCreate(new MoneyApplyInput
            {
                Amount = input.Amount,
                SourceType = WalletSourceEnums.RechargeApply,
                Type = input.Type,
                PayeeBankCardId = payeeBankCardId,// input.PayeeBankCardId,这里最好不要通过前台接收,因为很可能前端网络不稳定造成后台数据不准确
                PaymentInfoId = input.PaymentInfoId,
                Remark = input.Remark
            }, CurrentUser.UserId);
        }

        /// <summary>
        ///  用户提款
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task<string> UserWithdrawal([FromBody] UserMoneyApplyInput input)
        {

            return await _walletService.MoneyApplyCreate(new MoneyApplyInput
            {
                Amount = input.Amount,
                SourceType = WalletSourceEnums.WithdrawalApply,
                PayeeBankCardId = input.PayeeBankCardId,
                PaymentInfoId = input.PaymentInfoId,
                Remark = input.Remark
            }, CurrentUser.UserId);
        }

        /// <summary>
        ///  绑定银行卡
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task BindBankCard([FromBody] BindBankCardInput input)
        {
            await _userBankCardService.UserBankCardCreate(input, CurrentUser.UserId);
        }

        /// <summary>
        ///  银行卡删除
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task DeleteBankCard([FromBody] IdInput input)
        {
            await _userBankCardService.UserBankCardDelete(input.Id, CurrentUser.UserId);
        }

        /// <summary>
        ///   获取用户绑定银行卡
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        [HttpPost]
        public async Task<string> ExchangeIntegral([FromBody] UserDto input)
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
        /// <summary>
        /// 获取用户的当前积分
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<decimal> GetCountIntegral()
        {
            UserDto user = await _userService.GetUserById(CurrentUser.UserId);
            return user.Integral;
        }
        /// <summary>
        /// 获取用户的积分记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<IntegralRecodeDto>> GetIntegralRecode()
        {
            List<IntegralRecodeDto> integralRecodeList = await _integralRecodeService.GentntegralRecodeList(CurrentUser.UserId);
            return integralRecodeList;
        }
        /// <summary>
        /// 获取用户的积分订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<IntegralOrderDto>> GetIntegralOrder()
        {
            List<IntegralOrderDto> integralOrderList = await _integralOrderService.GentIntegralOrderList(CurrentUser.UserId);
            return integralOrderList;
        }
        /// <summary>
        ///  用户团队人数统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserTeamDto> GetTeamCountById()
        {
            return await _userService.GetTeamCountById(CurrentUser.UserId);
        }
        /// <summary>
        ///  获取用户团队信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserTeamImfoDto> GetUserTeamCountById()
        {
            return await _userService.GetUserTeamCountById(CurrentUser.UserId);
        }
        /// <summary>
        ///  获取用户收益信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserProfitDto> GetUserProfitById()
        {
            return await _userService.GetUserProfitById(CurrentUser.UserId);
        }
        /// <summary>
        ///   获取当前用户当年的所有提现记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<MoneyApplyDto>> GetUserMoneyApplyList()
        {
            return await _walletService.GetMoneyApplyRecode(CurrentUser.UserId);
        }
        /// <summary>
        ///   获取当前用户代还申请次数，已还次数，代换收益
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RepayIndexDto> GetRemainingChaka()
        {
            return await _walletService.GetRemainingChaka(CurrentUser.UserId);
        }
        /// <summary>
        ///   获取当前用户当年的所有信用卡代还申请记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<MoneyApplyDto>> GetUserMoneyWithoutList(MoneyApplyDto moneyApplyDto)
        {
            return await _walletService.GetMoneyWithoutRecode(CurrentUser.UserId, moneyApplyDto);
        }
    }
}
