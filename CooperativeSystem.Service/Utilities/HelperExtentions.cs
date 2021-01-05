using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Utilities
{
    public static class HelperExtentions
    {
        public static DateTime TruncateTime(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day);
        }

        public static int GetLastDayOfTheMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime GetMaximumDateOfTheMonth(this DateTime value)
        {
            var year = value.Year;
            var month = value.Month;
            var day = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, day, 23, 59, 59, 999);
        }

        public static DateTime GetMaximumDateOfTheQuarter(this Quarter quarter, int year)
        {
            var month = quarter.Months.Max(x => x.MonthID);

            return new DateTime(year, month, 1)
                .GetMaximumDateOfTheMonth();
        }

        public static DateTime GetMaximumDateOfTheYear(this int year)
        {
            return new DateTime(year, 12, 1).GetMaximumDateOfTheMonth();
        }

        public static bool HasFractionalValue(this double value)
        {
            var stringValue = value.ToString();
            var index = stringValue.IndexOf('.');
            if (index < 0)
                return false;

            var fractionalValue = 0D;
            var result = double.TryParse(stringValue.Substring(index + 1), out fractionalValue);
            if (result == false)
                return false;

            if (fractionalValue < 0)
                return false;

            return true;
        }
    }
}
