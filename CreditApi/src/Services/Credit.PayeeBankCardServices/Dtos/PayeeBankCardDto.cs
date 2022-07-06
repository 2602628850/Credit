namespace Credit.PayeeBankCardServices.Dtos;

/// <summary>
///  收款银行卡信息
/// </summary>
public class PayeeBankCardDto : PayeeBankCardInput
{
    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;
    
    /// <summary>
    ///  最后修改时间
    /// </summary>
    /// <returns></returns>
    public long UpdateAt { get; set; }
}

/// <summary>
///  收款银行卡输入
/// </summary>
public class PayeeBankCardInput
{
    /// <summary>
    ///  
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }
    
    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  银行卡绑定姓名
    /// </summary>
    public string BindRealName { get; set; } = string.Empty;

    /// <summary>
    ///   开户行地址
    /// </summary>
    public string BankAddress { get; set; } = string.Empty;

    /// <summary>
    ///  最低收款金额
    /// </summary>
    public decimal MinPayeeAmount { get; set; }

    /// <summary>
    ///  最高收款金额
    /// </summary>
    public decimal MaxPayeeAmount { get; set; }

    /// <summary>
    ///   开启时间
    /// </summary>
    public TimeSpan StartTime { get; set; } = new TimeSpan(00, 00, 00);

    /// <summary>
    ///   关闭时间
    /// </summary>
    public TimeSpan EndTime { get; set; } = new TimeSpan(23,59,59);

    /// <summary>
    ///  是否启动
    /// </summary>
    public int IsEnable { get; set; }
}

/// <summary>
///  收款银行卡选择
/// </summary>
public class PayeeBankCardSelectDto
{
    /// <summary>
    ///  
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///  银行Id
    /// </summary>
    public long BankId { get; set; }
    
    /// <summary>
    ///  卡号
    /// </summary>
    public string CardNo { get; set; } = string.Empty;

    /// <summary>
    ///  银行卡绑定姓名
    /// </summary>
    public string BindRealName { get; set; } = string.Empty;

    /// <summary>
    ///   开户行地址
    /// </summary>
    public string BankAddress { get; set; } = string.Empty;

    /// <summary>
    ///  银行名称
    /// </summary>
    public string BankName { get; set; } = string.Empty;
}

/// <summary>
///  获取银行卡金额输入
/// </summary>
public class BankCardAmountInput
{
    /// <summary>
    ///  金额
    /// </summary>
    public decimal Amount { get; set; }
}
