using System;
using System.Collections.Generic;
using System.Text;

namespace PhotofileMerger
{
    public class ProgressChangedEventArgs : EventArgs
    {
        public int Progress;
        public ProgressChangedEventArgs(double progress)
        {
            Progress = (int)Math.Ceiling(progress);
        }
    }
}
