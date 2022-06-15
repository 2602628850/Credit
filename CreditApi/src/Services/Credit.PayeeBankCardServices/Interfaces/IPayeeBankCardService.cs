using Credit.PayeeBankCardServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.PayeeBankCardServices;

/// <summary>
///  收款银行卡方法定义
/// </summary>
public interface IPayeeBankCardService
{
    /// <summary>
    ///  收款银行卡添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task PayeeBankCardCreate(PayeeBankCardInput input);

    /// <summary>
    ///  收款银行卡编辑
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task PayeeBankCardUpdate(PayeeBankCardInput input);

    /// <summary>
    ///  收款银行卡删除
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task PayeeBankCardDelete(long bankCardId, long deleteUserId);

    /// <summary>
    ///  启用收款银行卡
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <returns></returns>
    Task PayeeBankCardEnable(List<long> bankCardIds);

    /// <summary>
    ///  关闭收款银行卡
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <returns></returns>
    Task PayeeBankCardDisabled(List<long> bankCardIds);

    /// <summary>
    ///  获取收款银行卡信息
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    Task<PayeeBankCardDto> GetPayeeBankCardById(long bankCardId);

    /// <summary>
    ///  
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    Task<PayeeBankCardSelectDto> GetAvailablePayeeBankCards(decimal? amount = null,long? bankCardId = null);

    /// <summary>
    ///  获取收款银行信息卡列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<PayeeBankCardDto>> GetPayeeBankCardPagedList(PayeeBankCardPagedInput input);
}