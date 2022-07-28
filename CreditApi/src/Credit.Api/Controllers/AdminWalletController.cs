using Credit.UserWalletServices;
using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  钱包资金管理
/// </summary>
public class AdminWalletController : BaseAdminController
{
    private readonly IUserWalletService _userWalletService;

    public AdminWalletController(ITokenManager tokenManager,
        IUserWalletService userWalletService) : base(tokenManager)
    {
        _userWalletService = userWalletService;
    }

    /// <summary>
    ///  获取充值申请列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<MoneyApplyDto>> GetRechargeApplyPagedList([FromQuery]MoneyApplyPagedInput input)
    {
        input.Source = WalletSourceEnums.RechargeApply;
        return await _userWalletService.GetMoneyApplyPagedList(input);
    }
    
    /// <summary>
    ///  获取提款列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<MoneyApplyDto>> GetWithdrawalApplyPagedList([FromQuery]MoneyApplyPagedInput input)
    {
        input.Source = WalletSourceEnums.WithdrawalApply;
        return await _userWalletService.GetMoneyApplyPagedList(input);
    }
    
    /// <summary>
    ///  代还申请列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<MoneyApplyDto>> GetRepayApplyPagedList([FromQuery]MoneyApplyPagedInput input)
    {
        input.Source = WalletSourceEnums.CardRepayApply;
        return await _userWalletService.GetMoneyApplyPagedList(input);
    }

    /// <summary>
    ///  申请审核
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task MoneyApplyAudit([FromBody]MoneyApplyAuditInput input)
    {
        await _userWalletService.MoneyApplyAudit(input, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取申请未处理数量统计
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApplyDefaultCountDto> GetApplyDefaultCount()
    {
        return await _userWalletService.GetApplyDefaultCount();
    }
}