using Analogy.LogServer.Clients;
using Microsoft.Extensions.Logging;
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
        public void Dispose()
        {
            _loggers.Clear();
        }

        public ILogger CreateLogger(string categoryName)
        {
            var producer = _gRPCSenders.GetOrAdd(_config.AnalogyServerUrl, url => new AnalogyMessageProducer(url));
            return _loggers.GetOrAdd(categoryName, name => new AnalogyLogger(name, _config, producer));
        }
    }
}
