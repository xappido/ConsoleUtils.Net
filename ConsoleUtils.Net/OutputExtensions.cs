using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtils.Net
{
    public static class OutputExtensions
    {
        public static void ToConsole(this string output, ConsoleColor color = ConsoleColor.Gray, bool asLine = true)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (asLine)
            {
                Console.WriteLine(output);
            }
            else
            {
                Console.Write(output);
            }
            Console.ForegroundColor = prevColor;
        }
    }
}
