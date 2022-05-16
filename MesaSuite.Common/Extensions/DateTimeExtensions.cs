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
    }
}
