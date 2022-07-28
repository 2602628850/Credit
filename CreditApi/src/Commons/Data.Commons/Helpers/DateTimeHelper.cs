namespace Data.Commons.Helpers;

public static class DateTimeHelper
{
    public static long DayStart()
    {
        var utcDate = DateTime.UtcNow.Date;
        return new DateTimeOffset(utcDate).ToUnixTimeMilliseconds();
    }

    public static long WeekMondayStart()
    {
        var utcWeek = DateTime.UtcNow.AddDays(-Convert.ToInt32(DateTime.UtcNow.DayOfWeek) + 1).Date;
        return new DateTimeOffset(utcWeek).ToUnixTimeMilliseconds();
    }

    public static long UtcNow()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    /// <summary>
    ///  Utcʱ���תDateTime
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
    /// ��ȡ����Ŀ�ʼʱ��
    /// </summary>
    /// <returns></returns>
    public static long GetToday()
    {
        var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Date;
        return new DateTimeOffset(now).ToUnixTimeMilliseconds();
    }
    public static long GetTime(DateTime time)
    { 
        return new DateTimeOffset(time).ToUnixTimeMilliseconds();
    }

    public static long MonthStart()
    {
        var monthTime = DateTime.UtcNow.AddDays(1 - DateTime.UtcNow.Day).Date;
        return GetTime(monthTime);
    }

    public static long YearStart()
    {
        var yearTime = new DateTime(DateTime.UtcNow.Year, 1, 1);
        return GetTime(yearTime);
    }
}