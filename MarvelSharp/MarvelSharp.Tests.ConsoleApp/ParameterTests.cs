using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public static class ParameterTests
    {
        private const int CharacterIdIronMan = 1009368;
        private const int CreatorIdBrianMichaelBendis = 24;
        private const int CreatorIdPaulNeary = 262;

        private static readonly Dictionary<int, string> MenuItems = new Dictionary<int, string>
        {
            { 1, "Get all characters starting with 'Da', ordered by Date Modified" },
            { 2, "Get all comics featuring Iron Man, which have a digital issue, ordered by Title descending" },
            { 3, "Get all events featuring Iron Man, ordered by descending Start Date, with work by Brian Michael Bendis or Paul Neary" },
            { 4, "Get all last week's comics, ordered by ascending Title" }
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
                    GetAllCharactersTest();
                    break;
                case 2:
                    GetCharacterComicsTest();
                    break;
                case 3:
                    GetCharacterEventsTest();
                    break;
                case 4:
                    GetLastWeeksComicsTest();
                    break;
                default:
                    return;
            }

            Console.ReadKey();
        }

        private static void DisplayMetaData<T>(Response<T> response)
        {
            Console.WriteLine($"RESPONSE: {response.Code} {response.Status}");
            Console.WriteLine($"ATTRIBUTION TEXT: {response.AttributionText}");
            Console.WriteLine();
            var data = response.Data;
            Console.WriteLine($"LIMIT: {data.Limit}");
            Console.WriteLine($"OFFSET: {data.Offset}");
            Console.WriteLine($"COUNT: {data.Count}");
            Console.WriteLine($"TOTAL: {data.Total}");
            Console.WriteLine();
        }

        private static void GetAllCharactersTest()
        {
            var response = Program.ApiService.GetAllCharactersAsync(
                null,
                null,
                new CharacterCriteria
                {
                    NameStartsWith = "Da",
                    OrderBy = new List<CharacterOrder> { CharacterOrder.ModifiedAscending }
                }).Result;
            DisplayMetaData(response);
            foreach (var item in response.Data.Result)
            {
                Console.WriteLine($"NAME: {item.Name}");
                Console.WriteLine($"MODIFIED: {item.Modified}");
                Console.WriteLine();
            }
        }

        private static void GetCharacterComicsTest()
        {
            var response = Program.ApiService.GetCharacterComicsAsync(
                CharacterIdIronMan,
                10,
                10,
                new ComicCriteria
                {
                    OrderBy = new List<ComicOrder> { ComicOrder.TitleDescending },
                    HasDigitalIssue = true
                }).Result;
            DisplayMetaData(response);
            foreach (var item in response.Data.Result)
            {
                Console.WriteLine($"NAME: {item.Title}");
                Console.WriteLine($"DIGITAL ID: {item.DigitalId}");
                Console.WriteLine($"CHARACTERS: {string.Join(", ", item.Characters.Items.Select(i => i.Name))}");
                Console.WriteLine();
            }
        }

        private static void GetCharacterEventsTest()
        {
            var response = Program.ApiService.GetCharacterEventsAsync(
                CharacterIdIronMan,
                null,
                null,
                new EventCriteria
                {
                    Creators = new List<int> { CreatorIdBrianMichaelBendis, CreatorIdPaulNeary },
                    OrderBy = new List<EventOrder> { EventOrder.StartDateDescending }
                }).Result;
            DisplayMetaData(response);
            foreach (var item in response.Data.Result)
            {
                Console.WriteLine($"TITLE: {item.Title}");
                Console.WriteLine($"START DATE: {item.Start}");
                Console.WriteLine($"CHARACTERS: {string.Join(", ", item.Characters.Items.Select(i => i.Name))}");
                Console.WriteLine($"CREATORS: {string.Join(", ", item.Creators.Items.Select(i => i.Name))}");
                Console.WriteLine();
            }
        }

        private static void GetLastWeeksComicsTest()
        {
            var response = Program.ApiService.GetAllComicsAsync(
                25,
                0,
                new ComicCriteria
                {
                    DateDescriptor = DateDescriptor.LastWeek,
                    OrderBy = new List<ComicOrder> { ComicOrder.TitleAscending }
                }).Result;
            DisplayMetaData(response);
            foreach (var item in response.Data.Result)
            {
                Console.WriteLine($"TITLE: {item.Title}");
                foreach (var date in item.Dates)
                {
                    Console.WriteLine($"{date.Type}: {date.Date}");
                }
                foreach (var price in item.Prices)
                {
                    Console.WriteLine($"{price.Type}: {price.Price}");
                }
                Console.WriteLine();
            }
        }
    }
}
