using System;
using Microsoft.Extensions.Logging;

namespace Analogy.AspNetCore.LogProvider
{
    public class AnalogyLoggerConfiguration
    {

        public string AnalogyServerUrl { get; set; }
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; }

        public AnalogyLoggerConfiguration(LogLevel minimumLogLevel = LogLevel.Trace, int eventId = 0, string analogyServerUrl = "http://localhost:6000")
        {
            LogLevel = minimumLogLevel;
            EventId = eventId;
            AnalogyServerUrl = analogyServerUrl;
        }
    }
}
