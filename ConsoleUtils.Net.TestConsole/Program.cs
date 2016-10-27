using System;

namespace ConsoleUtils.Net.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            "This is a blue line".ToConsole(ConsoleColor.Blue);
            "This is a red line".ToConsole(ConsoleColor.Red);

            var value = ConsoleColor.Cyan;
            var msg = $"This is a {value} line".ToConsole(value);

            ConsoleClipboard.SetText(msg);

            $"This is a ".ToConsole(ConsoleColor.Gray, false);
            $"{value}".ToConsole(value, false);
            " value".ToConsole(ConsoleColor.Gray, false);
            Console.ReadLine();
        }
    }
}
