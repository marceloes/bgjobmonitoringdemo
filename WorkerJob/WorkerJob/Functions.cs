using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace WorkerJob
{
    public class Functions
    {
        public static readonly string queueName = ConfigurationManager.AppSettings["queue"];

        public static void ConsumeQueueMessage([QueueTrigger("worker-requests-queue")] string message, ILogger logger)
        {
            logger.LogInformation($"Started consuming message {message}");
        }
    }
}
