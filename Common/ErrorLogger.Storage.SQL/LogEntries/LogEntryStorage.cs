using System.Collections.Generic;
using System.Data;
using ErrorLogger.Common.Poco;
using ErrorLogger.IStorage;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace ErrorLogger.Storage.SQL.LogEntries
{
    public class LogEntryStorage : ILogEntryStorage
    {
        public IEnumerable<LogEntry> LoadLogEntries(int? pageNumber = null, int numberPerPage = 10)
        {
            var target = Procedures.ErrorLog.LogEntries.LoadLogEntries;

            var db = new SqlDatabase(target.Connection);

            using (var command = db.GetStoredProcCommand(target.ProcedureName))
            {

                if (pageNumber != null)
                {
                    db.AddInParameter(command, "@PageNumber", DbType.Int32, (int)pageNumber);
                    db.AddInParameter(command, "@NumberPerPage", DbType.Int32, numberPerPage); 
                }

                using (var reader = db.ExecuteReader(command))
                {
                    var readerWrapper = new DatabaseReader(reader, target.ProcedureName);
                    return LogEntryMap.LoadLogEntries(readerWrapper);
                }
            }
        }

        public void SaveLogEntry(LogEntry logEntry)
        {
            var target = Procedures.ErrorLog.LogEntries.InsertLogEntry;

            var db = new SqlDatabase(target.Connection);

            using (var command = db.GetStoredProcCommand(target.ProcedureName))
            {
                db.AddInParameter(command, "@LogEntry", DbType.String, logEntry.Entry);
                db.AddInParameter(command, "@CreatedBy", DbType.String, logEntry.CreatedBy);

                db.ExecuteNonQuery(command);
            }
        }

    }
}
