using Lab7_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Feed1));
            host.Open();
            Console.WriteLine("Host Open");
            string s = Console.ReadLine();
        }
    }
}
