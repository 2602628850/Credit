using Credit.RepayServices;
using Credit.RepayServices.Dtos;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="repayService"></param>
    public RepayController(ITokenManager tokenManager
    ,IRepayService repayService)
    : base(tokenManager)
    {
        _repayService = repayService;
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
    ///  获取还款卡号
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<RepayBankCardDto>> GetRepayBankCardList(long levelId)
    {
        return await _repayService.GetRepayBankCardList(levelId);
    }
}