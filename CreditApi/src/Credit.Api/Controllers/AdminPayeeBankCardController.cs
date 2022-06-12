using Credit.PayeeBankCardServices;
using Credit.PayeeBankCardServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  收款银行卡信息管理
/// </summary>
public class AdminPayeeBankCardController : BaseAdminController
{
    private readonly IPayeeBankCardService _payeeBankCardService;

    /// <summary>
    ///  
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="payeeBankCardService"></param>
    public AdminPayeeBankCardController(ITokenManager tokenManager,
        IPayeeBankCardService payeeBankCardService) : base(tokenManager)
    {
        _payeeBankCardService = payeeBankCardService;
    }

    /// <summary>
    ///  收款银行卡信息添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task PayeeBankCardCreate([FromBody]PayeeBankCardInput input)
    {
        await _payeeBankCardService.PayeeBankCardCreate(input);
    }
    
    /// <summary>
    ///  收款银行卡信息编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task PayeeBankCardUpdate([FromBody]PayeeBankCardInput input)
    {
        await _payeeBankCardService.PayeeBankCardUpdate(input);
    }

    /// <summary>
    ///  收款银行卡删除
    /// </summary>
    /// <param name="bankCardId"></param>
    [HttpPost]
    public async Task PayeeBankCardDelete([FromBody]long bankCardId)
    {
        await _payeeBankCardService.PayeeBankCardDelete(bankCardId, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  收款银行卡启用
    /// </summary>
    /// <param name="bankCardIds"></param>
    [HttpPost]
    public async Task PayeeBankCardEnable([FromBody]List<long> bankCardIds)
    {
        await _payeeBankCardService.PayeeBankCardEnable(bankCardIds);
    }

    /// <summary>
    ///  收款银行卡禁用
    /// </summary>
    /// <param name="bankCardIds"></param>
    [HttpPost]
    public async Task PayeeBankCardDisabled([FromBody]List<long> bankCardIds)
    {
        await _payeeBankCardService.PayeeBankCardDisabled(bankCardIds);
    }

    /// <summary>
    ///  获取收款银行卡信息
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PayeeBankCardDto> GetPayeeBankCardById([FromQuery]long bankCardId)
    {
        return await _payeeBankCardService.GetPayeeBankCardById(bankCardId);
    }

    /// <summary>
    ///  获取收款银行卡列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<PayeeBankCardDto>> GetPayeeBankCardPagedList([FromQuery]PayeeBankCardPagedInput input)
    {
        return await _payeeBankCardService.GetPayeeBankCardPagedList(input);
    }
}