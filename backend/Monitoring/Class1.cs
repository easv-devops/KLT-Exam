﻿using System.Net;
using Serilog;

namespace Monitoring;

public static class MonitorService
{
    public static ILogger Log => Serilog.Log.Logger;

    static MonitorService()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.Seq(Environment.GetEnvironmentVariable("seq")!)
            .CreateLogger();
    }
}