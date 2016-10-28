using System;
using System.Collections.Generic;

namespace ConsoleUtils.Net.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            "Colored Lines".ToConsole();
            "This is a blue line".ToConsole(ConsoleColor.Blue);
            "This is a red line".ToConsole(ConsoleColor.Red);
            var value = ConsoleColor.Cyan;
            var msg = $"This is a {value} line".ToConsole(value);
            "".NewLine(true);

            "Colored Values".ToConsole();
            "This is a ".ToConsole(ConsoleColor.Gray, false);
            $"{value}".ToConsole(value, false);
            " value".ToConsole();
            "".NewLine(true);

            "Set Clipboard".ToConsole();
            ConsoleClipboard.SetText(msg);
            $"{msg} copied to clipboard".ToConsole();
            "".NewLine(true);

            "Input Features".ToConsole();
            var input = "Please enter something:".AwaitConsoleInput();
            $"You entered {input}".ToConsole();
            "".NewLine(true);

            input = "Please enter one of these values:".AwaitConsoleInput(new List<string> { "Test", "Test12" });
            $"You entered {input}".ToConsole();
            "".NewLine(true);

            //With default value
            input = "Please enter one of these values:".AwaitConsoleInput(new List<string> { "Test", "Test12" }, "Test");
            $"You entered {input}".ToConsole();
            "".NewLine(true);

            input = "Please select one of these values:".AwaitConsoleSelection(new List<string> { "Test", "Test12" });
            $"You selected {input}".ToConsole();
            "".NewLine(true);

            //With default value
            input = "Please select one of these values:".AwaitConsoleSelection(new List<string> { "Test", "Test12" }, "Test12");
            $"You selected {input}".ToConsole();
            "".NewLine(true);

            //With default value
            var key = "Please Press Q or A".AwaitConsoleInput(new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.Q });
            $"You pressed {key}".ToConsole();
            "".NewLine(true);

            Console.ReadLine();
        }
    }
}
