using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class Month
    {
        public Month(int Id, string name)
        {
            MonthID = Id;
            Name = name;
        }

        #region Static Members

        public static readonly Month January = new Month(1, "January");
        public static readonly Month Febuary = new Month(2, "Febuary");
        public static readonly Month March = new Month(3, "March");
        public static readonly Month April = new Month(4, "April");
        public static readonly Month May = new Month(5, "May");
        public static readonly Month June = new Month(6, "June");
        public static readonly Month July = new Month(7, "July");
        public static readonly Month August = new Month(8, "August");
        public static readonly Month September = new Month(9, "September");
        public static readonly Month October = new Month(10, "October");
        public static readonly Month November = new Month(11, "November");
        public static readonly Month December = new Month(12, "December");

        private static readonly IList<Month> _months = new List<Month>()
        {
            January,
            Febuary,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        };

        public static IList<Month> GetAll()
        {
            return _months;
        }

        #endregion
    }
}
