﻿// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using Serilog.Events;

namespace Splat
{
    /// <summary>
    /// A full wrapping logger over Serilog.
    /// </summary>
    public class SerilogFullLogger : IFullLogger
    {
        private readonly global::Serilog.ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogFullLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger we are wrapping.</param>
        public SerilogFullLogger(global::Serilog.ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public bool IsDebugEnabled => _logger.IsEnabled(LogEventLevel.Debug);

        /// <inheritdoc />
        public bool IsInfoEnabled => _logger.IsEnabled(LogEventLevel.Information);

        /// <inheritdoc />
        public bool IsWarnEnabled => _logger.IsEnabled(LogEventLevel.Warning);

        /// <inheritdoc />
        public bool IsErrorEnabled => _logger.IsEnabled(LogEventLevel.Error);

        /// <inheritdoc />
        public bool IsFatalEnabled => _logger.IsEnabled(LogEventLevel.Fatal);

        /// <inheritdoc />
        public LogLevel Level
        {
            get
            {
                foreach (var mapping in SerilogHelper.Mappings)
                {
                    if (_logger.IsEnabled(mapping.Value))
                    {
                        return mapping.Key;
                    }
                }

                // Default to Fatal, it should always be enabled anyway.
                return LogLevel.Fatal;
            }

            set
            {
                // Do nothing. set is going soon anyway.
            }
        }

        /// <inheritdoc />
        public void Debug<T>(T value)
        {
            _logger.Debug(value.ToString());
        }

        /// <inheritdoc />
        public void Debug<T>(IFormatProvider formatProvider, T value)
        {
           _logger.Debug(string.Format(formatProvider, "{0}", value));
        }

        /// <inheritdoc />
        public void Debug(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
        {
           _logger.Debug(string.Format(formatProvider, message, args));
        }

        /// <inheritdoc />
        public void Debug([Localizable(false)] string message)
        {
           _logger.Debug(message);
        }

        /// <inheritdoc />
        public void Debug<T>([Localizable(false)] string message)
        {
            _logger.ForContext<T>().Debug(message);
        }

        /// <inheritdoc />
        public void Debug([Localizable(false)] string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        /// <inheritdoc />
        public void Debug<T>([Localizable(false)] string message, params object[] args)
        {
            _logger.ForContext<T>().Debug(message, args);
        }

        /// <inheritdoc />
        public void Debug<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
        {
            _logger.Debug(string.Format(formatProvider, message, argument));
        }

        /// <inheritdoc />
        public void Debug<TArgument>([Localizable(false)] string message, TArgument argument)
        {
            _logger.Debug(message, argument);
        }

        /// <inheritdoc />
        public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Debug(string.Format(formatProvider, message, argument1, argument2));
        }

        /// <inheritdoc />
        public void Debug<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Debug(message, argument1, argument2);
        }

        /// <inheritdoc />
        public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Debug(string.Format(formatProvider, message, argument1, argument2, argument3));
        }

        /// <inheritdoc />
        public void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Debug(message, argument1, argument2, argument3);
        }

        /// <inheritdoc />
        public void DebugException([Localizable(false)] string message, Exception exception)
        {
            _logger.Debug(exception, message);
        }

        /// <inheritdoc />
        public void Error<T>(T value)
        {
            _logger.Error(value.ToString());
        }

        /// <inheritdoc />
        public void Error<T>(IFormatProvider formatProvider, T value)
        {
           _logger.Error(string.Format(formatProvider, "{0}", value));
        }

        /// <inheritdoc />
        public void Error(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
        {
           _logger.Error(string.Format(formatProvider, message, args));
        }

        /// <inheritdoc />
        public void Error([Localizable(false)] string message)
        {
           _logger.Error(message);
        }

        /// <inheritdoc />
        public void Error<T>([Localizable(false)] string message)
        {
            _logger.ForContext<T>().Error(message);
        }

        /// <inheritdoc />
        public void Error([Localizable(false)] string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        /// <inheritdoc />
        public void Error<T>([Localizable(false)] string message, params object[] args)
        {
            _logger.ForContext<T>().Error(message, args);
        }

        /// <inheritdoc />
        public void Error<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
        {
            _logger.Error(string.Format(formatProvider, message, argument));
        }

        /// <inheritdoc />
        public void Error<TArgument>([Localizable(false)] string message, TArgument argument)
        {
            _logger.Error(message, argument);
        }

        /// <inheritdoc />
        public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Error(string.Format(formatProvider, message, argument1, argument2));
        }

        /// <inheritdoc />
        public void Error<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Error(message, argument1, argument2);
        }

        /// <inheritdoc />
        public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Error(string.Format(formatProvider, message, argument1, argument2, argument3));
        }

        /// <inheritdoc />
        public void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Error(message, argument1, argument2, argument3);
        }

        /// <inheritdoc />
        public void ErrorException([Localizable(false)] string message, Exception exception)
        {
            _logger.Error(exception, message);
        }

        /// <inheritdoc />
        public void Fatal<T>(T value)
        {
            _logger.Fatal(value.ToString());
        }

        /// <inheritdoc />
        public void Fatal<T>(IFormatProvider formatProvider, T value)
        {
           _logger.Fatal(string.Format(formatProvider, "{0}", value));
        }

        /// <inheritdoc />
        public void Fatal(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
        {
           _logger.Fatal(string.Format(formatProvider, message, args));
        }

        /// <inheritdoc />
        public void Fatal([Localizable(false)] string message)
        {
           _logger.Fatal(message);
        }

        /// <inheritdoc />
        public void Fatal<T>([Localizable(false)] string message)
        {
            _logger.ForContext<T>().Fatal(message);
        }

        /// <inheritdoc />
        public void Fatal([Localizable(false)] string message, params object[] args)
        {
            _logger.Fatal(message, args);
        }

        /// <inheritdoc />
        public void Fatal<T>([Localizable(false)] string message, params object[] args)
        {
            _logger.ForContext<T>().Fatal(message, args);
        }

        /// <inheritdoc />
        public void Fatal<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
        {
            _logger.Fatal(string.Format(formatProvider, message, argument));
        }

        /// <inheritdoc />
        public void Fatal<TArgument>([Localizable(false)] string message, TArgument argument)
        {
            _logger.Fatal(message, argument);
        }

        /// <inheritdoc />
        public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Fatal(string.Format(formatProvider, message, argument1, argument2));
        }

        /// <inheritdoc />
        public void Fatal<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Fatal(message, argument1, argument2);
        }

        /// <inheritdoc />
        public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Fatal(string.Format(formatProvider, message, argument1, argument2, argument3));
        }

        /// <inheritdoc />
        public void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Fatal(message, argument1, argument2, argument3);
        }

        /// <inheritdoc />
        public void FatalException([Localizable(false)] string message, Exception exception)
        {
            _logger.Fatal(exception, message);
        }

        /// <inheritdoc />
        public void Info<T>(T value)
        {
            _logger.Information(value.ToString());
        }

        /// <inheritdoc />
        public void Info<T>(IFormatProvider formatProvider, T value)
        {
           _logger.Information(string.Format(formatProvider, "{0}", value));
        }

        /// <inheritdoc />
        public void Info(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
        {
           _logger.Information(string.Format(formatProvider, message, args));
        }

        /// <inheritdoc />
        public void Info([Localizable(false)] string message)
        {
           _logger.Information(message);
        }

        /// <inheritdoc />
        public void Info<T>([Localizable(false)] string message)
        {
            _logger.ForContext<T>().Information(message);
        }

        /// <inheritdoc />
        public void Info([Localizable(false)] string message, params object[] args)
        {
            _logger.Information(message, args);
        }

        /// <inheritdoc />
        public void Info<T>([Localizable(false)] string message, params object[] args)
        {
            _logger.ForContext<T>().Information(message, args);
        }

        /// <inheritdoc />
        public void Info<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
        {
            _logger.Information(string.Format(formatProvider, message, argument));
        }

        /// <inheritdoc />
        public void Info<TArgument>([Localizable(false)] string message, TArgument argument)
        {
            _logger.Information(message, argument);
        }

        /// <inheritdoc />
        public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Information(string.Format(formatProvider, message, argument1, argument2));
        }

        /// <inheritdoc />
        public void Info<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Information(message, argument1, argument2);
        }

        /// <inheritdoc />
        public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Information(string.Format(formatProvider, message, argument1, argument2, argument3));
        }

        /// <inheritdoc />
        public void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Information(message, argument1, argument2, argument3);
        }

        /// <inheritdoc />
        public void InfoException([Localizable(false)] string message, Exception exception)
        {
            _logger.Information(exception, message);
        }

        /// <inheritdoc />
        public void Warn<T>(T value)
        {
            _logger.Warning(value.ToString());
        }

        /// <inheritdoc />
        public void Warn<T>(IFormatProvider formatProvider, T value)
        {
           _logger.Warning(string.Format(formatProvider, "{0}", value));
        }

        /// <inheritdoc />
        public void Warn(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
        {
           _logger.Warning(string.Format(formatProvider, message, args));
        }

        /// <inheritdoc />
        public void Warn([Localizable(false)] string message)
        {
           _logger.Warning(message);
        }

        /// <inheritdoc />
        public void Warn<T>([Localizable(false)] string message)
        {
            _logger.ForContext<T>().Warning(message);
        }

        /// <inheritdoc />
        public void Warn([Localizable(false)] string message, params object[] args)
        {
            _logger.Warning(message, args);
        }

        /// <inheritdoc />
        public void Warn<T>([Localizable(false)] string message, params object[] args)
        {
            _logger.ForContext<T>().Warning(message, args);
        }

        /// <inheritdoc />
        public void Warn<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
        {
            _logger.Warning(string.Format(formatProvider, message, argument));
        }

        /// <inheritdoc />
        public void Warn<TArgument>([Localizable(false)] string message, TArgument argument)
        {
            _logger.Warning(message, argument);
        }

        /// <inheritdoc />
        public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Warning(string.Format(formatProvider, message, argument1, argument2));
        }

        /// <inheritdoc />
        public void Warn<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
        {
            _logger.Warning(message, argument1, argument2);
        }

        /// <inheritdoc />
        public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Warning(string.Format(formatProvider, message, argument1, argument2, argument3));
        }

        /// <inheritdoc />
        public void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _logger.Warning(message, argument1, argument2, argument3);
        }

        /// <inheritdoc />
        public void WarnException([Localizable(false)] string message, Exception exception)
        {
            _logger.Warning(exception, message);
        }

        /// <inheritdoc />
        public void Write([Localizable(false)] string message, LogLevel logLevel)
        {
            _logger.Write(SerilogHelper.MappingsDictionary[logLevel], message);
        }

        /// <inheritdoc />
        public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
        {
            _logger.Write(SerilogHelper.MappingsDictionary[logLevel], exception, message);
        }

        /// <inheritdoc />
        public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
        {
            _logger.ForContext(type).Write(SerilogHelper.MappingsDictionary[logLevel], message);
        }

        /// <inheritdoc />
        public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
        {
            _logger.ForContext(type).Write(SerilogHelper.MappingsDictionary[logLevel], exception, message);
        }
    }
}
