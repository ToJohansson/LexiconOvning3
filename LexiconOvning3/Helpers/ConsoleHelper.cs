using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Helpers;

public static class ConsoleHelper
{
    public static void MessageOutput(string prompt)
    {
        Console.WriteLine(prompt);
    }
    public static string Ask(string prompt)
    {
        Console.Write(prompt + ": ");
        return Console.ReadLine();
    }
    public static string AskRequired(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt + ": ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("This field is required.");
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }


    public static int AskInt(string prompt)
    {
        Console.Write(prompt + ": ");
        return int.TryParse(Console.ReadLine(), out int result) ? result : 0;
    }

    public static double AskDouble(string prompt)
    {
        Console.Write(prompt + ": ");
        return double.TryParse(Console.ReadLine(), out double result) ? result : 0.0;
    }

    public static T AskEnum<T>(string prompt) where T : Enum
    {
        Console.WriteLine(prompt + ":");
        foreach (var value in Enum.GetValues(typeof(T)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }

        int choice = AskInt("Choose number");
        return (T)Enum.ToObject(typeof(T), choice);
    }

}
