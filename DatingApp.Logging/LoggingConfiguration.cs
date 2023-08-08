using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;
using Serilog.AspNetCore;
using Serilog.Events;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Microsoft.AspNetCore.Builder;

namespace DatingApp.Logging
{
    public static class LoggingConfiguration
    {
        private static readonly string outputTemplate =
            @"[{Timestamp:yy-MM-dd HH:mm:ss} {Level}]{ApplicationName}:{SourceContext}{NewLine}Message:{Message}{NewLine}in method {MemberName} at {FilePath}:{LineNumber}{NewLine}{Exception}{NewLine}";

        public static WebApplicationBuilder ConfigureSeriLog(this WebApplicationBuilder builder)
        {
            builder.Host
                .ConfigureLogging((context, logging) => { logging.ClearProviders(); })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    var config = hostingContext.Configuration;
                    var restrinctedToMinimumLevel = config["Logging:restrictedToMinimumLevel"].ToString();
                    if (!Enum.TryParse<LogEventLevel>(restrinctedToMinimumLevel, out var logLevel))
                    {
                        logLevel = LogEventLevel.Debug;
                    }

                    loggerConfiguration
                    .Enrich.FromLogContext()
                    .WriteTo.File(
                        path: "ErrorLog.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: logLevel,
                        outputTemplate: outputTemplate)
                    .WriteTo.Console(restrictedToMinimumLevel: logLevel);
                    
                });
            return builder;
        }
    }
}
