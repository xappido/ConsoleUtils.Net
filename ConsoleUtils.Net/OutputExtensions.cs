using System;

namespace ConsoleUtils.Net
{
    public static class OutputExtensions
    {
        public static string ToConsole(this string output, ConsoleColor color = ConsoleColor.Gray, bool asLine = true)
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

            return output;
        }
    }
}
