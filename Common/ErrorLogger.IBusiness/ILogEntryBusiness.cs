using System.Collections.Generic;
using ErrorLogger.Common.Poco;

namespace ErrorLogger.IBusiness
{
    public interface ILogEntryBusiness
    {
        IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10);
        void SaveLogEntry(LogEntry logEntry);
    }
}
