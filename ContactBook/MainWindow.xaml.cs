using ContactBook.Commons;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            StartApiServer.PowerUpApiServer();
            InitializeComponent();
        }

        //public static IWebHost BuildApiWebHost(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config.SetBasePath(Directory.GetCurrentDirectory());
        //        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //    }).CaptureStartupErrors(true).UseUrls("https://localhost:44344/").UseKestrel()
        //    .UseStartup<ContactsWebApplication.Startup>()
        //    .Build();
        //}

        //public static void StartApiServer()
        //{
        //    string[] args = new string[0];
        //    var apiHost = BuildApiWebHost(args);
        //    var serverThread = new Thread(new ThreadStart(() =>
        //    {
        //        apiHost.Run();
        //    }));
        //    serverThread.IsBackground = true;
        //    serverThread.Start();
        //    Thread.Sleep(5000);
            
        //}
    }
}
