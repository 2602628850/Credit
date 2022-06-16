using Credit.UserWalletServices.Dtos;

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
    Task MoneyApplyCreate(MoneyApplyInput input,long userId);
}