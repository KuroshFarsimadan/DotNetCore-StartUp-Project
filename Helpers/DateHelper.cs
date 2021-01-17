using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Helpers
{
    public class DateHelper
    {
        public static int DateRangeDifference(DateTime dt)
        {
            var today = DateTime.Today;
            var difference = today.Year - dt.Year;
            if (dt.Date > today.AddYears(difference))
            {
                difference--;
            }
            return difference;
        }

    }
}
