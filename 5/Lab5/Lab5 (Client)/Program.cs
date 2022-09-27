using Lab5__Client_.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5__Client_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string binding = "BasicHttpBinding_ISimplex";
            //string binding = "tcpEndpoint";

            SimplexClient simplexClient = new SimplexClient(binding);

            Console.WriteLine("Method add for int and int: " + simplexClient.Add(1, 3));

            Console.WriteLine("Method concat for str and double: " + simplexClient.Concat("str", 3));

            Lab5.A a = simplexClient.Sum(new Lab5.A { f = 3.2f, k = 1, s = "4" }, new Lab5.A { f = 1.3f, k = 2, s = "12" });
            Console.WriteLine($"Result of sum object: f = {a.f} k = {a.k} s = {a.s}");

            Console.ReadKey();
            simplexClient.Close();

        }
    }
}
