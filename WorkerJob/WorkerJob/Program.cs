using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace WorkerJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices();
                });

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
