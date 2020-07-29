using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DockerTesterService
{
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
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opts =>
                    {
                        // Bind directly to a socket handle or Unix socket
                        // opts.ListenHandle(123554);
                        // opts.ListenUnixSocket("/tmp/kestrel-test.sock");
                        //opts.Listen(IPAddress.Loopback, port: 5002);
                       // opts.ListenAnyIP(5101);
                       // opts.ListenAnyIP(5102);
                       // opts.ListenAnyIP(5103);
                        //opts.ListenLocalhost(5101, opts => opts.UseHttps());
                        //opts.ListenLocalhost(5102, opts => opts.UseHttps());
                        //opts.ListenLocalhost(5103, opts => opts.UseHttps());
                    });
                });
    }
}
