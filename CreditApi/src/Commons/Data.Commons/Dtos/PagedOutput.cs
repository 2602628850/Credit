namespace Data.Commons.Dtos;

[Serializable]
public class PagedListOutput<T>
{
    public PagedListOutput()
    {
        Items = new List<T>();
    }
    
    /// <summary>
    /// 数据
    /// </summary>
    public List<T> Items { get; set; }
}

[Serializable]
public class PagedOutput<T> : PagedListOutput<T>
{
    /// <summary>
    ///  总条数
    /// </summary>
    public long TotalCount { get; set; }
}
