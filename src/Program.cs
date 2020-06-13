using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

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
                await context.Response.WriteAsync(return new ContentResult
                 {
                  Content = @"
                  <html><body>
                  <h1>Hello world</h1>
                  Hello world. 
                  </body></html> ",
                ContentType = "text/html"
                  };              
                );
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
