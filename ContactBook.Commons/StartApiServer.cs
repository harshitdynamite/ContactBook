using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace ContactBook.Commons
{
    public class StartApiServer
    {
        public static IWebHost BuildApiWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            }).CaptureStartupErrors(true).UseUrls("https://localhost:44344/").UseKestrel()
            .UseStartup<ContactsWebApplication.Startup>()
            .Build();
        }

        public static void PowerUpApiServer()
        {
            string[] args = new string[0];
            var apiHost = BuildApiWebHost(args);
            var serverThread = new Thread(new ThreadStart(() =>
            {
                apiHost.Run();
            }));
            serverThread.IsBackground = true;
            serverThread.Start();
            Thread.Sleep(5000);

        }
    }
}
