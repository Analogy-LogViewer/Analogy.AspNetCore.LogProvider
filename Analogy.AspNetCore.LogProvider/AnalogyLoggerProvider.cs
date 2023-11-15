using Analogy.LogServer.Clients;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Analogy.AspNetCore.LogProvider
{
    public class AnalogyLoggerProvider : ILoggerProvider
    {
        private readonly AnalogyLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, AnalogyLogger> _loggers = new ConcurrentDictionary<string, AnalogyLogger>();
        private readonly ConcurrentDictionary<string, AnalogyMessageProducer> _gRPCSenders = new ConcurrentDictionary<string, AnalogyMessageProducer>();
        public AnalogyLoggerProvider(AnalogyLoggerConfiguration config)
        {
            _config = config;
        }

        public AnalogyLoggerProvider(string analogyServerUrl, Microsoft.Extensions.Logging.LogLevel minimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Trace, int eventId = 0)
        {
            _config = new AnalogyLoggerConfiguration(minimumLogLevel, eventId, analogyServerUrl);
        }
        public void Dispose()
        {
            _loggers.Clear();
            foreach (var producer in _gRPCSenders)
            {
                try
                {
                    producer.Value.StopReceiving();
                    producer.Value.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            var producer = _gRPCSenders.GetOrAdd(_config.AnalogyServerUrl, url => new AnalogyMessageProducer(url));
            return _loggers.GetOrAdd(categoryName, name => new AnalogyLogger(name, _config, producer));
        }
    }
}