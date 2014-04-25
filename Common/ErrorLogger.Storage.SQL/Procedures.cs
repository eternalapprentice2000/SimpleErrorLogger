namespace ErrorLogger.Storage.SQL
{
    public static class Procedures
    {
        public static class ErrorLog
        {
            private static string Connection
            {
                get { return StorageBase.Instance.ErrorLog; }
            }

            public static class LogEntries
            {
                public static ProcedureTarget LoadLogEntries
                {
                    get
                    {
                        return new ProcedureTarget
                            {
                                Connection = Connection,
                                ProcedureName = "spLoadLogEntries"
                            };
                    }
                }

                public static ProcedureTarget InsertLogEntry
                {
                    get
                    {
                        return new ProcedureTarget
                            {
                                Connection = Connection,
                                ProcedureName = "spInsertLogEntry"
                            };
                    }
                }
            }
        }
    }
}
