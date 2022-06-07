namespace Data.Commons.Dtos;

public class PagedInput
{
    /// <summary>
    ///  页码
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    ///  每页条数
    /// </summary>
    public int PageSize { get; set; } = 30;
}