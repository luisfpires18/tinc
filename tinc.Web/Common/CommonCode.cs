using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tinc.Web.Common
{
    public static class CommonCode
    {
        public static DateTime ToDate(this string data)
        {
            var dayStart = data.Split('/')[0];
            var monthStart = data.Split('/')[1];
            var yearStart = data.Split('/')[2];
            return new DateTime(int.Parse(dayStart), int.Parse(monthStart), int.Parse(yearStart));
        }
    }
}
