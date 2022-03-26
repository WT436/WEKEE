using log4net;
using log4net.Config;
using System;
using System.Application.Interface;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace System.Application.Application
{
    public class LogTextLog4NetService : ILogTextLog4Net
    {

        private readonly ILog _logger = LogManager.GetLogger(typeof(LogTextLog4NetService));
        public LogTextLog4NetService()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead(@"..\System.Domain\Shared\log4net.config"))
                {
                    log4netConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                            Assembly.GetEntryAssembly(),
                            typeof(log4net.Repository.Hierarchy.Hierarchy));

                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

                    // The first log to be written
                    _logger.Info("Log System Initialized");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }

        public void LogError(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void LogError(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogWanning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
