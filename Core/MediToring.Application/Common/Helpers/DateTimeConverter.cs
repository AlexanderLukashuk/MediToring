namespace MediToring.Application.Common.Helpers;

public static class DateTimeConverter
{
    public static DateTime ConvertToUtc(DateTime dateTime)
    {
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }

    public static (DateTime StartTimeUtc, DateTime EndTimeUtc) ConvertToUtc(DateTime startTime, DateTime endTime)
    {
        var startTimeUtc = ConvertToUtc(startTime);
        var endTimeUtc = ConvertToUtc(endTime);
        return (startTimeUtc, endTimeUtc);
    }
}