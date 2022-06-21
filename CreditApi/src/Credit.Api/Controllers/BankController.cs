using Credit.BankServices;
using Credit.BankServices.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  银行接口管理
/// </summary>
public class BankController : BaseUserController
{
    private readonly IBankService _bankService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="bankService"></param>
    public BankController(ITokenManager tokenManager
        ,IBankService bankService) : base(tokenManager)
    {
        _bankService = bankService;
    }

    /// <summary>
    ///  获取银行
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<BankSelectDto>> GetBankList()
    {
        return await _bankService.GetBankList();
    }
}