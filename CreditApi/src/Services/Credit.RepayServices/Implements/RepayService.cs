using Credit.BankModels;
using Credit.RepayModels;
using Credit.RepayServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.RepayServices;

/// <summary>
///  还款管理方法实现
/// </summary>
public class RepayService : IRepayService
{
    private readonly IFreeSql _freeSql;

    public RepayService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    #region 还款等级

     /// <summary>
    ///  还款等级信息验证
    /// </summary>
    /// <param name="input"></param>
    private void RepayLevelVerify(RepayLevelInput input)
    {
        if (string.IsNullOrEmpty(input.LevelName))
            throw new MyException("Please enter a name");
        if (input.UnlockBalance < 0)
            throw new MyException("Unlock balance must be greater than or equal to 0");
        if (input.ProfitRate < 0)
            throw new MyException("Profit ratio must be greater than or equal to 0");
        if (input.MinRepayAmount <= 0)
            throw new MyException("Minimum repayment amount must be greater than 0");
        if (input.MaxRepayAmount <= input.MinRepayAmount)
            throw new MyException("The maximum repayment amount must be greater than the minimum repayment amount");
        if (string.IsNullOrEmpty(input.Introduction))
            throw new MyException("Please enter an introduction");
    }

    /// <summary>
    ///  还款等级添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task RepayLevelCreate(RepayLevelInput input)
    {
        RepayLevelVerify(input);
        var level = input.MapTo<RepayLevel>();
        level.Id = IdHelper.GetId();
        await _freeSql.Insert(level).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级编辑
    /// </summary>
    /// <param name="input"></param>
    public async Task RepayLevelUpdate(RepayLevelInput input)
    {
        RepayLevelVerify(input);
        var level = await _freeSql.Select<RepayLevel>()
            .Where(s => s.Id == input.Id)
            .ToOneAsync();
        if (level == null)
            throw new MyException("No data found");
        level.LevelName = input.LevelName;
        level.UnlockBalance = input.UnlockBalance;
        level.Introduction = input.Introduction;
        level.MinRepayAmount = input.MinRepayAmount;
        level.CoverImage = input.CoverImage;
        level.MaxRepayAmount = input.MaxRepayAmount;
        level.ProfitRate = input.ProfitRate;
        level.IsEnable = input.IsEnable;
        level.UpdateAt = DateTimeHelper.UtcNow();
        await _freeSql.Update<RepayLevel>().SetSource(level).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级删除
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <param name="deleteUserId"></param>
    /// <returns></returns>
    public async Task RepayLevelDelete(List<long> repayLevelIds, long deleteUserId)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsDeleted = 1;
            item.DeleteUserId = deleteUserId;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级启用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    public async Task RepayLevelEnable(List<long> repayLevelIds)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsEnable = 1;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款等级禁用
    /// </summary>
    /// <param name="repayLevelIds"></param>
    /// <returns></returns>
    public async Task RepayLevelDisable(List<long> repayLevelIds)
    {
        var levels = await _freeSql.Select<RepayLevel>()
            .Where(s => repayLevelIds.Contains(s.Id))
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        levels.ForEach(item =>
        {
            item.IsEnable = 0;
            item.UpdateAt = utcNow;
        });
        await _freeSql.Update<RepayLevel>().SetSource(levels).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  获取还款等级
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    public async Task<RepayLevelDto> GetRepayLevel(long repayLevelId)
    {
        var level = await _freeSql.Select<RepayLevel>()
            .Where(s => s.Id == repayLevelId)
            .ToOneAsync();
        return level.MapTo<RepayLevelDto>();
    }

    /// <summary>
    ///  获取还款等级集合
    /// </summary>
    /// <param name="isEnable"></param>
    /// <returns></returns>
    public async Task<List<RepayLevelDto>> GetRepayLevelList(int isEnable = 1)
    {
        var list = await _freeSql.Select<RepayLevel>()
            .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
            .ToListAsync();
        return list.MapToList<RepayLevelDto>();
    }

    /// <summary>
    ///   获取还款等级列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<RepayLevelDto>> GetRepayLevelPagedList(RepayLevelPagedInput input)
    {
        var list = await _freeSql.Select<RepayLevel>()
            .WhereIf(!string.IsNullOrEmpty(input.LevelName), s => s.LevelName.Contains(input.LevelName))
            .Where(s => s.IsDeleted == 0)
            .Count(out long totalCount)
            .OrderByDescending(s => s.CreateAt)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<RepayLevelDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<RepayLevelDto>()
        };

        return output;
    }


    #endregion
    
    #region 还款银行卡

    /// <summary>
    ///  还款银行卡信息验证
    /// </summary>
    /// <param name="input"></param>
    private async Task<string> RepayBankCardVerify(RepayBankCardInput input)
    {
        if (input.BankId == 0)
            throw new MyException("Please select a bank");
        var bank = await _freeSql.Select<BankInfo>()
            .Where(s => s.Id == input.BankId)
            .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
            .ToOneAsync();
        if (bank == null)
            throw new MyException("Please select another bank");
        if (input.RepayLevelId == 0)
            throw new MyException("Please select a level");
        var level = await _freeSql.Select<RepayLevel>()
            .Where(s => s.Id == input.RepayLevelId)
            .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
            .ToOneAsync();
        if (level == null)
            throw new MyException("Please select another level");
        if (input.Amount < level.MinRepayAmount || input.Amount > level.MaxRepayAmount)
            throw new MyException($"Repayment amount {level.MinRepayAmount} - {level.MaxRepayAmount}.");
        if (string.IsNullOrEmpty(input.CardNo))
            throw new MyException("Please enter the card number");
        if (string.IsNullOrEmpty(input.BindUser))
            throw new MyException("Please enter the name of the bank card binding person");
        if (input.Amount <= 0)
            throw new MyException("Repayment amount must be greater than 0");

        return bank.BankName;
    }

    /// <summary>
    ///  还款银行卡添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task RepayBankCardCreate(RepayBankCardInput input)
    {
        var bankName = await RepayBankCardVerify(input);
        var bankCard = input.MapTo<RepayBankCard>();
        bankCard.Id = IdHelper.GetId();
        bankCard.BankName = bankName;
        await _freeSql.Insert(bankCard).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款银行卡编辑
    /// </summary>
    /// <param name="input"></param>
    public async Task RepayBankCardUpdate(RepayBankCardInput input)
    {
        var bankName = await RepayBankCardVerify(input);
        var bankCard = await _freeSql.Select<RepayBankCard>()
            .Where(s => s.Id == input.Id)
            .ToOneAsync();
        if (bankCard == null)
            throw new MyException("Data error");
        bankCard.BankId = input.BankId;
        bankCard.BankName = bankName;
        bankCard.CardNo = input.CardNo;
        bankCard.Amount = input.Amount;
        bankCard.BindUser = input.BindUser;
        bankCard.IsEnable = input.IsEnable;
        bankCard.RepayLevelId = input.RepayLevelId;

        await _freeSql.Update<RepayBankCard>()
            .SetSource(bankCard)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款银行卡删除
    /// </summary>
    /// <param name="bankCardIds"></param>
    /// <param name="deleteUserId"></param>
    public async Task RepayBankCardDelete(List<long> bankCardIds, long deleteUserId)
    {
        var bankCards = await _freeSql.Select<RepayBankCard>()
            .Where(s => bankCardIds.Contains(s.Id))
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        bankCards.ForEach(item =>
        {
            item.IsDeleted = 1;
            item.DeleteUserId = deleteUserId;
            item.UpdateAt = utcNow;
        });

        await _freeSql.Update<RepayBankCard>()
            .SetSource(bankCards)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款银行卡启用
    /// </summary>
    /// <param name="bankCardIds"></param>
    public async Task RepayBankCardEnable(List<long> bankCardIds)
    {
        var bankCards = await _freeSql.Select<RepayBankCard>()
            .Where(s => bankCardIds.Contains(s.Id))
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        bankCards.ForEach(item =>
        {
            item.IsEnable = 1;
            item.UpdateAt = utcNow;
        });

        await _freeSql.Update<RepayBankCard>()
            .SetSource(bankCards)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  还款银行卡停用
    /// </summary>
    /// <param name="bankCardIds"></param>
    public async Task RepayBankCardDisable(List<long> bankCardIds)
    {
        var bankCards = await _freeSql.Select<RepayBankCard>()
            .Where(s => bankCardIds.Contains(s.Id))
            .ToListAsync();
        var utcNow = DateTimeHelper.UtcNow();
        bankCards.ForEach(item =>
        {
            item.IsEnable = 0;
            item.UpdateAt = utcNow;
        });

        await _freeSql.Update<RepayBankCard>()
            .SetSource(bankCards)
            .ExecuteAffrowsAsync();
    }

    /// <summary>
    ///   获取还款银行卡
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    public async Task<RepayBankCardDto> GetRepayBankCard(long bankCardId)
    {
        var data = await _freeSql.Select<RepayBankCard>()
            .Where(s => s.Id == bankCardId)
            .ToOneAsync();
        return data.MapTo<RepayBankCardDto>();
    }

    /// <summary>
    ///  获取还款银行卡
    /// </summary>
    /// <param name="repayLevelId"></param>
    /// <returns></returns>
    public async Task<List<RepayBankCardDto>> GetRepayBankCardList(long repayLevelId)
    {
        var list = await _freeSql.Select<RepayBankCard>()
            .WhereIf(repayLevelId > 0, s => s.RepayLevelId == repayLevelId)
            .Where(s => s.IsDeleted == 0 && s.IsEnable == 1)
            .OrderByRandom()
            .Limit(5)
            .ToListAsync();
        //页面显示卡号的时候取8位数字
        for(int i=0;i< list.Count; i++)
        {
            if (list[i].CardNo.Length > 8)
            {
                list[i].CardNo = list[i].CardNo.Substring(0, 8);
            }
        }
        return list.MapToList<RepayBankCardDto>();
    }

    /// <summary>
    ///  获取还款银行卡列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedOutput<RepayBankCardDto>> GetRepayBankCardPagedList(RepayBankCardPagedInput input)
    {
        var list = await _freeSql.Select<RepayBankCard>()
            .WhereIf(input.BankId.HasValue, s => s.BankId == input.BankId)
            .WhereIf(input.RepayLevelId.HasValue, s => s.RepayLevelId == input.RepayLevelId)
            .WhereIf(!string.IsNullOrEmpty(input.BindUser), s => s.BindUser.Contains(input.BindUser))
            .WhereIf(input.IsEnable.HasValue, s => s.IsEnable == input.IsEnable)
            .Where(s => s.IsDeleted == 0)
            .OrderByDescending(s => s.CreateAt)
            .Count(out long totalCount)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
        var output = new PagedOutput<RepayBankCardDto>
        {
            TotalCount = totalCount,
            Items = list.MapToList<RepayBankCardDto>()
        };

        return output;
    }

    #endregion
}