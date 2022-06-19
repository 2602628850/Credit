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
    public async Task<PagedOutput<MoneyApplyDto>> GetRechargeApplyPagedList(MoneyApplyPagedInput input)
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
    public async Task<PagedOutput<MoneyApplyDto>> GetWithdrawalApplyPagedList(MoneyApplyPagedInput input)
    {
        input.Source = WalletSourceEnums.WithdrawalApply;
        return await _userWalletService.GetMoneyApplyPagedList(input);
    }

    /// <summary>
    ///  申请审核
    /// </summary>
    /// <param name="input"></param>
    [HttpGet]
    public async Task MoneyApplyAudit(MoneyApplyAuditInput input)
    {
        await _userWalletService.MoneyApplyAudit(input, CurrentAdmin.UserId);
    }
}