using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// This interface defines the contract for a logger manager class that can log different types of messages 
    /// </summary>
    public interface ILoggerManager
    {
        void LogInfo(string message); 
        void LogWarn(string message); 
        void LogDebug(string message); 
        void LogError(string message);
    }
}
