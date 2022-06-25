namespace Credit.OrderServices.Dtos;

/// <summary>
///  理财订单输出DTO
/// </summary>
public class FinancilOrderDto
{
    
}

/// <summary>
///  理财订单输入
/// </summary>
public class FinancilOrderInput
{
    /// <summary>
    ///  理财产品Id
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    ///  购买份数
    /// </summary>
    public int UnitCount { get; set; }
}