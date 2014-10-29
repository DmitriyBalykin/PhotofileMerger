using System;
using System.Collections.Generic;
using System.Text;

namespace PhotofileMerger
{
    public class Grouping
    {
        public bool ByYear = false;
        public bool ByMonth = false;
        public bool ByDay = false;
        public Grouping(bool byYear, bool byMonth, bool byDay)
        {
            ByYear = byYear;
            ByMonth = byMonth;
            ByDay = byDay;
        }
        
    }
}
