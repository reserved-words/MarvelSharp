using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class Program
    {
        internal const int ReturnItems = 25;
        internal const string PreviousPageCode = "<";
        internal const string NextPageCode = ">";
        internal const int PreviousPageValue = -1;
        internal const int NextPageValue = -2;
        internal static ApiService ApiService;

        private static readonly Dictionary<int, string> ItemTypesPlural = new Dictionary<int, string>
        {
            { 1, "Characters" },
            { 2, "Comics" },
            { 3, "Creators" },
            { 4, "Events" },
            { 5, "Series" },
            { 6, "Stories" }
        };

        private static readonly Dictionary<string, Func<RequestDetails,List<ItemBase>>> MethodDictionary  = new Dictionary<string, Func<RequestDetails, List<ItemBase>>>
        {
            { "10", rd => GetList<Character, CharacterCriteria>(ApiService.GetAllCharactersAsync, rd) },
            { "20", rd => GetList<Comic, ComicCriteria>(ApiService.GetAllComicsAsync, rd) },
            { "30", rd => GetList<Creator, CreatorCriteria>(ApiService.GetAllCreatorsAsync, rd) },
            { "40", rd => GetList<Event, EventCriteria>(ApiService.GetAllEventsAsync, rd) },
            { "50", rd => GetList<Series, SeriesCriteria>(ApiService.GetAllSeriesAsync, rd) },
            { "60", rd => GetList<Story, StoryCriteria>(ApiService.GetAllStoriesAsync, rd) },

            { "11", rd => new List<ItemBase> { ApiService.GetCharacterByIdAsync(rd.ItemId).Result.Data.Result } },
            { "22", rd => new List<ItemBase> { ApiService.GetComicByIdAsync(rd.ItemId).Result.Data.Result } },
            { "33", rd => new List<ItemBase> { ApiService.GetCreatorByIdAsync(rd.ItemId).Result.Data.Result } },
            { "44", rd => new List<ItemBase> { ApiService.GetEventByIdAsync(rd.ItemId).Result.Data.Result } },
            { "55", rd => new List<ItemBase> { ApiService.GetSeriesByIdAsync(rd.ItemId).Result.Data.Result } },
            { "66", rd => new List<ItemBase> { ApiService.GetStoryByIdAsync(rd.ItemId).Result.Data.Result } },
            
            { "21", rd => GetList<Comic, ComicCriteria>(ApiService.GetCharacterComicsAsync, rd) },
            { "41", rd => GetList<Event, EventCriteria>(ApiService.GetCharacterEventsAsync, rd) },
            { "51", rd => GetList<Series, SeriesCriteria>(ApiService.GetCharacterSeriesAsync, rd) },
            { "61", rd => GetList<Story, StoryCriteria>(ApiService.GetCharacterStoriesAsync, rd) },

            { "12", rd => GetList<Character, CharacterCriteria>(ApiService.GetComicCharactersAsync, rd) },
            { "32", rd => GetList<Creator, CreatorCriteria>(ApiService.GetComicCreatorsAsync, rd) },
            { "42", rd => GetList<Event, EventCriteria>(ApiService.GetComicEventsAsync, rd) },
            { "62", rd => GetList<Story, StoryCriteria>(ApiService.GetComicStoriesAsync, rd) },

            { "23", rd => GetList<Comic, ComicCriteria>(ApiService.GetCreatorComicsAsync, rd) },
            { "43", rd => GetList<Event, EventCriteria>(ApiService.GetCreatorEventsAsync, rd) },
            { "53", rd => GetList<Series, SeriesCriteria>(ApiService.GetCreatorSeriesAsync, rd) },
            { "63", rd => GetList<Story, StoryCriteria>(ApiService.GetCreatorStoriesAsync, rd) },

            { "14", rd => GetList<Character, CharacterCriteria>(ApiService.GetEventCharactersAsync, rd) },
            { "24", rd => GetList<Comic, ComicCriteria>(ApiService.GetEventComicsAsync, rd) },
            { "34", rd => GetList<Creator, CreatorCriteria>(ApiService.GetEventCreatorsAsync, rd) },
            { "54", rd => GetList<Series, SeriesCriteria>(ApiService.GetEventSeriesAsync, rd) },
            { "64", rd => GetList<Story, StoryCriteria>(ApiService.GetEventStoriesAsync, rd) },

            { "15", rd => GetList<Character, CharacterCriteria>(ApiService.GetSeriesCharactersAsync, rd) },
            { "25", rd => GetList<Comic, ComicCriteria>(ApiService.GetSeriesComicsAsync, rd) },
            { "35", rd => GetList<Creator, CreatorCriteria>(ApiService.GetSeriesCreatorsAsync, rd) },
            { "45", rd => GetList<Event, EventCriteria>(ApiService.GetSeriesEventsAsync, rd) },
            { "65", rd => GetList<Story, StoryCriteria>(ApiService.GetSeriesStoriesAsync, rd) },

            { "16", rd => GetList<Character, CharacterCriteria>(ApiService.GetStoryCharactersAsync, rd) },
            { "26", rd => GetList<Comic, ComicCriteria>(ApiService.GetStoryComicsAsync, rd) },
            { "36", rd => GetList<Creator, CreatorCriteria>(ApiService.GetStoryCreatorsAsync, rd) },
            { "46", rd => GetList<Event, EventCriteria>(ApiService.GetStoryEventsAsync, rd) },
            { "56", rd => GetList<Series, SeriesCriteria>(ApiService.GetStorySeriesAsync, rd) }
        };

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

            ApiService = new ApiService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            
            MainMenu();
        }

        internal static void MainMenu()
        {
            PrintHeader("Main Menu");

            DisplayMainMenuOptions();

            var input = InputHelper.ParseMainMenuInput();
            
            if (input == null)
                return;

            if (input.Item1 == 8)
                ErrorTests.DisplayOptions();

            if (input.Item1 == 9)
                ParameterTests.DisplayOptions();

            if (!ItemTypesPlural.Keys.Contains(input.Item1))
                return;
            
            DisplayRequestedList(new RequestDetails(input.Item1, input.Item2, input.Item3, 1, null));
        }

        private static void DisplayMainMenuOptions()
        {
            foreach (var kvp in ItemTypesPlural)
            {
                Console.WriteLine($"{kvp.Key}\tFetch {kvp.Value}");
            }

            Console.WriteLine();
            Console.WriteLine($"8\tExamples with Errors");
            Console.WriteLine($"9\tExamples with Criteria");
            Console.WriteLine();
            Console.WriteLine("Type an option number, optionally followed by a character (to return only results starting with that character)");
            Console.WriteLine("and a date (format YYYY-MM-DD, to return only results modified since that date).");
            Console.WriteLine("Arguments should be separated by one space.");
            Console.WriteLine();
        }

        private static void DisplayRequestedList(RequestDetails rd)
        {
            if (rd.FetchType == rd.ItemType)
            {
                DisplayRequestedItem(rd);
            }

            var list = FetchItems(rd);

            PrintHeader((rd.ItemId == 0
                ? "ALL " + ItemTypesPlural[rd.FetchType]
                : ItemTypesPlural[rd.FetchType] + " for " + rd.ItemName) + " (PAGE " + rd.Page + ")");

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + "\t" + item);
            }

            Console.WriteLine();

            DisplayItemListOptions(rd, list);
        }

        private static void DisplayRequestedItem(RequestDetails rd)
        {
            var item = FetchItems(rd).Single();

            PrintHeader(item.ToString());

            DisplayHelper.DisplayItemDetails(item);

            DisplayItemOptions(item, rd);
        }

        private static List<ItemBase> FetchItems(RequestDetails rd)
        {
            var combinedTypes = rd.FetchType.ToString() + rd.ItemType.ToString();
            
            return MethodDictionary[combinedTypes](rd);
        }

        private static void DisplayItemOptions(ItemBase item, RequestDetails rd)
        {
            foreach (var kvp in ItemTypesPlural)
            {
                if (kvp.Key == rd.ItemType)
                    continue;

                if (!MethodDictionary.Keys.Contains(kvp.Key.ToString() + rd.ItemType.ToString()))
                    continue;

                Console.WriteLine($"{kvp.Key}\tFetch {kvp.Value}");
            }

            Console.WriteLine();

            if (rd.PreviousRequest != null)
            {
                Console.WriteLine($"{PreviousPageCode}\tPrevious page");
            }

            var input = InputHelper.ParseInput();

            switch (input)
            {
                case null:
                    return;
                case PreviousPageValue:
                    DisplayRequestedList(rd.PreviousRequest);
                    return;
                default:
                    DisplayRequestedList(new RequestDetails(
                        input ?? 0, 
                        "",
                        null,
                        1, 
                        rd.ItemType, 
                        rd.ItemId, 
                        item.ToString(), 
                        rd));
                    break;
            }            
        }

        private static void DisplayItemListOptions(RequestDetails rd, IEnumerable<ItemBase> list)
        {
            Console.WriteLine("Type ID to view further details");
            Console.WriteLine();

            if (rd.PreviousRequest != null)
            {
                Console.WriteLine($"{PreviousPageCode}\tPrevious page");
            }

            Console.WriteLine($"{NextPageCode}\tNext Page");

            var input = InputHelper.ParseInput();

            switch (input)
            {
                case null:
                    return;
                case PreviousPageValue:
                    DisplayRequestedList(rd.PreviousRequest);
                    return;
                case NextPageValue:
                    DisplayRequestedList(new RequestDetails(rd.FetchType, rd.FetchStartingWith, rd.FetchModifiedSince, rd.Page + 1, rd.ItemType, rd.ItemId, rd.ItemName, rd));
                    return;
            }

            var selectedItem = list.Single(i => i.Id == input);

            var newListDetails = new RequestDetails(rd.FetchType, rd.FetchStartingWith, rd.FetchModifiedSince, 1, rd.FetchType, selectedItem.Id ?? 0, selectedItem.ToString(), rd);

            DisplayRequestedItem(newListDetails);
        }

        private static void PrintHeader(string header)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(header.ToUpper());
            Console.WriteLine("------------------------------------------------------");
        }

        private static List<ItemBase> GetList<T1, T2>(Func<int?, int?, T2, Task<Response<List<T1>>>> method, RequestDetails rd) where T1 : ItemBase where T2 : BaseCriteria
        {
            BaseCriteria criteria = null;

            var parameterType = typeof(T2).Name;

            switch (parameterType)
            {
                case nameof(CharacterCriteria):
                    criteria = new CharacterCriteria { NameStartsWith = rd.FetchStartingWith, ModifiedSince = rd.FetchModifiedSince };
                    break;
                case nameof(ComicCriteria):
                    criteria = new ComicCriteria { TitleStartsWith = rd.FetchStartingWith, ModifiedSince = rd.FetchModifiedSince };
                    break;
                case nameof(CreatorCriteria):
                    criteria = new CreatorCriteria { NameStartsWith = rd.FetchStartingWith, ModifiedSince = rd.FetchModifiedSince };
                    break;
                case nameof(EventCriteria):
                    criteria = new EventCriteria { NameStartsWith = rd.FetchStartingWith, ModifiedSince = rd.FetchModifiedSince };
                    break;
                case nameof(SeriesCriteria):
                    criteria = new SeriesCriteria { TitleStartsWith = rd.FetchStartingWith, ModifiedSince = rd.FetchModifiedSince };
                    break;
            }

            return method(ReturnItems, (rd.Page - 1) * ReturnItems, (T2)criteria).Result.Data.Result.OfType<ItemBase>().ToList();
        }

        private static List<ItemBase> GetList<T1, T2>(Func<int, int?, int?, T2, Task<Response<List<T1>>>> method, RequestDetails rd) where T1 : ItemBase where T2 : BaseCriteria
        {
            return method(rd.ItemId, ReturnItems, (rd.Page - 1) * ReturnItems, null).Result.Data.Result.OfType<ItemBase>().ToList();
        }
    }
}
