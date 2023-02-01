using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaSuite.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToLocalTime(this DateTime centralDateTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZone.CurrentTimeZone.StandardName);
            TimeZoneInfo centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTime(centralDateTime, centralTimeZone, localTimeZone);
        }

        public static DateTime ConvertToServerTime(this DateTime localTimeDateTime)
        {
            DateTime innerDateTime = new DateTime(localTimeDateTime.Ticks, DateTimeKind.Unspecified);
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZone.CurrentTimeZone.StandardName);
            TimeZoneInfo centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTime(innerDateTime, localTimeZone, centralTimeZone);
        }
    }
}
