using Credit.CreditLevelServices.Dtos;
using Credit.CreditLevelServices.Interfaces;
using Credit.TeamServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Data.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;
/// <summary>
/// 信用等级后台设置
/// </summary>
public class AdminCreditLevelController : BaseAdminController
{
    private readonly ICreditLevelService _creditService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenManager"></param>
    /// <param name="creditService"></param>
    public AdminCreditLevelController(ITokenManager tokenManager
        , ICreditLevelService creditService) : base(tokenManager)
    {
        _creditService = creditService;
    }
    #region 信用等级

    /// <summary>
    ///  信用等级添加
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task CreditLevelCreate([FromBody] CreditLevelInput input)
    {
        await _creditService.CreditLevelCreate(input);
    }

    /// <summary>
    ///  信用等级编辑
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task CreditLevelUpdate([FromBody] CreditLevelInput input)
    {
        await _creditService.CreditLevelUpdate(input);
    }

    /// <summary>
    ///  信用等级删除
    /// </summary>
    /// <param name="input"></param>
    [HttpPost]
    public async Task CreditLevelDelete([FromBody] IdInput input)
    {
        await _creditService.CreditLevelDelete(input.Id, CurrentAdmin.UserId);
    }

    /// <summary>
    ///  获取信用等级
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<CreditLevelDto> GetCreditLevel([FromQuery] IdInput input)
    {
        return await _creditService.GetCreditLevel(input.Id);
    }

    /// <summary>
    ///  获取信用等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedOutput<CreditLevelDto>> GetCreditLevelPagedList(CreditLevelPagedInput input)
    {
        return await _creditService.GetCreditLevelPagedList(input);
    }
     

    #endregion

}
