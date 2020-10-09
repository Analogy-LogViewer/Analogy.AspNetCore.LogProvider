using System;
using System.Collections.Generic;
using System.Text;
using Analogy.Interfaces;
using Analogy.LogServer;
using Analogy.LogServer.Clients;
using Microsoft.Extensions.Logging;

namespace Analogy.AspNetCore.LogProvider
{
    public class AnalogyLogger : ILogger
    {
        private readonly string _name;
        private readonly AnalogyLoggerConfiguration _config;
        private readonly AnalogyMessageProducer logSender;
        private bool gRPCEnabled = true;

        public AnalogyLogger(string name, AnalogyLoggerConfiguration config, AnalogyMessageProducer producer)
        {
            _name = name;
            _config = config;
            logSender = producer;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (gRPCEnabled && !IsEnabled(logLevel))
            {
                return;
            }

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                try
                {
                    AnalogyGRPCLogLevel level;
                    switch (logLevel)
                    {
                        case LogLevel.Trace:
                            level = AnalogyGRPCLogLevel.Trace;
                            break;
                        case LogLevel.Debug:
                            level = AnalogyGRPCLogLevel.Debug;

                            break;
                        case LogLevel.Information:
                            level = AnalogyGRPCLogLevel.Information;

                            break;
                        case LogLevel.Warning:
                            level = AnalogyGRPCLogLevel.Warning;
                            break;
                        case LogLevel.Error:
                            level = AnalogyGRPCLogLevel.Error;
                            break;
                        case LogLevel.Critical:
                            level = AnalogyGRPCLogLevel.Critical;
                            break;
                        case LogLevel.None:
                            level = AnalogyGRPCLogLevel.None;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
                    }

                    string text = formatter(state, exception);
                    logSender.Log(text, _name, level, "", Environment.MachineName, Environment.UserName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    gRPCEnabled = false;
                }
            }
        }


        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _config.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
