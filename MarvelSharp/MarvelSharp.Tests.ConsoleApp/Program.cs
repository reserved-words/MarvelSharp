using MarvelSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class Program
    {
        private const int ReturnItems = 25;
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
            { "10", listDetails => _characterService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "20", listDetails => _comicService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "30", listDetails => _creatorService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "40", listDetails => _eventService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "50", listDetails => _seriesService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "60", listDetails => _storyService.GetAllAsync(ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "11", listDetails => new List<ItemBase> { _characterService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },
            { "22", listDetails => new List<ItemBase> { _comicService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },
            { "33", listDetails => new List<ItemBase> { _creatorService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },
            { "44", listDetails => new List<ItemBase> { _eventService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },
            { "55", listDetails => new List<ItemBase> { _seriesService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },
            { "66", listDetails => new List<ItemBase> { _storyService.GetByIdAsync(listDetails.ItemId).Result.Data.Result } },

            { "21", listDetails => _comicService.GetByCharacterAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "41", listDetails => _eventService.GetByCharacterAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "51", listDetails => _seriesService.GetByCharacterAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "61", listDetails => _storyService.GetByCharacterAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "12", listDetails => _characterService.GetByComicAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "32", listDetails => _creatorService.GetByComicAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "42", listDetails => _eventService.GetByComicAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "62", listDetails => _storyService.GetByComicAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "23", listDetails => _comicService.GetByCreatorAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "43", listDetails => _eventService.GetByCreatorAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "53", listDetails => _seriesService.GetByCreatorAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "63", listDetails => _storyService.GetByCreatorAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "14", listDetails => _characterService.GetByEventAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "24", listDetails => _comicService.GetByEventAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "34", listDetails => _creatorService.GetByEventAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "54", listDetails => _seriesService.GetByEventAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "64", listDetails => _storyService.GetByEventAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "15", listDetails => _characterService.GetBySeriesAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "25", listDetails => _comicService.GetBySeriesAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "35", listDetails => _creatorService.GetBySeriesAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "45", listDetails => _eventService.GetBySeriesAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "65", listDetails => _storyService.GetBySeriesAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },

            { "16", listDetails => _characterService.GetByStoryAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "26", listDetails => _comicService.GetByStoryAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "36", listDetails => _creatorService.GetByStoryAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "46", listDetails => _eventService.GetByStoryAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
            { "56", listDetails => _seriesService.GetByStoryAsync(listDetails.ItemId, ReturnItems, (listDetails.Page - 1) * ReturnItems).Result.Data.Result.OfType<ItemBase>().ToList() },
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

            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            PrintHeader("Main Menu");

            foreach (var kvp in ItemTypesPlural)
            {
                Console.WriteLine($"{kvp.Key}\tFetch {kvp.Value}");
            }

            var input = GetInput();

            if (input == null)
                return;

            if (!ItemTypesPlural.Keys.Contains(input.Value))
                return;

            DisplayList(new RequestDetails(input.Value, 1, null));
        }

        private static void DisplayList(RequestDetails requestDetails)
        {
            if (requestDetails.FetchType == requestDetails.ItemType)
            {
                DisplayItem(requestDetails);
            }

            var list = FetchItems(requestDetails);

            PrintHeader((requestDetails.ItemId == 0
                ? "ALL " + ItemTypesPlural[requestDetails.FetchType]
                : ItemTypesPlural[requestDetails.FetchType] + " for " + requestDetails.ItemName) + " (PAGE " + requestDetails.Page + ")");

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + "\t" + item);
            }

            Console.WriteLine();

            if (requestDetails.PreviousRequest != null)
            {
                Console.WriteLine("9\tPrevious page");
            }

            Console.WriteLine("999\tNext Page");

            var selectedId = GetInput();

            if (!selectedId.HasValue)
                return;

            if (selectedId == 9)
            {
                DisplayList(requestDetails.PreviousRequest);
                return;
            }

            if (selectedId == 999)
            {
                DisplayList(new RequestDetails(requestDetails.FetchType, requestDetails.Page + 1, requestDetails.ItemType, requestDetails.ItemId, requestDetails.ItemName, requestDetails));
                return;
            }

            var selectedItem = list.Single(i => i.Id == selectedId);

            var newListDetails = new RequestDetails(requestDetails.FetchType, 1, requestDetails.FetchType, selectedItem.Id.Value, selectedItem.ToString(), requestDetails);

            DisplayItem(newListDetails);
        }

        private static List<ItemBase> FetchItems(RequestDetails requestDetails)
        {
            var combinedTypes = requestDetails.FetchType.ToString() + requestDetails.ItemType.ToString();
            
            return MethodDictionary[combinedTypes](requestDetails);
        }

        private static int? GetInput()
        {
            Console.WriteLine(0 + "\t" + "Back to Main Menu");

            Console.WriteLine();

            var input = Console.ReadLine();

            if (input == "0")
            {
                ShowMainMenu();
                return null;
            }

            int inputInt;
            if (!int.TryParse(input, out inputInt))
                return null;

            return inputInt;
        }

        private static void DisplayItem(RequestDetails requestDetails)
        {
            var item = GetItem(requestDetails);

            PrintHeader(item.ToString());

            DisplayHelper.DisplayItem(item);
            Console.WriteLine();

            foreach (var kvp in ItemTypesPlural)
            {
                if (kvp.Key == requestDetails.ItemType)
                    continue;

                if (!MethodDictionary.Keys.Contains(kvp.Key.ToString() + requestDetails.ItemType.ToString()))
                    continue;

                Console.WriteLine($"{kvp.Key}\tFetch {kvp.Value}");
            }

            Console.WriteLine();

            if (requestDetails.PreviousRequest != null)
            {
                Console.WriteLine("9\tPrevious page");
            }

            var fetchType = GetInput();

            if (!fetchType.HasValue)
                return;

            if (fetchType == 9)
            {
                DisplayList(requestDetails.PreviousRequest);
                return;
            }

            DisplayList(new RequestDetails(fetchType.Value, 1, requestDetails.ItemType, requestDetails.ItemId, item.ToString(), requestDetails));
        }

        private static ItemBase GetItem(RequestDetails requestDetails)
        {
            var list = FetchItems(requestDetails);
            return list.Single();
        }

        private static void PrintHeader(string header)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(header.ToUpper());
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
