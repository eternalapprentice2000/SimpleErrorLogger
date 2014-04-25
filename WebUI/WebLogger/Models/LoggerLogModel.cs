using System;

namespace WebLogger.Models
{
    public class LoggerLogModel
    {
        public int LogId { get; set; }
        public string LogEntry { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}