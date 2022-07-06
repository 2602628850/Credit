using Credit.PayeeBankCardServices;
using Credit.PayeeBankCardServices.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  收款银行卡
/// </summary>
public class PayeeBankCardController : BaseUserController
{
    private readonly IPayeeBankCardService _payeeBankCardService;
    
    /// <summary>
    ///  
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="payeeBankCardService"></param>
    public PayeeBankCardController(ITokenManager tokenManager,
        IPayeeBankCardService payeeBankCardService) : base(tokenManager)
    {
        _payeeBankCardService = payeeBankCardService;
    }

    /// <summary>
    ///  获取充值银行卡
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PayeeBankCardSelectDto> GetPayeeBankCard([FromQuery]BankCardAmountInput input)
    {
        return await _payeeBankCardService.GetAvailablePayeeBankCards(input.Amount);
    }
}