using Microsoft.Extensions.Logging;
using System;

namespace Analogy.AspNetCore.LogProvider
{
    public static class AnalogyLoggerExtensions
    {
        public static ILoggerFactory AddAnalogyLogger(this ILoggerFactory loggerFactory, AnalogyLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new AnalogyLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddAnalogyLogger(this ILoggerFactory loggerFactory)
        {
            var config = new AnalogyLoggerConfiguration();
            return loggerFactory.AddAnalogyLogger(config);
        }
        public static ILoggerFactory AddAnalogyLogger(this ILoggerFactory loggerFactory, Action<AnalogyLoggerConfiguration> configure)
        {
            var config = new AnalogyLoggerConfiguration();
            configure(config);
            return loggerFactory.AddAnalogyLogger(config);
        }
    }
}