using System.Collections.Generic;
using System.Linq;
using ErrorLogger.Business.LogEntries;
using ErrorLogger.Common.Poco;
using ErrorLogger.IBusiness;

namespace SimpleErrorLogger
{
    class Program
    {
        private static readonly ILogEntryBusiness _logEntryBusiness;

        static Program()
        {
            _logEntryBusiness = new LogEntryBusiness();
        }

        public static void Main(string[] args)
        {

            WriteLine("Press 1 to Enter a Log Entry or 2 to read the log");
            var key = ReadKey();

            switch (key.KeyChar.ToString())
            {
                case "1":
                    ProcessWriteToLog();
                    break;

                case "2":
                    ProcessReadFromLog();
                    break;

            }

            WriteLine("Press ANY KEY to Close");
            ReadKey();
        }
    
        private static void ProcessWriteToLog()
        {
            // get the person creating the log
            WriteLine("Enter Your Name");
            var userName = ReadLine();

            WriteLine("Enter your Log Entry");
            var logEntry = ReadLine();

            WriteLine(string.Format("Your Name: {0} \r\nYour Entry: {1}", userName, logEntry));
            WriteLine("Is this correct [y]es [n]o");

            var keypressed = ReadKey();

            var logEntryPoco = new LogEntry
                {
                    Entry = logEntry,
                    CreatedBy = userName
                };

            switch (keypressed.KeyChar.ToString().ToLower().Trim())
            {
                case "y":
                    _logEntryBusiness.SaveLogEntry(logEntryPoco);
                    break;
                default:
                    WriteLine("Entry Cancelled");
                    break;
            }

        }

        private static void ProcessReadFromLog()
        {
            var logEntries = _logEntryBusiness.LoadLogEntries().ToList();
            var entryTemplate = "Id:            {0}" + "\r\n" +
                                "Entry:         {1}" + "\r\n" +
                                "Date Entered:  {2}" + "\r\n" +
                                "Entered By:    {3}" + "\r\n" +
                                "-----------------------------------------------------------";

            foreach (var entry in logEntries)
            {
                WriteLine(string.Format(entryTemplate, entry.Id, entry.Entry, entry.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"), entry.CreatedBy));

            }
        }

        #region helpers

        public static void WriteLine(string text)
        {
            System.Console.WriteLine("\r\n{0}",text);
        }

        public static System.ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        #endregion



    }
}
