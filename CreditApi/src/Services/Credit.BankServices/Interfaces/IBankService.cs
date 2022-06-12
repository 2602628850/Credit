using Credit.BankServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.BankServices;

/// <summary>
///  银行管理方法定义
/// </summary>
public interface IBankService
{
    /// <summary>
    ///  银行添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task BankCreate(BankInput input);

    /// <summary>
    ///  银行更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task BankUpdate(BankInput input);

    /// <summary>
    ///  银行删除
    /// </summary>
    /// <param name="bankId"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    Task BankDelete(long bankId,long deleteUserId);

    /// <summary>
    ///  获取银行信息
    /// </summary>
    /// <param name="bankId"></param>
    /// <returns></returns>
    Task<BankDto> GetBankById(long bankId);

    /// <summary>
    ///  获取银行列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedOutput<BankDto>> GetBankPagedList(BankPagedInput input);

    /// <summary>
    ///  获取银行集合
    /// </summary>
    /// <returns></returns>
    Task<List<BankSelectDto>> GetBankList();

    /// <summary>
    ///  银行启用
    /// </summary>
    /// <param name="bankIds"></param>
    /// <returns></returns>
    Task BankEnable(List<long> bankIds);

    /// <summary>
    ///  银行禁用
    /// </summary>
    /// <param name="bankIds"></param>
    /// <returns></returns>
    Task BankDisabled(List<long> bankIds);
}