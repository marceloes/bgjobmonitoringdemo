using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Threading;

namespace WorkerJob
{
    public class Functions
    {
        public static readonly string queueName = ConfigurationManager.AppSettings["queue"];

        public static void ConsumeQueueMessage([QueueTrigger("worker-requests-queue")] string message, ILogger logger)
        {
            
            logger.LogInformation(999, "Started consuming message '{message}'", message);
            logger.LogInformation(998, "Processing begins...");
            Random r = new Random();
            int interval = r.Next(0, 300);
            logger.LogInformation(997, "It will take {interval} seconds", interval);
            Thread.Sleep(interval * 1000);
            logger.LogInformation(996, "Finished consuming message", message);
            
        }
    }
}
