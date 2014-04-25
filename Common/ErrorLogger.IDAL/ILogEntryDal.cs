using System.Collections.Generic;
using ErrorLogger.Common.Poco;

namespace ErrorLogger.IDAL
{
    public interface ILogEntryDal
    {
        IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10);
        void SaveLogEntry(LogEntry logEntry);
    }
}
