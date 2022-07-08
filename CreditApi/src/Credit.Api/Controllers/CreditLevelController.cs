using Credit.CreditLevelServices.Dtos;
using Credit.CreditLevelServices.Interfaces;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

public class CreditLevelController : BaseUserController
{
    private readonly ICreditLevelService _creditService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="creditService"></param>
    public CreditLevelController(ITokenManager tokenManager
        , ICreditLevelService creditService) : base(tokenManager)
    {
        _creditService = creditService;
    }

    /// <summary>
    ///  获取所有信用等级
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<CreditLevelDto>> GetAllCreditLevels()
    {
        return await _creditService.GetAllCreditLevels();
    }
}
