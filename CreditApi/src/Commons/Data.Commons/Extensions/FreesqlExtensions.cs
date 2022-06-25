using Data.Commons.Runtime;
using FreeSql;

namespace Data.Commons.Extensions;

/// <summary>
/// 
/// </summary>
public enum TableTimeFormat
{
    /// <summary>
    /// 根据月份格式化
    /// </summary>
    Month,
    /// <summary>
    /// 根据年份格式化
    /// </summary>
    Year,
}

/// <summary>
///  freeSql扩展
/// </summary>
public static class FreesqlExtensions
{
    /// <summary>
    /// 根据时间范围查询分表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="format">查询分表格式, 例如: "yyyyMM"</param>
    /// <param name="timeStart">开始时间</param>
    /// <param name="timeEnd">结束时间</param>
    /// <returns></returns>
    public static ISelect<T> WhereTableTime<T>(this ISelect<T> query,TableTimeFormat format,long timeStart = 0,long timeEnd = 0)
    {
        if (timeStart > timeEnd)
            throw new MyException("开始时间不能大于结束时间");
        if (timeStart == 0)
            timeStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        if (timeEnd == 0)
            timeEnd = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var datetimeStart = DateTimeOffset.FromUnixTimeMilliseconds(timeStart);
        var datetimeEnd = DateTimeOffset.FromUnixTimeMilliseconds(timeEnd);
    
        if (format == TableTimeFormat.Month)
        {
            for (var i = 0; i < 12; i++)
            {
                var datetimeStartStr = datetimeStart.AddMonths(i).Date.ToString("yyyyMM");
                var datetimeEndStr = datetimeEnd.Date.ToString("yyyyMM");
    
                query = query.AsTable((type, table) => $"{table}_{datetimeStartStr}");
                if (datetimeStartStr == datetimeEndStr)
                    break;
            }
        }
        else if (format == TableTimeFormat.Year)
        {
            for (var i = 0; i < 3; i++)
            {
                var datetimeStartStr = datetimeStart.AddYears(i).Date.ToString("yyyy");
                var datetimeEndStr = datetimeEnd.Date.ToString("yyyy");
    
                query = query.AsTable((type, table) => $"{table}_{datetimeStartStr}");
                if (datetimeStartStr == datetimeEndStr)
                    break;
            }
        }
        return query;
    }

    /// <summary>
    ///  根据创建时间修改数据
    /// </summary>
    /// <param name="update"></param>
    /// <param name="format"></param>
    /// <param name="createAt"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IUpdate<T> UpdateTableTime<T>(this IUpdate<T> update,TableTimeFormat format,long createAt)
    {
        var tableTime = DateTimeOffset.FromUnixTimeMilliseconds(createAt);
        var suffix = string.Empty;
        if (format == TableTimeFormat.Month)
        {
            suffix = tableTime.ToString("yyyyMM");
        }
        else
        {
            suffix = tableTime.ToString("yyyy");
        }
        return update.AsTable(table => $"{table}_{suffix}");
    }

    /// <summary>
    /// 创建数据
    /// </summary>
    /// <param name="insert"></param>
    /// <param name="format"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IInsert<T> InsertTableTime<T>(this IInsert<T> insert,TableTimeFormat format) where T : class
    {
        var uctNow = DateTimeOffset.UtcNow;
        var suffix = string.Empty;
        if (format == TableTimeFormat.Month)
        {
            suffix = uctNow.ToString("yyyyMM");
        }
        else
        {
            suffix = uctNow.ToString("yyyy");
        }
        return insert.AsTable(table => $"{table}_{suffix}");
    }
}