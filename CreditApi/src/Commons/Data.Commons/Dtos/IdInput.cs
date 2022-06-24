namespace Data.Commons.Dtos;

public class IdInput
{
    /// <summary>
    ///  主键Id
    /// </summary>
    public long Id { get; set; }
}

public class ListIdInput
{
    /// <summary>
    ///  主键Id集合
    /// </summary>
    public List<long> Ids { get; set; }
}