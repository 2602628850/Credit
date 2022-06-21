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
}