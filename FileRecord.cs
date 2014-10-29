using System;
using System.Collections.Generic;
using System.Text;

namespace PhotofileMerger
{
    class FileRecord : IComparable<FileRecord>
    {
        public string Name;
        public DateTime Time;
        public FileRecord(string fileName, DateTime fileTime)
        {
            Name = fileName;
            Time = fileTime;
        }
        public override bool Equals(object obj)
        {
            return (obj is FileRecord) && ((FileRecord)obj).Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(FileRecord record)
        {
            if (Time.CompareTo(record.Time) != 0)
            {
                return Time.CompareTo(record.Time);
            }
            else
            {
                return Name.CompareTo(record.Name);
            }
        }
    }
}
