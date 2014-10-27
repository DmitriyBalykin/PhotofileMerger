using System;
using System.Collections.Generic;
using System.Text;

namespace PhotofileMerger
{
    public class OriginDateChangedEventArgs : EventArgs
    {
        public OriginDateChangedEventArgs(string date)
        {
            Date = date;
        }
        public string Date;
    }
}
