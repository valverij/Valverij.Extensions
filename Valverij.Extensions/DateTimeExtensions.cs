using System;

namespace Valverij.Extensions
{
    public static class DateTimeExtensions
    {
        public static string MonthName(this DateTime? dateTime) => dateTime?.ToString("MMMM");

        public static string ShortMonthName(this DateTime? dateTime) => dateTime?.ToString("MMM");

        public static string ToShortDateString(this DateTime? dateTime) => dateTime?.ToShortDateString();

        public static string ToShortTimeString(this DateTime? dateTime) => dateTime.HasValue ? dateTime.Value.ToShortTimeString() : null;

        public static string ToStringWithFormat(this DateTime? dateTime, string format) => dateTime.HasValue ? dateTime.Value.ToString(format) : null;

        public static DateTime StartOfDay(this DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);       

        public static DateTime? StartOfDay(this DateTime? dateTime) => dateTime.HasValue ? new DateTime?(dateTime.Value.StartOfDay()) : null;

        public static DateTime EndOfDay(this DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);

        public static DateTime? EndOfDay(this DateTime? dateTime) => dateTime.HasValue ? new DateTime?(dateTime.Value.EndOfDay()) : null;
    }
}
