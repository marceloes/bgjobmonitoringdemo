using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Threading;

namespace ProducerWorker
{
    public class Functions
    {
        public static void ProduceMessages ([TimerTrigger("*/5 * * * * *")] TimerInfo timer, [Queue("worker-requests-queue")] out string message, ILogger logger)
        {
            //log.LogInformation(800, "Created message {message}", message);
            var text = String.Format("Request-{0}-{1}", DateTime.Now, new Random().Next(0, 10000));
            logger.LogInformation(800, "Message logged = {text}", text);
            message = text;            
        }
    }
}
