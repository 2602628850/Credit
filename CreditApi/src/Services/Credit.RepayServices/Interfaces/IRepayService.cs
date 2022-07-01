using Credit.RepayServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.RepayServices;

/// <summary>
///  还款管理方法定义
/// </summary>
public interface IRepayService
{
    /// <summary>
    ///  还款等级添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayLevelCreate(RepayLevelInput input);

    /// <summary>
    ///  还款等级更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayLevelUpdate(RepayLevelInput input);

    /// <summary>
    ///  还款等级删除
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task RepayLevelDelete(List<long> repayLevelIds,long deleteUserId);

    /// <summary>
    ///  还款等级启用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    Task RepayLevelEnable(List<long> repayLevelIds);

    /// <summary>
    ///  还款等级禁用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    Task RepayLevelDisable(List<long> repayLevelIds);

    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    Task<RepayLevelDto> GetRepayLevel(long repayLevelId);

    /// <summary>
    ///  获取还款等级集合
    /// </summary>
    /// <param name="isEnable"></param>
    /// <returns></returns>
    Task<List<RepayLevelDto>> GetRepayLevelList(int isEnable = 1);

    /// <summary>
    ///  获取还款等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<RepayLevelDto>> GetRepayLevelPagedList(RepayLevelPagedInput input);

    /// <summary>
    ///  还款银行卡添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayBankCardCreate(RepayBankCardInput input);

    /// <summary>
    ///  还款银行卡编辑
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task RepayBankCardUpdate(RepayBankCardInput input);

    /// <summary>
    ///  还款银行卡删除
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task RepayBankCardDelete(List<long> bankCardIds,long deleteUserId);

    /// <summary>
    ///  还款银行卡启用
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <returns></returns>
    Task RepayBankCardEnable(List<long> bankCardIds);

    /// <summary>
    ///  还款银行卡停用
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <returns></returns>
    Task RepayBankCardDisable(List<long> bankCardIds);

    /// <summary>
    ///  主键获取还款银行卡
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    Task<RepayBankCardDto> GetRepayBankCard(long bankCardId);

    /// <summary>
    ///  等级获取还款银行卡
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    Task<List<RepayBankCardDto>> GetRepayBankCardList(long repayLevelId);

    /// <summary>
    ///  获取还款银行卡列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<RepayBankCardDto>> GetRepayBankCardPagedList(RepayBankCardPagedInput input);
}