using Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    /// <summary>
    /// This class implements the ILoggerManager interface and uses the NLog library to log different types of messages
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
                
        }
        public void LogDebug(string message) => logger.Debug(message);  
        

        public void LogError(string message) => logger?.Error(message); 
        

        public void LogInfo(string message) => logger.Info(message);    
        

        public void LogWarn(string message) => logger?.Warn(message);   
        
    }
}
