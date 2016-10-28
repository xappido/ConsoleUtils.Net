using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUtils.Net
{
    /// <summary>
    /// Provides a set of Console-Input Extensions
    /// </summary>
    public static class InputExtensions
    {
        /// <summary>
        /// Asks the user to enter some string value
        /// </summary>
        /// <param name="message">The entered message</param>
        /// <param name="messageColor">The color of the message</param>
        /// <returns>The entered user input</returns>
        public static string AwaitConsoleInput(this string message, ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            message.ToConsole(messageColor);
            "> ".ToConsole(ConsoleColor.White, false);
            return Console.ReadLine();
        }

        /// <summary>
        /// Asks the user for a specific string value and just returns if the value matches to the allowed values
        /// </summary>
        /// <param name="message">The entered message</param>
        /// <param name="allowedValues">All allowed values</param>
        /// <param name="defaultValue">The default value (will be entered if the user hits ENTER)</param>
        /// <param name="messageColor">The color of the message</param>
        /// <returns></returns>
        public static string AwaitConsoleInput(this string message, List<string> allowedValues, string defaultValue = null, ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            while (true)
            {
                message.ToConsole(messageColor);
                "[".ToConsole(ConsoleColor.Gray, false);
                var allowed = "";
                var hasDefaultValue = false;
                foreach (var allowedValue in allowedValues)
                {
                    if (!string.IsNullOrEmpty(allowed)) allowed += " | ";
                    allowed += allowedValue;
                    if (allowedValue.Equals(defaultValue))
                    {
                        hasDefaultValue = true;
                        allowed += "*";
                    }
                }
                allowed.ToConsole(ConsoleColor.DarkGray, false);
                "]".ToConsole();

                "> ".ToConsole(ConsoleColor.White, false);
                var ret = Console.ReadLine();

                if (hasDefaultValue && string.IsNullOrWhiteSpace(ret))
                {
                    return defaultValue;
                }

                if (!allowedValues.Any(a => a.Equals(ret)))
                {
                    continue;
                }

                return ret;
            }
        }

        /// <summary>
        /// Asks the user for a specific key input and just returns if the entered key matches one of the allowed keys
        /// </summary>
        /// <param name="message">The message to the user</param>
        /// <param name="allowedKeys">All allowed keys</param>
        /// <param name="messageColor">The color of the message</param>
        /// <returns></returns>
        public static ConsoleKey AwaitConsoleInput(this string message, List<ConsoleKey> allowedKeys, ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            while (true)
            {
                message.ToConsole(messageColor);

                "> ".ToConsole(ConsoleColor.White, false);
                var key = Console.ReadKey().Key;
                "".ToConsole();

                if (allowedKeys.All(k => k != key))
                {
                    messageColor = ConsoleColor.Cyan;
                    continue;
                }
                return key;
            }
        }

        /// <summary>
        /// Asks the user to select one of the entered values (like a combobox).
        /// </summary>
        /// <param name="message">The message to the user</param>
        /// <param name="items">All allowed items</param>
        /// <param name="defaultValue">The value of the default item (will be selected when user hits ENTER)</param>
        /// <param name="messageColor">The color of the message</param>
        /// <returns></returns>
        public static string AwaitConsoleSelection(this string message, List<string> items, string defaultValue = null, ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            while (true)
            {
                message.ToConsole(messageColor);

                var i = 0;
                var hasDefaultValue = false;
                foreach (var item in items)
                {
                    i++;
                    if (item.Equals(defaultValue))
                    {
                        hasDefaultValue = true;
                        $"{i} - {item}*".ToConsole();
                    }
                    else
                    {
                        $"{i} - {item}".ToConsole();
                    }
                }

                "> ".ToConsole(ConsoleColor.White, false);
                var selected = Console.ReadKey();

                if (hasDefaultValue && selected.Key == ConsoleKey.Enter)
                {
                    return defaultValue;
                }

                "".ToConsole();
                short keyNo;
                if (!short.TryParse(selected.KeyChar.ToString(), out keyNo) || keyNo < 1 || keyNo > i)
                {
                    continue;
                }

                return items[keyNo - 1];
            }
        }
    }
}
