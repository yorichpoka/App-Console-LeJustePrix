using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models.Static
{
    public static class AppClass
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly Random random = new Random();

        #region string
        public static string AppNextLineBefore(this string value, int increment = 0)
        {
            return
               "\n".AppIncrement(increment) + value;
        }

        public static string AppNextLineAfter(this string value, int increment = 0)
        {
            return
                value + "\n".AppIncrement(increment);
        }

        public static string AppTabLineBefore(this string value, int increment = 0)
        {
            return
                "\t".AppIncrement(increment) + value;
        }

        public static string AppTabLineAfter(this string value, int increment = 0)
        {
            return
                value + "\t".AppIncrement(increment);
        }

        public static string AppIncrement(this string value, int increment)
        {
            if (increment < 0)
            {
                throw new ArgumentException("Increment must be grant thant 0.");
            }

            string result = string.Empty;

            do
            {
                result += value;
                increment--;
            } while (increment != -1);

            return
                result;
        }

        public static string AppIncrementBefore(this string value, string expression, int increment)
        {
            if (increment < 0)
            {
                throw new ArgumentException("Increment must be grant thant 0.");
            }

            string result = string.Empty;

            do
            {
                result += expression;
                increment--;
            } while (increment != -1);

            return
                result + value;
        }

        public static string AppIncrementAfter(this string value, string expression, int increment)
        {
            if (increment < 0)
            {
                throw new ArgumentException("Increment must be grant thant 0.");
            }

            string result = string.Empty;

            do
            {
                result += expression;
                increment--;
            } while (increment != -1);

            return
                value + result;
        }
        #endregion

        #region Console
        public static void ConsoleForegroundColor(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
        }

        public static string ConsoleReadLine()
        {
            string value = Console.ReadLine();

            if (new string[] { ".quit", ".exit" }.Contains(value))
            {
                Exit();
            }

            return value;
        }

        public static void Exit()
        {
            System.Environment.Exit(-1);
        }
        #endregion
    }
}
