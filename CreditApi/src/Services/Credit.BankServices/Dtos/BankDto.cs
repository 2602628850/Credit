namespace Credit.BankServices.Dtos;

/// <summary>
///  银行Dto
/// </summary>
public class BankDto :BankInput
{
    /// <summary>
    ///  更新时间
    /// </summary>
    public long UpdateAt { get; set; }
}

/// <summary>
///  银行输入
/// </summary>
public class BankInput
{
    /// <summary>
    ///   银行Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    ///  银行编码
    /// </summary>
    public string BankCode { get; set; } = string.Empty;

    /// <summary>
    ///  银行Logo
    /// </summary>
    public string Logo { get; set; } = string.Empty;

    /// <summary>
    ///  是否启用 0 启用  1禁用
    /// </summary>
    public int IsEnable { get; set; }
}

/// <summary>
///  银行选择DTO
/// </summary>
public class BankSelectDto
{
    /// <summary>
    ///  银行Id
    /// </summary>
    public long  BankId { get; set; }

    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;
}