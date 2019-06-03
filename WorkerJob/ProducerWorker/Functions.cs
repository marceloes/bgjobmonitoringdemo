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
        public static void ProduceMessages ([TimerTrigger("0 */15 * * * 1-5", RunOnStartup = true)] TimerInfo timerInfo, [Queue("worker-requests-queue")] out string message)
        {
            message = String.Format("Request-{0}-{1}", DateTime.Now, new Random().Next(0, 10000));
        }
    }
}
