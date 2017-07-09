using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests.ConsoleApp
{
    public static class InputHelper
    {
        public static int? ParseInput()
        {
            Console.WriteLine(0 + "\t" + "Back to Main Menu");
            Console.WriteLine();

            var input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Program.MainMenu();
                    return null;
                case Program.NextPageCode:
                    return Program.NextPageValue;
                case Program.PreviousPageCode:
                    return Program.PreviousPageValue;
            }

            int inputInt;
            return int.TryParse(input, out inputInt)
                ? inputInt
                : (int?)null;
        }

        public static Tuple<int, string, DateTime?> ParseMainMenuInput()
        {
            var input = Console.ReadLine()?.Split(' ');

            if (input == null)
                return null;

            var option = int.Parse(input[0]);

            string startsWith = null;
            DateTime modifiedSince = DateTime.MinValue;

            for (var i = 1; i < 3; i++)
            {
                if (input.Length > i)
                {
                    if (modifiedSince == DateTime.MinValue && DateTime.TryParse(input[i], out modifiedSince))
                    {
                        continue;
                    }

                    if (startsWith == null)
                    {
                        startsWith = input[i];
                    }
                }
            }

            return new Tuple<int, string, DateTime?>(option, startsWith, modifiedSince == DateTime.MinValue ? (DateTime?)null : modifiedSince);
        }
    }
}
