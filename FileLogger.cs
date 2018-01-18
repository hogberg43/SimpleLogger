using System;
using System.IO;

namespace SimpleLogger
{
    public class FileLogger : ISimpleLogger
    {
        private readonly string _fileName;

        public FileLogger(ILogConfig config)
        {
            if (!Directory.Exists(config.LogLocation)) throw new Exception($"The log file directory set in the config does not exist: {config.LogLocation}");
            _fileName = $"{config.LogLocation.TrimEnd('\\')}\\{config.LogFileName}_{DateTime.Now:MMddyyyy}.txt";
        }

        public void Log(string message)
        {
            LogToFile($"{DateTime.Now} - INFO: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            LogToFile($"{DateTime.Now} - ERROR: {message}\r\n{ex}");
        }

        void LogToFile(string message)
        {
            if (File.Exists(_fileName))
            {
                using (var logWriter = File.AppendText(_fileName))
                {
                    logWriter.WriteLine(message);
                }
            }
            else
            {
                using (var logWriter = File.CreateText(_fileName))
                {
                    logWriter.WriteLine(message);
                }
            }
        }
    }
}
