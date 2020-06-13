using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace PracticalAspNetCore
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                // Duplicate the code below and write more messages. Save and refresh your browser to see the result.
                //await context.Response.WriteAsync("Hello world. Make sure you run this app using 'dotnet watch run'.");
                var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
                var memory = 0.0;
                Process proc = Process.GetCurrentProcess();
                memory = Math.Round(proc.PrivateMemorySize64 / 1024*1024, 2);
                proc.Dispose();
                await context.Response.WriteAsync("<html><body><h1>Hello world</h1><b>System:</b> "+memory+"</body></html> ");
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
