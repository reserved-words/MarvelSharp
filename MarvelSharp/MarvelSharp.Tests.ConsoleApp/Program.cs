using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            { "10", rd => GetList<Character, CharacterCriteria>(_characterService.GetAllAsync, rd) },
            { "20", rd => GetList<Comic, ComicCriteria>(_comicService.GetAllAsync, rd) },
            { "30", rd => GetList<Creator, CreatorCriteria>(_creatorService.GetAllAsync, rd) },
            { "40", rd => GetList<Event, EventCriteria>(_eventService.GetAllAsync, rd) },
            { "50", rd => GetList<Series, SeriesCriteria>(_seriesService.GetAllAsync, rd) },
            { "60", rd => GetList<Story, StoryCriteria>(_storyService.GetAllAsync, rd) },

            { "11", rd => new List<ItemBase> { _characterService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "22", rd => new List<ItemBase> { _comicService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "33", rd => new List<ItemBase> { _creatorService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "44", rd => new List<ItemBase> { _eventService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "55", rd => new List<ItemBase> { _seriesService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            { "66", rd => new List<ItemBase> { _storyService.GetByIdAsync(rd.ItemId).Result.Data.Result } },
            
            { "21", rd => GetList<Comic, ComicCriteria>(_comicService.GetByCharacterAsync, rd) },
            { "41", rd => GetList<Event, EventCriteria>(_eventService.GetByCharacterAsync, rd) },
            { "51", rd => GetList<Series, SeriesCriteria>(_seriesService.GetByCharacterAsync, rd) },
            { "61", rd => GetList<Story, StoryCriteria>(_storyService.GetByCharacterAsync, rd) },

            { "12", rd => GetList<Character, CharacterCriteria>(_characterService.GetByComicAsync, rd) },
            { "32", rd => GetList<Creator, CreatorCriteria>(_creatorService.GetByComicAsync, rd) },
            { "42", rd => GetList<Event, EventCriteria>(_eventService.GetByComicAsync, rd) },
            { "62", rd => GetList<Story, StoryCriteria>(_storyService.GetByComicAsync, rd) },

            { "23", rd => GetList<Comic, ComicCriteria>(_comicService.GetByCreatorAsync, rd) },
            { "43", rd => GetList<Event, EventCriteria>(_eventService.GetByCreatorAsync, rd) },
            { "53", rd => GetList<Series, SeriesCriteria>(_seriesService.GetByCreatorAsync, rd) },
            { "63", rd => GetList<Story, StoryCriteria>(_storyService.GetByCreatorAsync, rd) },

            { "14", rd => GetList<Character, CharacterCriteria>(_characterService.GetByEventAsync, rd) },
            { "24", rd => GetList<Comic, ComicCriteria>(_comicService.GetByEventAsync, rd) },
            { "34", rd => GetList<Creator, CreatorCriteria>(_creatorService.GetByEventAsync, rd) },
            { "54", rd => GetList<Series, SeriesCriteria>(_seriesService.GetByEventAsync, rd) },
            { "64", rd => GetList<Story, StoryCriteria>(_storyService.GetByEventAsync, rd) },

            { "15", rd => GetList<Character, CharacterCriteria>(_characterService.GetBySeriesAsync, rd) },
            { "25", rd => GetList<Comic, ComicCriteria>(_comicService.GetBySeriesAsync, rd) },
            { "35", rd => GetList<Creator, CreatorCriteria>(_creatorService.GetBySeriesAsync, rd) },
            { "45", rd => GetList<Event, EventCriteria>(_eventService.GetBySeriesAsync, rd) },
            { "65", rd => GetList<Story, StoryCriteria>(_storyService.GetBySeriesAsync, rd) },

            { "16", rd => GetList<Character, CharacterCriteria>(_characterService.GetByStoryAsync, rd) },
            { "26", rd => GetList<Comic, ComicCriteria>(_comicService.GetByStoryAsync, rd) },
            { "36", rd => GetList<Creator, CreatorCriteria>(_creatorService.GetByStoryAsync, rd) },
            { "46", rd => GetList<Event, EventCriteria>(_eventService.GetByStoryAsync, rd) },
            { "56", rd => GetList<Series, SeriesCriteria>(_seriesService.GetByStoryAsync, rd) }
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

            var input = ParseMainMenuInput();

            if (input == null || !ItemTypesPlural.Keys.Contains(input.Item1))
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

        private static Tuple<int,string,DateTime?> ParseMainMenuInput()
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

        private static int? ParseInput()
        {
            Console.WriteLine(0 + "\t" + "Back to Main Menu");
            Console.WriteLine();

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

            var input = ParseInput();

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
