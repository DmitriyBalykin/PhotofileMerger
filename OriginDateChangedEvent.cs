using System;
using System.Collections.Generic;
using System.Text;

namespace ReadExif
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
