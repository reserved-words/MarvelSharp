using MarvelSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelSharp.Model;
using MarvelSharp.Parameters;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class Program
    {
        private const int ReturnItems = 25;
        private const string PreviousPageCode = "<";
        private const string NextPageCode = ">";
        private const int PreviousPageValue = -1;
        private const int NextPageValue = -2;
        private static CharacterService _characterService;
        private static ComicService _comicService;
        private static EventService _eventService;
        private static SeriesService _seriesService;
        private static StoryService _storyService;
        private static CreatorService _creatorService;

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
            { "10", rd => GetList<Character, CharacterParameters>(_characterService.GetAllAsync, rd) },
            { "20", rd => GetList<Comic, ComicParameters>(_comicService.GetAllAsync, rd) },
            { "30", rd => GetList<Creator, CreatorParameters>(_creatorService.GetAllAsync, rd) },
            { "40", rd => GetList<Event, EventParameters>(_eventService.GetAllAsync, rd) },
            { "50", rd => GetList<Series, SeriesParameters>(_seriesService.GetAllAsync, rd) },
            { "60", rd => GetList<Story, StoryParameters>(_storyService.GetAllAsync, rd) },

            { "11", rd => new List<ItemBase> { _characterService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "22", rd => new List<ItemBase> { _comicService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "33", rd => new List<ItemBase> { _creatorService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "44", rd => new List<ItemBase> { _eventService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "55", rd => new List<ItemBase> { _seriesService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "66", rd => new List<ItemBase> { _storyService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            
            { "21", rd => GetList<Comic, ComicParameters>(_comicService.GetByCharacterAsync, rd) },
            { "41", rd => GetList<Event, EventParameters>(_eventService.GetByCharacterAsync, rd) },
            { "51", rd => GetList<Series, SeriesParameters>(_seriesService.GetByCharacterAsync, rd) },
            { "61", rd => GetList<Story, StoryParameters>(_storyService.GetByCharacterAsync, rd) },

            { "12", rd => GetList<Character, CharacterParameters>(_characterService.GetByComicAsync, rd) },
            { "32", rd => GetList<Creator, CreatorParameters>(_creatorService.GetByComicAsync, rd) },
            { "42", rd => GetList<Event, EventParameters>(_eventService.GetByComicAsync, rd) },
            { "62", rd => GetList<Story, StoryParameters>(_storyService.GetByComicAsync, rd) },

            { "23", rd => GetList<Comic, ComicParameters>(_comicService.GetByCreatorAsync, rd) },
            { "43", rd => GetList<Event, EventParameters>(_eventService.GetByCreatorAsync, rd) },
            { "53", rd => GetList<Series, SeriesParameters>(_seriesService.GetByCreatorAsync, rd) },
            { "63", rd => GetList<Story, StoryParameters>(_storyService.GetByCreatorAsync, rd) },

            { "14", rd => GetList<Character, CharacterParameters>(_characterService.GetByEventAsync, rd) },
            { "24", rd => GetList<Comic, ComicParameters>(_comicService.GetByEventAsync, rd) },
            { "34", rd => GetList<Creator, CreatorParameters>(_creatorService.GetByEventAsync, rd) },
            { "54", rd => GetList<Series, SeriesParameters>(_seriesService.GetByEventAsync, rd) },
            { "64", rd => GetList<Story, StoryParameters>(_storyService.GetByEventAsync, rd) },

            { "15", rd => GetList<Character, CharacterParameters>(_characterService.GetBySeriesAsync, rd) },
            { "25", rd => GetList<Comic, ComicParameters>(_comicService.GetBySeriesAsync, rd) },
            { "35", rd => GetList<Creator, CreatorParameters>(_creatorService.GetBySeriesAsync, rd) },
            { "45", rd => GetList<Event, EventParameters>(_eventService.GetBySeriesAsync, rd) },
            { "65", rd => GetList<Story, StoryParameters>(_storyService.GetBySeriesAsync, rd) },

            { "16", rd => GetList<Character, CharacterParameters>(_characterService.GetByStoryAsync, rd) },
            { "26", rd => GetList<Comic, ComicParameters>(_comicService.GetByStoryAsync, rd) },
            { "36", rd => GetList<Creator, CreatorParameters>(_creatorService.GetByStoryAsync, rd) },
            { "46", rd => GetList<Event, EventParameters>(_eventService.GetByStoryAsync, rd) },
            { "56", rd => GetList<Series, SeriesParameters>(_seriesService.GetByStoryAsync, rd) }
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

            _characterService = new CharacterService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            _comicService = new ComicService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            _eventService = new EventService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            _seriesService = new SeriesService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            _storyService = new StoryService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);
            _creatorService = new CreatorService(Properties.Settings.Default.PublicApiKey, Properties.Settings.Default.PrivateApiKey);

            MainMenu();
        }

        private static void MainMenu()
        {
            PrintHeader("Main Menu");

            DisplayMainMenuOptions();

            var input = ParseInput(false);

            if (input == null || !ItemTypesPlural.Keys.Contains(input.Value))
                return;

            DisplayRequestedList(new RequestDetails(input.Value, 1, null));
        }

        private static void DisplayMainMenuOptions()
        {
            foreach (var kvp in ItemTypesPlural)
            {
                Console.WriteLine($"{kvp.Key}\tFetch {kvp.Value}");
            }

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

        private static int? ParseInput(bool includeMainMenuOption = true)
        {
            if (includeMainMenuOption)
            {
                Console.WriteLine(0 + "\t" + "Back to Main Menu");
                Console.WriteLine(); 
            }

            var input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    MainMenu();
                    return null;
                case NextPageCode:
                    return NextPageValue;
                case PreviousPageCode:
                    return PreviousPageValue;
            }

            int inputInt;
            return int.TryParse(input, out inputInt)
                ? inputInt
                : (int?)null;
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

            var input = ParseInput();

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

            var input = ParseInput();

            switch (input)
            {
                case null:
                    return;
                case PreviousPageValue:
                    DisplayRequestedList(rd.PreviousRequest);
                    return;
                case NextPageValue:
                    DisplayRequestedList(new RequestDetails(rd.FetchType, rd.Page + 1, rd.ItemType, rd.ItemId, rd.ItemName, rd));
                    return;
            }

            var selectedItem = list.Single(i => i.Id == input);

            var newListDetails = new RequestDetails(rd.FetchType, 1, rd.FetchType, selectedItem.Id ?? 0, selectedItem.ToString(), rd);

            DisplayRequestedItem(newListDetails);
        }

        private static void PrintHeader(string header)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(header.ToUpper());
            Console.WriteLine("------------------------------------------------------");
        }

        private static List<ItemBase> GetList<T1, T2>(Func<int?, int?, T2, Task<Response<List<T1>>>> method, RequestDetails rd) where T1 : ItemBase where T2 : ParametersBase
        {
            return method(ReturnItems, (rd.Page - 0) * ReturnItems, null).Result.Data.Result.OfType<ItemBase>().ToList();
        }

        private static List<ItemBase> GetList<T1, T2>(Func<int, int?, int?, T2, Task<Response<List<T1>>>> method, RequestDetails rd) where T1 : ItemBase where T2 : ParametersBase
        {
            return method(rd.ItemId, ReturnItems, (rd.Page - 0) * ReturnItems, null).Result.Data.Result.OfType<ItemBase>().ToList();
        }
    }
}
