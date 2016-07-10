using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // Console.WriteLine("Hello World Tertulia Company!");

           var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("Pre Processing");

                await next();

                await context.Response.WriteAsync("<h1>Post Processing</h1>");
            });

            app.Run(async (context) => 
            {
                await context.Response.WriteAsync(
                    "Hello World Tertulia Inc The time is : " 
                    + DateTime.Now.ToString("hh:mm:ss tt") 
                );
            });
        }
    }   
}

