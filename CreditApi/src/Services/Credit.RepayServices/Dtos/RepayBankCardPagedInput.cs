using Data.Commons.Dtos;
using Data.Commons.Enums;

namespace Credit.RepayServices.Dtos;

/// <summary>
///  还款银行卡列表输入
/// </summary>
public class RepayBankCardPagedInput : PagedInput
{
    /// <summary>
    ///  银行Id
    /// </summary>
    public long? BankId { get; set; }

    /// <summary>
    ///  还款等级Id
    /// </summary>
    public long? RepayLevelId { get; set; }

    /// <summary>
    ///  卡号绑定人
    /// </summary>
    public string BindUser { get; set; }

    /// <summary>
    ///   启用状态
    /// </summary>
    public int? IsEnable { get; set; }
    
    /// <summary>
    ///  还款类型
    /// </summary>
    public RepayTypeEnums? RepayType { get; set; }
}