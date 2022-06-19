using Credit.BankModels;
using Credit.PayeeBankCardServices.Dtos;
using Credit.PayeeInfoModels;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.PayeeBankCardServices;

/// <summary>
///  收款银行卡方法实现
/// </summary>
public class PayeeBankCardService : IPayeeBankCardService
{
    private readonly IFreeSql _freeSql;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="freeSql"></param>
    public PayeeBankCardService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  收款银行卡信息验证
    /// </summary>
    /// <param name="input"></param>
    private async Task<string> PayeeBankCardVerify(PayeeBankCardInput input)
    {
        if (input.BankId == 0)
            throw new MyException("Please select a bank");
        if (string.IsNullOrEmpty(input.CardNo))
            throw new MyException("Please enter bank card number");
        if (string.IsNullOrEmpty(input.BindRealName))
            throw new MyException("Please enter the real name of the bank card");
        if (input.MinPayeeAmount <= 0)
            throw new MyException("Please enter a minimum payment amount");
        if (input.MaxPayeeAmount <= 0)
            throw new MyException("Please enter a maximum payment amount");
        if (input.MinPayeeAmount > input.MaxPayeeAmount)
            throw new MyException("The minimum payment amount of the bank card cannot be greater than the maximum payment amount");
        if (input.StartTime > input.EndTime)
            throw new MyException("The opening time of the bank card cannot be greater than the closing time");
        //银行信息
        var bank = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id == input.BankId)
            .Where(s => s.IsEnable == 1 && s.IsDeleted == 0)
            .ToOneAsync();
        if (bank == null)
            throw new MyException("Please select another bank");
        return bank.BankName;
    }

    /// <summary>
    ///  收款银行卡添加
    /// </summary>
    /// <param name="input"></param>
    public async Task PayeeBankCardCreate(PayeeBankCardInput input)
    {
        var bankName = await PayeeBankCardVerify(input);
        
        var payeeBankCard = input.MapTo<PayeeBankCard>();
        payeeBankCard.Id = IdHelper.GetId();
        payeeBankCard.BankName = bankName;
        await _freeSql.Insert(payeeBankCard).ExecuteAffrowsAsync();
    }
    
    /// <summary>
    ///  收款银行卡更新信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PayeeBankCardUpdate(PayeeBankCardInput input)
    {
        var bankName = await PayeeBankCardVerify(input);
        var payeeBankCard = await _freeSql.Select<PayeeBankCard>()
            .Where(s => s.Id == input.Id)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        //赋值
        payeeBankCard.BankAddress = input.BankAddress;
        payeeBankCard.BankId = input.BankId;
        payeeBankCard.BankName = bankName;
        payeeBankCard.BindRealName = input.BindRealName;
        payeeBankCard.CardNo = input.CardNo;
        payeeBankCard.StartTime = input.StartTime;
        payeeBankCard.EndTime = input.EndTime;
        payeeBankCard.MinPayeeAmount = input.MinPayeeAmount;
        payeeBankCard.MaxPayeeAmount = input.MaxPayeeAmount;
        payeeBankCard.IsEnable = input.IsEnable;
        await _freeSql.Update<PayeeBankCard>(payeeBankCard).ExecuteAffrowsAsync();
    }
    
    /// <summary>
    ///  删除收款银行卡信息
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    public async Task PayeeBankCardDelete(long bankCardId, long deleteUserId)
    {
        var payeeBankCard = await _freeSql.Select<PayeeBankCard>()
            .Where(s => s.Id == bankCardId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (payeeBankCard == null)
            throw new MyException("Delete information does not exist");
        payeeBankCard.IsDeleted = 1;
        payeeBankCard.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        payeeBankCard.DeleteUserId = deleteUserId;
        await _freeSql.Update<PayeeBankCard>(payeeBankCard).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  启用收款银行卡
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <returns></returns>
    public async Task PayeeBankCardEnable(List<long> bankCardIds)
    {
        var bankCards = await _freeSql.Select<PayeeBankCard>()
            .Where(s => bankCardIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        bankCards.ForEach(item =>
        {
            item.IsEnable = 1;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<PayeeBankCard>(bankCards).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  禁用收款银行卡
    /// </summary>
    /// <param name="bankCardIds"></param>
    public async Task PayeeBankCardDisabled(List<long> bankCardIds)
    {
        var bankCards = await _freeSql.Select<PayeeBankCard>()
            .Where(s => bankCardIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        bankCards.ForEach(item =>
        {
            item.IsEnable = 0;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<PayeeBankCard>(bankCards).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取收款银行卡信息
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    public async Task<PayeeBankCardDto> GetPayeeBankCardById(long bankCardId)
    {
        var bankCard = await _freeSql.Select<PayeeBankCard>()
            .Where(s => s.Id == bankCardId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        return bankCard.MapTo<PayeeBankCardDto>();
    }

    /// <summary>
    /// 获取可用的收款银行卡信息
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    public async Task<PayeeBankCardSelectDto> GetAvailablePayeeBankCards(decimal? amount = null,long? bankCardId = null)
    {
        var now = DateTime.UtcNow;
        var nowSpan = new TimeSpan(now.Hour,now.Minute,now.Second);
        var sql = _freeSql.Select<PayeeBankCard>()
            .WhereIf(amount > 0, s => s.MinPayeeAmount <= amount && s.MaxPayeeAmount >= amount)
            .WhereIf(bankCardId.HasValue, s => s.Id == bankCardId)
            .Where(s => nowSpan >= s.StartTime && nowSpan <= s.EndTime)
            .Where(s => s.IsEnable == 1)
            .Where(s => s.IsDeleted == 0)
            .OrderByRandom()
            .ToSql();
        var bankCard = await _freeSql.Select<PayeeBankCard>()
            .WhereIf(amount > 0,s => s.MinPayeeAmount <= amount && s.MaxPayeeAmount >= amount)
            .WhereIf(bankCardId.HasValue, s => s.Id == bankCardId)
            .Where(s => nowSpan >= s.StartTime && nowSpan <= s.EndTime)
            .Where(s => s.IsEnable == 1)
            .Where(s => s.IsDeleted == 0)
            .OrderByRandom()
            .ToOneAsync();

        return bankCard.MapTo<PayeeBankCardSelectDto>();
    }

    /// <summary>
    ///  获取收款银行卡信息列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<PayeeBankCardDto>> GetPayeeBankCardPagedList(PayeeBankCardPagedInput input)
    {
        var list = await _freeSql.Select<PayeeBankCard>()
            .WhereIf(input.BankId.HasValue, s => s.BankId == input.BankId)
            .WhereIf(input.StartTime.HasValue, s => s.StartTime >= input.StartTime)
            .WhereIf(input.EndTime.HasValue, s => s.EndTime <= input.EndTime)
            .Where(s => s.IsDeleted == 0)
            .Count(out long totalCount)
            .OrderByDescending(s => s.UpdateAt)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<PayeeBankCardDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<PayeeBankCardDto>()
        };

        return output;
    }
}