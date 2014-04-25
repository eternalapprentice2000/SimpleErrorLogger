using System.Collections.Generic;
using ErrorLogger.Common.Poco;

namespace ErrorLogger.IStorage
{
    public interface ILogEntryStorage
    {
        IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10);
        void SaveLogEntry(LogEntry logEntry);

    }
}
