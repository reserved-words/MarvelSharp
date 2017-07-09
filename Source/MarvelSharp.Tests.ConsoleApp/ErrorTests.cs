using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public static class ErrorTests
    {
        private static readonly Dictionary<int, string> MenuItems = new Dictionary<int, string>
        {
            { 1, "Get all characters with limit greater than 100" },
            { 2, "Get all characters with limit below 1" },
            { 3, "Get character with invalid ID" },
            { 4, "Get all characters with too many values sent to multi-value list filter" },
            { 5, "Make request with invalid API key" }
        };

        public static void DisplayOptions()
        {
            foreach (var kvp in MenuItems)
            {
                Console.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }

            Console.WriteLine();

            var input = InputHelper.ParseInput();

            if (input == null)
                return;

            if (input == 0)
                Program.MainMenu();

            Execute(input.Value);
        }

        private static void Execute(int option)
        {
            switch (option)
            {
                case 1:
                    GetAllCharactersWithLimitGreaterThan100();
                    break;
                case 2:
                    GetAllCharactersWithLimitBelow1();
                    break;
                case 3:
                    GetCharacterWithInvalidId();
                    break;
                case 4:
                    GetAllCharactersWithTooManyValuesForMultiValueParameter();
                    break;
                case 5:
                    MakeRequestWithInvalidApiKey();
                    break;
                default:
                    return;
            }

            Console.WriteLine();
            DisplayOptions();

            Console.ReadKey();
        }

        private static void DisplayMetaData<T>(Response<T> response)
        {
            Console.WriteLine($"RESPONSE: {response.Code} {response.Status}");
        }

        private static void GetAllCharactersWithLimitGreaterThan100()
        {
            var response = Program.ApiService.GetAllCharactersAsync(101).Result;

            DisplayMetaData(response);
        }

        private static void GetAllCharactersWithLimitBelow1()
        {
            var response = Program.ApiService.GetAllCharactersAsync(-1).Result;

            DisplayMetaData(response);
        }

        private static void GetCharacterWithInvalidId()
        {
            var response = Program.ApiService.GetCharacterByIdAsync(1).Result;

            DisplayMetaData(response);
        }

        private static void GetAllCharactersWithTooManyValuesForMultiValueParameter()
        {
            var comics = Enumerable.Range(1, 200).ToList();
            var response = Program.ApiService.GetAllCharactersAsync(null, null, new CharacterCriteria { Comics = comics }).Result;

            DisplayMetaData(response);
        }

        private static void MakeRequestWithInvalidApiKey()
        {
            var apiService = new ApiService("testingInvalidApiKey", "testingInvalidApiKey");
            var response = apiService.GetAllCharactersAsync().Result;

            DisplayMetaData(response);
        }
    }
}
