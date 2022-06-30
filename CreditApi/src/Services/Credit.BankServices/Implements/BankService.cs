using Credit.BankModels;
using Credit.BankServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.BankServices;

/// <summary>
///  银行管理方法实现
/// </summary>
public class BankService : IBankService
{
    private readonly IFreeSql _freeSql;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    public BankService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  银行添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task BankCreate(BankInput input)
    {
        if (string.IsNullOrEmpty(input.BankName))
            throw new MyException("Please enter bank name");
        if (string.IsNullOrEmpty(input.BankCode))
            throw new MyException("Please enter bank code");
        var nameExist = await _freeSql.Select<BankInfo>()
                .Where(s => s.BankName == input.BankName)
                .Where(s => s.IsDeleted == 0)
                .AnyAsync();
        if (nameExist)
            throw new MyException("Bank name already exists");
        var bank = input.MapTo<BankInfo>();
        bank.Id = IdHelper.GetId();
        await _freeSql.Insert(bank).ExecuteAffrowsAsync();
    }
    
    /// <summary>
    ///  银行修改
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task BankUpdate(BankInput input)
    {
        if (string.IsNullOrEmpty(input.BankName))
            throw new MyException("Please enter bank name");
        if (string.IsNullOrEmpty(input.BankCode))
            throw new MyException("Please enter bank code");
        var bank = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id == input.Id)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (bank == null)
            throw new MyException("Edit data does not exist");
        var nameRepeat = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id != input.Id && s.BankName == input.BankName)
            .Where(s => s.IsDeleted == 0)
            .AnyAsync();
        if (nameRepeat)
            throw new MyException("Bank name already exists");
        bank.BankCode = input.BankCode;
        bank.BankName = input.BankName;
        bank.IsEnable = input.IsEnable;
        bank.Logo = input.Logo;
        bank.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        await _freeSql.Update<BankInfo>().SetSource(bank).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  银行删除
    /// </summary>
    /// <param name="bankId"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    public async Task BankDelete(long bankId, long deleteUserId)
    {
        var bank = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id == bankId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (bank == null)
            throw new MyException("Delete data does not exist");
        bank.IsDeleted = 1;
        bank.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        bank.DeleteUserId = deleteUserId;
        await _freeSql.Update<BankInfo>(bank).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取银行信息
    /// </summary>
    /// <param name="bankId"></param>
    /// <returns></returns>
    public async Task<BankDto> GetBankById(long bankId)
    {
        var bank = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id == bankId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync(s => new BankDto
            {
                Id = s.Id,
                BankName = s.BankName,
                BankCode = s.BankCode,
                IsEnable = s.IsEnable,
                Logo = s.Logo,
                UpdateAt = s.UpdateAt
            });
        return bank;
    }

    /// <summary>
    ///  获取银行列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<BankDto>> GetBankPagedList(BankPagedInput input)
    {
        var list = await _freeSql.Select<BankInfo>()
            .Where(s => s.IsDeleted == 0)
            .WhereIf(!string.IsNullOrEmpty(input.BankName), s => s.BankName.Contains(input.BankName))
            .WhereIf(input.IsEnable.HasValue, s => s.IsEnable == input.IsEnable)
            .Count(out long totalCouunt)
            .OrderByDescending(s => s.UpdateAt)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<BankDto>
        {
            TotalCount = totalCouunt,
            Items = list.MapToList<BankDto>()
        };
        return output;
    }

    /// <summary>
    ///  获取银行集合
    /// </summary>
    /// <returns></returns>
    public async Task<List<BankSelectDto>> GetBankList()
    {
        var list = await _freeSql.Select<BankInfo>()
            .Where(s => s.IsDeleted == 0)
            .Where(s => s.IsEnable == 1)
            .ToListAsync(s => new BankSelectDto
            {
                BankId = s.Id,
                BankName = s.BankName
            });
        return list;
    }

    /// <summary>
    ///  银行启用
    /// </summary>
    /// <param name="bankIds"></param>
    public async Task BankEnable(List<long> bankIds)
    {
        var banks = await _freeSql.Select<BankInfo>()
            .Where(s => bankIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        banks.ForEach(item =>
        {
            item.IsEnable = 1;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<BankInfo>(banks).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  银行禁用
    /// </summary>
    /// <param name="bankIds"></param>
    public async Task BankDisabled(List<long> bankIds)
    {
        var banks = await _freeSql.Select<BankInfo>()
            .Where(s => bankIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        banks.ForEach(item =>
        {
            item.IsEnable = 0;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<BankInfo>(banks).ExecuteAffrowsAsync();
    }
}