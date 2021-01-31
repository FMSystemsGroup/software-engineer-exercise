﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystems.Server
{

#pragma warning disable CS1591



    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.ConfigureLogging((hostingContext, logging) =>
                    {
                        logging.ClearProviders();
                        logging.AddDebug();
                        logging.AddConsole();
                    });

                    webBuilder.UseStartup<Startup>();

                });
    }


#pragma warning restore CS1591
}
