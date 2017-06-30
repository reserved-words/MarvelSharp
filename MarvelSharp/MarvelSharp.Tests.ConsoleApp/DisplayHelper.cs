using System;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public static class DisplayHelper
    {
        public static void DisplayItem(ItemBase item)
        {
            var character = item as Character;
            if (character != null)
            {
                DisplayCharacter(character);
                return;
            }

            var comic = item as Comic;
            if (comic != null)
            {
                DisplayComic(comic);
                return;
            }

            var ev = item as Event;
            if (ev != null)
            {
                DisplayEvent(ev);
                return;
            }

            var creator = item as Creator;
            if (creator != null)
            {
                DisplayCreator(creator);
                return;
            }

            var series = item as Series;
            if (series != null)
            {
                DisplaySeries(series);
                return;
            }

            var story = item as Story;
            if (story != null)
            {
                DisplayStory(story);
                return;
            }
        }

        private static void DisplayCharacter(Character item)
        {
            Console.WriteLine("NAME:");
            Console.WriteLine(item.Name);
            Console.WriteLine();
            Console.WriteLine("DESCRIPTION:");
            Console.WriteLine(item.Description);
        }

        private static void DisplayComic(Comic item)
        {
            Console.WriteLine("TITLE:");
            Console.WriteLine(item.Title);
            Console.WriteLine();
            Console.WriteLine("DESCRIPTION:");
            Console.WriteLine(item.Description);
        }

        private static void DisplayCreator(Creator item)
        {
            Console.WriteLine("NAME:");
            Console.WriteLine(item.FullName);
            Console.WriteLine();
            Console.WriteLine("THUMBNAIL:");
            Console.WriteLine(item.Thumbnail);
        }

        private static void DisplayEvent(Event item)
        {
            Console.WriteLine("TITLE:");
            Console.WriteLine(item.Title);
            Console.WriteLine();
            Console.WriteLine("START DATE:");
            Console.WriteLine(item.Start);
        }

        private static void DisplaySeries(Series item)
        {
            Console.WriteLine("TITLE:");
            Console.WriteLine(item.Title);
            Console.WriteLine();
            Console.WriteLine("START YEAR:");
            Console.WriteLine(item.StartYear);
        }

        private static void DisplayStory(Story item)
        {
            Console.WriteLine("TITLE:");
            Console.WriteLine(item.Title);
            Console.WriteLine();
            Console.WriteLine("ORIGINAL ISSUE:");
            Console.WriteLine(item.OriginalIssue?.Name);
        }
    }
}
