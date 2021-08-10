using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//Add System libs for info system
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PracticalAspNetCore
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("Application Started.");
                var  os = "unknown";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                   { Console.WriteLine("Application running on Windows!"); os = "Windows";}
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                   { Console.WriteLine("Application running on Linux!"); os = "Linux";}
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                   { Console.WriteLine("Application running on MacOS!"); os = "MacOS";}
                else
                    Console.WriteLine("System unknown.");

                var proc = Process.GetCurrentProcess();
                var page = @"<html><body><h1 align=center>SYS-INFO SAMPLE .NET Core</h1>
                             <h2 align=center>Environment</h2>
                             <p align=center>"+os+@"</p>
                             <p align=center>"+RuntimeInformation.FrameworkDescription+@"</p>
                             <p align=center>"+RuntimeInformation.OSDescription+@"</p> 
                             <h2 align=center>Metrics</h2><table width=500 align=center><tr></td></tr><tr>
                             <td>CPU cores</td><td>"+Environment.ProcessorCount+@"</td></tr>
                             <tr><td>Memory, current usage (bytes)</td><td>"+proc.WorkingSet64+@"</td></tr>
                             <tr><td>Memory, max available (bytes)</td><td>"+proc.MaxWorkingSet+@"</td>
                             </body></html>";
                await context.Response.WriteAsync(page);
            });
        }
    }

    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>()
                );
    }
}
