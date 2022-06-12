using Data.Commons.Dtos;

namespace Credit.PayeeBankCardServices.Dtos;

public class PayeeBankCardPagedInput : PagedInput
{
    /// <summary>
    ///  银行Id
    /// </summary>
    public long? BankId { get; set; }
    
    /// <summary>
    ///  开启时间
    /// </summary>
    public TimeSpan? StartTime { get; set; }

    /// <summary>
    ///  关闭时间
    /// </summary>
    public TimeSpan? EndTime { get; set; }
}