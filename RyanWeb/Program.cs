using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Ryan;

namespace RyanWeb
{
    class Program
    {
        static void Main(string[] args)
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
