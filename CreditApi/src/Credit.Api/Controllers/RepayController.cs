using Credit.RepayServices;
using Credit.RepayServices.Dtos;
using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  用户代还管理
/// </summary>
public class RepayController : BaseUserController
{
    private readonly IRepayService _repayService;
    private readonly IUserWalletService _userWalletService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="repayService"></param>
    /// <param name="userWalletService"></param>
    public RepayController(ITokenManager tokenManager
    ,IRepayService repayService
    ,IUserWalletService userWalletService)
    : base(tokenManager)
    {
        _repayService = repayService;
        _userWalletService = userWalletService;
    }

    /// <summary>
    ///  获取还款等级集合
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<RepayLevelDto>> GetRepayLevelList()
    {
        return await _repayService.GetRepayLevelList();
    }
    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<RepayLevelDto> GetRepayLevel(LeavesInput input)
    {
        return await _repayService.GetRepayLevel(input.Leaveid);
    }

    /// <summary>
    ///  获取还款卡号
    ///  uniapp只支持对象传参,不能用long levelId接收参数
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<RepayBankCardDto>> GetRepayBankCardList(LeavesInput input)
    {
        return await _repayService.GetRepayBankCardList(input.Leaveid);
    }


    /// <summary>
    ///  代还
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task<string> RepayApplication([FromBody]MoneyApplyInput input)
    {
        input.SourceType = WalletSourceEnums.RepayApply;
        return await _userWalletService.MoneyApplyCreate(input,CurrentUser.UserId);
    }
}