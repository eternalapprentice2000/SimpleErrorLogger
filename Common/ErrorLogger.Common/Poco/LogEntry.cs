using System;

namespace ErrorLogger.Common.Poco
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
