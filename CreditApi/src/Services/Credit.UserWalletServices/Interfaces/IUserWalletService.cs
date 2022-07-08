using Credit.UserWalletServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Enums;

namespace Credit.UserWalletServices;

/// <summary>
///  用户钱包资金变动方法定义
/// </summary>
public interface IUserWalletService
{
    /// <summary>
    ///  资金变动申请
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<string> MoneyApplyCreate(MoneyApplyInput input,long userId);

    /// <summary>
    ///  资金变动申请列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<MoneyApplyDto>> GetMoneyApplyPagedList(MoneyApplyPagedInput input);
    
    /// <summary>
    ///  资金变动申请审核
    /// </summary>
    /// <param name="input"></param>
    /// <param name="auditUserId"></param>
    /// <returns></returns>
    Task MoneyApplyAudit(MoneyApplyAuditInput input,long auditUserId);

    /// <summary>
    ///  资金变动记录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    void WalletRecordCreate(UserWalletRecordInput input);


    /// <summary>
    ///  获取资金变动列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<UserWalletRecordDto>> GetUserWalletRecordPagedList(WalletRecordPagedInput input);
    /// <summary>
    ///  获取当前用户当年的所有提现记录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<List<MoneyApplyDto>> GetMoneyApplyRecode(long userid);

}