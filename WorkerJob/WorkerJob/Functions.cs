using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace WorkerJob
{
    public class Functions
    {
        public static void ConsumeQueueMessage([QueueTrigger("worker-requests-queue")] string message, ILogger logger)
        {
            TelemetryClient tc = new TelemetryClient();

            tc.TrackTrace($"Testing message for {message}", SeverityLevel.Warning,
                new Dictionary<string, string>()
                {
                    {"ProcessedOn", DateTime.UtcNow.ToString() },
                    {"RecordIdentifier", message},
                    {"Status", "Process Started" },
                    {"Message", message },
                    {"BackgroundJobId", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() }
                });            

            var threadName = Thread.CurrentThread.ManagedThreadId;
            logger.LogInformation(999, "{name} - Started consuming message '{message}'", threadName, message);
            logger.LogInformation(998, "{name} - Processing begins for '{message}'...", threadName, message);
            Random r = new Random();
            int interval = r.Next(0, 300);
            logger.LogInformation(997, "{name} - It will take {interval} seconds to process '{message}'", threadName, interval, message);
            
            Thread.Sleep(interval * 1000);
            logger.LogInformation(996, "{name} - Finished consuming message '{message}'", threadName, message);            
        }
    }
}
