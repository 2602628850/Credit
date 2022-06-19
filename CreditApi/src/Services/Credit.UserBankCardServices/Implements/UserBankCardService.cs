using Credit.BankModels;
using Credit.UserBankCardModels;
using Credit.UserBankCardServices.Dtos;
using Credit.UserModels;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.UserBankCardServices;

/// <summary>
///  用户银行卡方法实现
/// </summary>
public class UserBankCardService : IUserBankCardService
{
    private readonly IFreeSql _freeSql;

    public UserBankCardService(IFreeSql freeSql)
    {
        _freeSql = freeSql;
    }

    /// <summary>
    ///  绑定银行卡
    /// </summary>
    /// <param name="input"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task UserBankCardCreate(BindBankCardInput input,long userId)
    {
        var userAny = await _freeSql.Select<Users>()
            .Where(s => s.IsAdmin == 0 && s.IsDeleted == 0)
            .Where(s => s.Id == userId)
            .AnyAsync();
        if (!userAny)
            throw new MyException("Please login again");
        if (string.IsNullOrEmpty(input.CardNo))
            throw new MyException("Please enter the card number");
        if (string.IsNullOrEmpty(input.BindUser))
            throw new MyException("Please enter your real name");
        var bankAny = await _freeSql.Select<BankInfo>()
            .Where(s => s.IsEnable == 1 && s.IsDeleted == 0 && s.Id == input.BankId)
            .AnyAsync();
        if (!bankAny)
            throw new MyException("Please select a bank");
        var bankCards = await GetUserBankCardList(userId);
        if (bankCards.Count >= 5)
            throw new MyException("Up to 5 bank cards can be bound");
        var userBankCard = new UserBankCard
        {
            Id = IdHelper.GetId(),
            BankId = input.BankId,
            BankBranch = input.BankBranch,
            BindUser = input.BindUser,
            UserId = userId,
            CardNo = input.CardNo
        };
        await _freeSql.Insert(userBankCard).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///  接触银行卡绑定
    /// </summary>
    /// <param name="bankCardId"></param>
    /// <param name="userId"></param>
    public async Task UserBankCardDelete(long bankCardId, long userId)
    {
        var bankCard = await _freeSql.Select<UserBankCard>()
            .Where(s => s.Id == bankCardId && s.UserId == userId)
            .Where(s => s.IsDeleted == 0)
            .ToOneAsync();
        if (bankCard == null)
            throw new MyException("Bank card does not exist");
        bankCard.IsDeleted = 1;
        bankCard.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        bankCard.DeleteUserId = userId;
        await _freeSql.Update<UserBankCard>(bankCard).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///   获取用户银行卡
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="bankCardId"></param>
    /// <returns></returns>
    public async Task<List<UserBankCardDto>> GetUserBankCardList(long userId, long bankCardId = 0)
    {
        var bankCards = await _freeSql.Select<UserBankCard>()
            .WhereIf(bankCardId > 0, s => s.Id == bankCardId)
            .Where(s => s.UserId == userId)
            .Where(s => s.IsDeleted == 0)
            .ToListAsync();
        return bankCards.MapToList<UserBankCardDto>();
    }
}