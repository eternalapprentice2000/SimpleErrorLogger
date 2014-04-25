using System.Collections.Generic;
using ErrorLogger.Common.Poco;

namespace ErrorLogger.Storage.SQL.LogEntries
{
    public static class LogEntryMap
    {
        public static IEnumerable<LogEntry> LoadLogEntries(DatabaseReader readerWrapper)
        {
            var returnValue = new List<LogEntry>();

            using (readerWrapper)
            {
                while (readerWrapper.Read())
                {
                    var logEntry = new LogEntry
                        {
                            Id = readerWrapper.GetInt32("LogId"),
                            Entry = readerWrapper.GetString("LogEntry"),
                            CreatedOn = readerWrapper.GetDateTime("CreatedOn"),
                            CreatedBy = readerWrapper.GetString("CreatedBy")
                        };

                    returnValue.Add(logEntry);
                }
            }

            return returnValue;

        }
    }
}
