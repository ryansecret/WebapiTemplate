using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace Ryan
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];

            Console.WriteLine("Started successfully,address:");
            Console.WriteLine(baseUrl);
            var server = WebApp.Start<Startup>(new StartOptions(baseUrl));
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

            Console.WriteLine("Terminating.");
            server.Dispose();
        }
    }
}