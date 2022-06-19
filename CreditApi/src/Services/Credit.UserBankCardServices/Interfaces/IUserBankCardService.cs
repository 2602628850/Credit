using Credit.UserBankCardServices.Dtos;

namespace Credit.UserBankCardServices;

/// <summary>
///  用户银行卡方法定义
/// </summary>
public interface IUserBankCardService
{
    /// <summary>
    ///  绑定银行卡
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task UserBankCardCreate(BindBankCardInput input,long userId);

    /// <summary>
    ///   删除银行卡
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task UserBankCardDelete(long bankCardId,long userId);

    /// <summary>
    /// 获取用户绑定银行卡
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    Task<List<UserBankCardDto>> GetUserBankCardList(long userId,long bankCardId = 0);
}