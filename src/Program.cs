using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
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
                
                
    var proc = Process.GetCurrentProcess();
    var page = "<html><body><h1>HELLO-WORLD SAMPLE .NET Core</h1><h5>Environment</h5><p>"+RuntimeInformation.FrameworkDescription+"</p><p>"+RuntimeInformation.OSDescription+"</p>";
//page=page+"<h5>Metrics</h5><table width=500 align=center><tr><td>Containerized</td><td>"+Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") is object ? "true" : "false")+"</td></tr><tr><td>CPU cores</td>";
page=page+"<h5>Metrics</h5><table width=500 align=center><tr><td>Containerized</td><td>none</td></tr><tr><td>CPU cores</td>";
page=page+"<td>"+Environment.ProcessorCount+"</td></tr><tr><td>Memory, current usage (bytes)</td><td>"+proc.WorkingSet64+"</td></tr><tr><td>Memory, max available (bytes)</td><td>"+proc.MaxWorkingSet+"</td>";
page=page+"</body></html>";
                
                // Duplicate the code below and write more messages. Save and refresh your browser to see the result.
                //await context.Response.WriteAsync("Hello world. Make sure you run this app using 'dotnet watch run'.");
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
