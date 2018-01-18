using System;

namespace SimpleLogger
{
    public interface ISimpleLogger
    {
        void Log(string message);
        void LogError(string message, Exception ex);
    }
}
