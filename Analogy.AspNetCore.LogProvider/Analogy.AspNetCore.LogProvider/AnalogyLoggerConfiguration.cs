using System;
using Microsoft.Extensions.Logging;

namespace Analogy.AspNetCore.LogProvider
{
    public class AnalogyLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; }
        public string AnalogyServerUrl { get; set; }

        public AnalogyLoggerConfiguration()
        {
            LogLevel = LogLevel.Trace;
            EventId = 0;
            AnalogyServerUrl = "http://localhost:6000";
        }

        public AnalogyLoggerConfiguration(LogLevel logLevel, int eventId, string analogyServerUrl)
        {
            AnalogyServerUrl = analogyServerUrl;
            LogLevel = logLevel;
            EventId = eventId;
        }
    }
}
