using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using log4net.Config;
using log4net;

namespace LoggerTestApi
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging((hostingContext, logging) =>
            {
                // The ILoggingBuilder minimum level determines the
                // the lowest possible level for logging. The log4net
                // level then sets the level that we actually log at.
                logging.AddLog4Net();
                logging.SetMinimumLevel(LogLevel.Debug);
            })
                .Build();

    }
}
