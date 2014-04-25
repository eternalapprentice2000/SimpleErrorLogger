using System.Collections.Generic;
using ErrorLogger.Common.Poco;
using ErrorLogger.IDAL;
using ErrorLogger.IStorage;
using ErrorLogger.Storage.SQL.LogEntries;

namespace ErrorLogger.DAL.LogEntries
{
    public class LogEntryDal : ILogEntryDal
    {
        private readonly ILogEntryStorage _logEntryStorage;

        public LogEntryDal()
        {
            // better to use dependency injection but in this case this will do.
            _logEntryStorage = new LogEntryStorage();
        }

        public IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10)
        {
            return _logEntryStorage.LoadLogEntries(pageNumber, numberPerPage);
        }

        public void SaveLogEntry(LogEntry logEntry)
        {
            _logEntryStorage.SaveLogEntry(logEntry);
        }
    }
}
