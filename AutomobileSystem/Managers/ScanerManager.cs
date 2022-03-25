using AutomobileSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem.Managers
{
    public static class ScanerManager
    {
        public static int ReadInteger(string message)
        {
            l1:            
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                PrintError("Wrong information!!! Please repeat add it");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static double ReadDouble(string message)
        {
        l1:
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("Wrong information!!! Please repeat add it");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static string ReadString(string message)
        {
            l1:

            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Wrong information!!! Please repeat add it");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static Menu ReadMenu(string message)
        {
            l1:

            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {
                PrintError("Please,select from menu");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static BodyType ReadBodyMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out BodyType m))
            {
                PrintError("Please,select from menu");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static FuelType ReadFuelMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out FuelType m))
            {
                PrintError("Please,select from menu");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
    }
}
