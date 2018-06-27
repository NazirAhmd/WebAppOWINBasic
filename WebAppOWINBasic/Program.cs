using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppOWINBasic
{
    public class Program
    {
        static void Main()
        {
            string uri = @"http://localhost:5432";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Starting");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }
}