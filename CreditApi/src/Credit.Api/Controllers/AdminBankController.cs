using Credit.BankServices;
using Credit.BankServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  银行接口管理
/// </summary>
public class AdminBankController : BaseAdminController
{
    private readonly IBankService _bankService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="bankService"></param>
    public AdminBankController(ITokenManager tokenManager,
        IBankService bankService) : base(tokenManager)
    {
        _bankService = bankService;
    }

    /// <summary>
    ///  银行添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task BankCreate([FromBody]BankInput input)
    {
        await _bankService.BankCreate(input);
    }
    
    /// <summary>
    ///  银行修改
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task BankUpdate([FromBody]BankInput input)
    {
        await _bankService.BankCreate(input);
    }

    /// <summary>
    ///  银行删除
    /// </summary>
    /// <param name="bankId"></param>
    [HttpPost]
    public async Task BankDelete([FromBody]long bankId)
    {
        await _bankService.BankDelete(bankId, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取银行信息
    /// </summary>
    /// <param name="bankId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<BankDto> GetBankById([FromQuery]long bankId)
    {
        return await _bankService.GetBankById(bankId);
    }

    /// <summary>
    ///  获取银行列表信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<BankDto>> GetBankPagedList([FromQuery]BankPagedInput input)
    {
        return await _bankService.GetBankPagedList(input);
    }

    /// <summary>
    ///  获取可选银行
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<BankSelectDto>> GetBankList()
    {
        return await _bankService.GetBankList();
    }

    /// <summary>
    ///  银行启用
    /// </summary>
    /// <param name="bankIds"></param>
    [HttpPost]
    public async Task BankEnable([FromBody]List<long> bankIds)
    {
        await _bankService.BankEnable(bankIds);
    }

    /// <summary>
    ///  银行禁用
    /// </summary>
    /// <param name="bankIds"></param>
    [HttpPost]
    public async Task BankDisabled(List<long> bankIds)
    {
        await _bankService.BankDisabled(bankIds);
    }
}