using ConsoleUtils.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtils.Net.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            "This is a blue line".ToConsole(ConsoleColor.Blue);
            "This is a red line".ToConsole(ConsoleColor.Red);

            var value = "Test";
            $"This is a {value} Value".ToConsole(ConsoleColor.Cyan);
            Console.ReadLine();
        }
    }
}
