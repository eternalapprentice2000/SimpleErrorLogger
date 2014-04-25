using System.Collections.Generic;
using ErrorLogger.Common.Poco;
using ErrorLogger.DAL.LogEntries;
using ErrorLogger.IBusiness;
using ErrorLogger.IDAL;

namespace ErrorLogger.Business.LogEntries
{
    public class LogEntryBusiness : ILogEntryBusiness
    {
        private readonly ILogEntryDal _logEntryDal;

        public LogEntryBusiness()
        {
            _logEntryDal = new LogEntryDal();
        }

        public IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10)
        {
            return _logEntryDal.LoadLogEntries(pageNumber, numberPerPage);
        }

        public void SaveLogEntry(LogEntry logEntry)
        {
            _logEntryDal.SaveLogEntry(logEntry);
        }
    }
}
