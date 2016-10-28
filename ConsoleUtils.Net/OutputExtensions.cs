using System;

namespace ConsoleUtils.Net
{
    /// <summary>
    /// Provides a set of output extensions for the Console
    /// </summary>
    public static class OutputExtensions
    {
        /// <summary>
        /// Writes a string to the console with the selected color.
        /// </summary>
        /// <param name="output">The string</param>
        /// <param name="color">The used color for the output</param>
        /// <param name="asLine">Defines whetere it's a complete line or part</param>
        /// <returns>The output for reuse</returns>
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

        /// <summary>
        /// Creates a new line
        /// </summary>
        /// <param name="output">not used</param>
        /// <param name="hasLine">defines wheter its a line or not</param>
        /// <param name="color">The color of the line</param>
        public static void NewLine(this string output, bool hasLine = true, ConsoleColor color = ConsoleColor.Gray)
        {
            if (!hasLine)
            {
                "".ToConsole();
                return;
            }

            var line = "";
            for (var i = 0; i < Console.BufferWidth -1; i++)
            {
                line += "_";
            }
            line.ToConsole(color);
            "".ToConsole();
        }
    }
}
