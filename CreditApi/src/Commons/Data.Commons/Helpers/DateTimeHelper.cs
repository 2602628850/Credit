namespace Data.Commons.Helpers;

public static class DateTimeHelper
{
    public static long DayStart()
    {
        var utcDate = DateTime.UtcNow.Date;
        return new DateTimeOffset(utcDate).ToUnixTimeMilliseconds();
    }

    public static long UtcNow()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    /// <summary>
    ///  Utc时间戳转DateTime
    /// </summary>
    /// <param name="unixTime"></param>
    /// <returns></returns>
    public static DateTime UnixTimeToDateTime(long unixTime)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddMilliseconds(unixTime).ToLocalTime();
        return dateTime;
    }
    /// <summary>
    /// 获取今天的开始时间
    /// </summary>
    /// <returns></returns>
    public static long GetToday()
    {
        var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Date;
        return new DateTimeOffset(now).ToUnixTimeMilliseconds();
    }
}