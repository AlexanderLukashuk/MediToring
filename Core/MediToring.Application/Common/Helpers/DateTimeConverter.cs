namespace MediToring.Application.Common.Helpers;

public static class DateTimeConverter
{
    public static (DateTime StartTimeUtc, DateTime EndTimeUtc) ConvertToUtc(DateTime startTime, DateTime endTime)
    {
        var startTimeUtc = DateTime.SpecifyKind(startTime, DateTimeKind.Utc);
        var endTimeUtc = DateTime.SpecifyKind(endTime, DateTimeKind.Utc);
        return (startTimeUtc, endTimeUtc);
    }
}