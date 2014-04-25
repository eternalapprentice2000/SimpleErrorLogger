using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErrorLogger.Business.LogEntries;
using ErrorLogger.Common.Poco;
using ErrorLogger.IBusiness;
using WebLogger.Models;

namespace WebLogger.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogEntryBusiness _logEntryBusiness;

        public LoggerController()
        {
            _logEntryBusiness = new LogEntryBusiness();
        }

        [HttpGet]
        public ActionResult Log(int? pageNumber = null, int? numberPerPage = null)
        {
            // get the data
            return ReturnLogResults(pageNumber, numberPerPage);
        }

        [HttpPost]
        public ActionResult Log(LoggerLogModel logModel)
        {
            var logEntry = new LogEntry
                {
                    CreatedBy = logModel.CreatedBy,
                    Entry = logModel.LogEntry
                };

            _logEntryBusiness.SaveLogEntry(logEntry);

            return ReturnLogResults();
        }

        private ActionResult ReturnLogResults(int? pageNumber = null, int? numberPerPage = null)
        {
            var logs = _logEntryBusiness.LoadLogEntries(pageNumber, numberPerPage ?? 10);

            var loggerModels = new List<LoggerLogModel>();

            foreach (var log in logs)
            {
                var logModel = new LoggerLogModel
                {
                    LogId = log.Id,
                    LogEntry = log.Entry,
                    CreatedBy = log.CreatedBy,
                    CreatedOn = log.CreatedOn
                };

                loggerModels.Add(logModel);
            }


            return View("Log", loggerModels);
        }

    }
}
