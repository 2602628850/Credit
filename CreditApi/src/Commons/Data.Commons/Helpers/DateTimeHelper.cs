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
    ///  UtcÊ±¼ä´Á×ªDateTime
    /// </summary>
    /// <param name="unixTime"></param>
    /// <returns></returns>
    public static DateTime UnixTimeToDateTime(long unixTime)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddMilliseconds(unixTime).ToLocalTime();
        return dateTime;
    }
}