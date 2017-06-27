using MarvelSharp.Parameters;
using MarvelSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.PublicApiKey))
            {
                Console.WriteLine("Enter public API key:");
                Properties.Settings.Default.PublicApiKey = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.WriteLine();
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.PrivateApiKey))
            {
                Console.WriteLine("Enter private API key:");
                Properties.Settings.Default.PrivateApiKey = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.WriteLine();
            }

            var characterService = new CharacterService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            var comicService = new ComicService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            var eventService = new EventService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            var seriesService = new SeriesService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);

            TestGetComicsByCharacter(comicService);
            TestGetAll(characterService);
            TestGetById(characterService);
            TestGetEventsByCharacter(eventService);
            TestGetSeries(seriesService);
            TestGetAllComics(comicService);

            Console.ReadKey();
        }

        private static void TestGetAll(CharacterService service)
        {
            var parameters = new CharacterParameters
            {
                NameStartsWith = "Captain",
                OrderBy = Enums.CharacterOrder.NameDescending,
                Limit = 100
            };

            var response = service.GetAllAsync(parameters).Result;
            
            if (!response.Success)
            {
                Console.WriteLine("ERROR: " + response.Code + " " + response.Status);
                return;
            }

            Console.WriteLine(response.Code);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Copyright);
            Console.WriteLine(response.AttributionText);

            foreach (var character in response.Data.Result)
            {
                Console.WriteLine(character.Name);
                Console.WriteLine(character.Description);
            }
        }

        private static void TestGetById(CharacterService service)
        {
            var response = service.GetByIdAsync(1011334).Result;

            Console.WriteLine(response.Data.Result.Name);
        }

        private static void TestGetComicsByCharacter(ComicService service)
        {
            var response = service.GetByCharacterAsync(1011334).Result;

            foreach (var comic in response.Data.Result)
            {
                Console.WriteLine(comic.Title);
                Console.WriteLine(comic.Description);
                Console.WriteLine("Characters: " + GetListDescription(comic.Characters.Items.Select(c => c.Name).ToList()));
                Console.WriteLine("-");
            }
        }

        private static void TestGetEventsByCharacter(EventService service)
        {
            var response = service.GetByCharacterAsync(1011334).Result;

            foreach (var e in response.Data.Result)
            {
                Console.WriteLine(e.Title);
                Console.WriteLine(e.Description);
                Console.WriteLine("Characters: " + GetListDescription(e.Characters.Items.Select(c => c.Name).ToList()));
                Console.WriteLine("-");
            }
        }

        private static void TestGetSeries(SeriesService service)
        {
            var response = service.GetByCharacterAsync(1011334).Result;

            foreach (var series in response.Data.Result)
            {
                Console.WriteLine(series.Title);
                Console.WriteLine(series.Description);
                Console.WriteLine("Characters: " + GetListDescription(series.Characters.Items.Select(c => c.Name).ToList()));
                Console.WriteLine("-");
            }
        }

        private static string GetListDescription(List<string> list)
        {
            return string.Join(", ", list);
        }

        private static void TestGetAllComics(ComicService service)
        {
            var response = service.GetAllAsync().Result;

            foreach (var comic in response.Data.Result)
            {
                Console.WriteLine(comic.Title);
                Console.WriteLine(comic.Description);
                Console.WriteLine("Characters: " + GetListDescription(comic.Characters.Items.Select(c => c.Name).ToList()));
                Console.WriteLine("-");
            }
        }
    }
}
