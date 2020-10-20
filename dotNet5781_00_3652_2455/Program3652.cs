using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_3652_2455
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome3652();
            Welcome2455();
            Console.ReadKey();
        }

        static partial void Welcome2455();

        private static void Welcome3652()
        {
            Console.Write("Enter your name: ");
            String name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}
