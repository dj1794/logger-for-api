1. Install-Package log4net -Version 2.0.8
2. Install-Package Microsoft.Extensions.Logging.Log4Net.AspNetCore
3. Add a log4net.config file with the below content in the root of project.

<?xml version="1.0"?>
<log4net debug="false">
  <appender name="LogToFile" type="log4net.Appender.FileAppender">
    <threshold value="INFO" />
    <file type="log4net.Util.PatternString" value="logs/log-%utcdate{yyyy-MM-dd}.txt" />
    <immediateFlush value="true" />
    <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
    <appendToFile value="false" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date %-5level - %message%newline" />
    </layout>
  </appender>
  <root>
    <level value="ALL" />
    <appender-ref ref="LogToFile" />
  </root>
</log4net>

3. add the below code while instantiating the webhost interface.

.ConfigureLogging((hostingContext, logging) =>
            {
                // The ILoggingBuilder minimum level determines the
                // the lowest possible level for logging. The log4net
                // level then sets the level that we actually log at.
                logging.AddLog4Net();
                logging.SetMinimumLevel(LogLevel.Debug);
            })
			
4. In the main method add below two lines

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
			
5 A test action to log a exception

     public IEnumerable<string> Get()
        {
            var logger = LogManager.GetLogger(typeof(Program));
            var j = "b";
            try
            {
                Convert.ToInt32(j);
            }
            catch (Exception e)
            {
                logger.Error("Logger is working!!! " + e.Message);
            }
            
            return new string[] { j, "Test" };
        }
