using Credit.RepayServices;
using Credit.RepayServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  管理员代还管理
/// </summary>
public class AdminRepayController : BaseAdminController
{
    private readonly IRepayService _repayService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="repayService"></param>
    public AdminRepayController(ITokenManager tokenManager
    ,IRepayService repayService)
    : base(tokenManager)
    {
        _repayService = repayService;
    }

    #region 还款等级

    /// <summary>
    ///  还款等级添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayLevelCreate([FromBody]RepayLevelInput input)
    {
        await _repayService.RepayLevelCreate(input);
    }
    
    /// <summary>
    ///  还款等级编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayLevelUpdate([FromBody]RepayLevelInput input)
    {
        await _repayService.RepayLevelUpdate(input);
    }

    /// <summary>
    ///  还款等级删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayLevelDelete([FromBody]ListIdInput input)
    {
        await _repayService.RepayLevelDelete(input.Ids,CurrentAdmin.UserId);
    }
    
    /// <summary>
    ///  还款等级启用
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayLevelEnable([FromBody]ListIdInput input)
    {
        await _repayService.RepayLevelEnable(input.Ids);
    }
    
    /// <summary>
    ///  还款等级停用
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayLevelDisable([FromBody]ListIdInput input)
    {
        await _repayService.RepayLevelDisable(input.Ids);
    }

    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<RepayLevelDto> GetRepayLevel([FromQuery]long repayLevelId)
    {
        return await _repayService.GetRepayLevel(repayLevelId);
    }

    /// <summary>
    ///  获取还款等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<RepayLevelDto>> GetRepayLevelPagedList([FromQuery]RepayLevelPagedInput input)
    {
        return await _repayService.GetRepayLevelPagedList(input);
    }

    #endregion

    #region 还款银行卡

    /// <summary>
    ///  还款银行卡添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayBankCardCreate([FromBody]RepayBankCardInput input)
    {
        await _repayService.RepayBankCardCreate(input);
    }

    /// <summary>
    ///  还款银行卡编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayBankCardUpdate([FromBody]RepayBankCardInput input)
    {
        await _repayService.RepayBankCardUpdate(input);
    }
    
    /// <summary>
    ///  还款银行卡删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayBankCardDelete([FromBody]ListIdInput input)
    {
        await _repayService.RepayBankCardDelete(input.Ids,CurrentAdmin.UserId);
    }
    
    /// <summary>
    ///  还款银行卡启用
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayBankCardEnable([FromBody]ListIdInput input)
    {
        await _repayService.RepayBankCardEnable(input.Ids);
    }
    
    /// <summary>
    ///  还款银行卡停用
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task RepayBankCardDisable([FromBody]ListIdInput input)
    {
        await _repayService.RepayBankCardDisable(input.Ids);
    }

    /// <summary>
    ///  获取还款银行卡
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<RepayBankCardDto> GetRepayBankCard([FromQuery]long bankCardId)
    {
        return await _repayService.GetRepayBankCard(bankCardId);
    }

    /// <summary>
    ///  获取还款银行卡列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<RepayBankCardDto>> GetRepayBankCardPagedList([FromQuery]RepayBankCardPagedInput input)
    {
        return await _repayService.GetRepayBankCardPagedList(input);
    }

    #endregion
}