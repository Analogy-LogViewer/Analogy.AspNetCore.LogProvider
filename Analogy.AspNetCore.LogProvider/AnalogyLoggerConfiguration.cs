using System;
using Microsoft.Extensions.Logging;

namespace Analogy.AspNetCore.LogProvider
{
    public class AnalogyLoggerConfiguration
    {

        public string AnalogyServerUrl { get; set; }
        public LogLevel LogLevel { get; set; }

        public AnalogyLoggerConfiguration() : this(LogLevel.Trace, "http://localhost:6000")
        {
        }

        public AnalogyLoggerConfiguration(LogLevel minimumLogLevel, string analogyServerUrl)
        {
            LogLevel = minimumLogLevel;
            AnalogyServerUrl = analogyServerUrl;
        }
    }
}
