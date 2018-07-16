// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class TestSqlLoggerFactory : ILoggerFactory
    {
        private static readonly string _eol = Environment.NewLine;

        private readonly Logger _logger = new Logger();

        ILogger ILoggerFactory.CreateLogger(string categoryName) => _logger;

        void ILoggerFactory.AddProvider(ILoggerProvider provider) => throw new NotImplementedException();

        void IDisposable.Dispose()
        {
        }

        private sealed class Logger : ILogger
        {
            public IndentedStringBuilder LogBuilder { get; } = new IndentedStringBuilder();
            public List<string> SqlStatements { get; } = new List<string>();
            public List<string> Parameters { get; } = new List<string>();

            private CancellationTokenSource _cancellationTokenSource;

            public ITestOutputHelper TestOutputHelper { get; set; }

            private readonly object _sync = new object();

            public void Clear()
            {
                lock (_sync) // Guard against tests with explicit concurrency
                {
                    SqlStatements.Clear();
                    LogBuilder.Clear();
                    Parameters.Clear();

                    _cancellationTokenSource = null;
                }
            }

            public CancellationToken CancelQuery()
            {
                lock (_sync) // Guard against tests with explicit concurrency
                {
                    _cancellationTokenSource = new CancellationTokenSource();

                    return _cancellationTokenSource.Token;
                }
            }

            void ILogger.Log<TState>(
                LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                var format = formatter(state, exception)?.Trim();

                lock (_sync) // Guard against tests with explicit concurrency
                {
                    if (format != null)
                    {
                        if (_cancellationTokenSource != null)
                        {
                            _cancellationTokenSource.Cancel();
                            _cancellationTokenSource = null;
                        }

                        if (eventId.Id == RelationalEventId.CommandExecuted.Id
                            || eventId.Id == RelationalEventId.CommandError.Id)
                        {
                            var structure = (IReadOnlyList<KeyValuePair<string, object>>)state;

                            var parameters = structure.Where(i => i.Key == "parameters").Select(i => (string)i.Value).First();
                            var commandText = structure.Where(i => i.Key == "commandText").Select(i => (string)i.Value).First();

                            if (!string.IsNullOrWhiteSpace(parameters))
                            {
                                Parameters.Add(parameters);
                                parameters = parameters.Replace(", ", _eol) + _eol + _eol;
                            }

                            SqlStatements.Add(parameters + commandText);
                        }
                        else
                        {
                            LogBuilder.AppendLine(format);
                        }

                        if (eventId.Id != RelationalEventId.CommandExecuted.Id)
                        {
                            TestOutputHelper?.WriteLine(format + _eol);
                        }
                    }
                }
            }

            bool ILogger.IsEnabled(LogLevel logLevel) => true;

            IDisposable ILogger.BeginScope<TState>(TState state)
            {
                lock (_sync) // Guard against tests with explicit concurrency
                {
                    return LogBuilder.Indent();
                }
            }
        }
    }
}
