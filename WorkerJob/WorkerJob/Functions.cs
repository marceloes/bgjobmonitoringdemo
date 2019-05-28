using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WorkerJob
{
    public class Functions
    {
        public static void ConsumeQueueMessage([QueueTrigger("queue")] string message, ILogger logger)
        {
            logger.LogInformation($"Started consuming message {message}");
        }
    }
}
