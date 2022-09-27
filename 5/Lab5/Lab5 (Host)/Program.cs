using Lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lab5__Host_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host =new ServiceHost(typeof(Simplex));
            host.Open();
            Console.WriteLine("Service has been started");
            Console.ReadLine();
        }
    }
}
