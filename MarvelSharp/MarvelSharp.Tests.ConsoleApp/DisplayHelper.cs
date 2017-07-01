using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Model;

namespace MarvelSharp.Tests.ConsoleApp
{
    public static class DisplayHelper
    {
        private const int TotalLabelWidth = 20;

        public static void DisplayItemDetails(ItemBase item)
        {
            Display("ID", item.Id);
            Display("Resource URI", item.ResourceUri);
            Display("Modified", item.Modified);
            Display("Thumbnail", item.Thumbnail == null 
                ? string.Empty
                : $"{item.Thumbnail.Path}.{item.Thumbnail.Extension}");

            var character = item as Character;
            if (character != null)
            {
                DisplayCharacter(character);
                Console.WriteLine();
                return;
            }

            var comic = item as Comic;
            if (comic != null)
            {
                DisplayComic(comic);
                Console.WriteLine();
                return;
            }

            var ev = item as Event;
            if (ev != null)
            {
                DisplayEvent(ev);
                Console.WriteLine();
                return;
            }

            var creator = item as Creator;
            if (creator != null)
            {
                DisplayCreator(creator);
                Console.WriteLine();
                return;
            }

            var series = item as Series;
            if (series != null)
            {
                DisplaySeries(series);
                Console.WriteLine();
                return;
            }

            var story = item as Story;
            if (story != null)
            {
                DisplayStory(story);
                Console.WriteLine();
                return;
            }
        }

        private static void Display(string label, object value)
        {
            if (value == null || value.ToString() == string.Empty)
                return;

            Console.WriteLine(label.ToUpper().PadRight(TotalLabelWidth, ' ') + value);
        }

        private static void DisplayList(string label, IEnumerable<string> list)
        {
            if (list == null)
                return;

            var enumerated = list.ToList();

            if (!enumerated.Any())
            return;

            Console.WriteLine();
            Console.WriteLine(label.ToUpper() + ":");

            foreach (var item in enumerated)
            {
                Console.WriteLine(item);
            }
        }

        private static void DisplayCharacter(Character item)
        {
            Display("Name", item.Name);
            Display("Description", item.Description);

            DisplayList("URLs", item.Urls.Select(u => $"{u.Value} ({u.Type})"));
            DisplayList("Comics", item.Comics.Items.Select(i => i.Name));
            DisplayList("Events", item.Events.Items.Select(i => i.Name));
            DisplayList("Series", item.Series.Items.Select(i => i.Name));
            DisplayList("Stories", item.Stories.Items.Select(i => i.Name));
        }

        private static void DisplayComic(Comic item)
        {
            Display("Title", item.Title);
            Display("Description", item.Description);
            Display("Digital ID", item.DigitalId);
            Display("Issue Number", item.IssueNumber);
            Display("Variant Description", item.VariantDescription);
            Display("ISBN", item.Isbn);
            Display("UPC", item.Upc);
            Display("Diamond Code", item.DiamondCode);
            Display("EAN", item.Ean);
            Display("ISSN", item.Issn);
            Display("Format", item.Format);
            Display("Page Count", item.PageCount);
            Display("Series", item.Series.Name);

            DisplayList("URLs", item.Urls.Select(u => $"{u.Value} ({u.Type})"));
            DisplayList("Creators", item.Creators.Items.Select(i => i.Name));
            DisplayList("Events", item.Events.Items.Select(i => i.Name));
            DisplayList("Characters", item.Characters.Items.Select(i => i.Name));
            DisplayList("Stories", item.Stories.Items.Select(i => i.Name));
            DisplayList("Text Objects", item.TextObjects.Select(i => $"{i.Text} ({i.Type})"));
            DisplayList("Variants", item.Variants.Select(i => i.Name));
            DisplayList("Collections", item.Collections.Select(i => i.Name));
            DisplayList("Collected Issues", item.CollectedIssues.Select(i => i.Name));
            DisplayList("Dates", item.Dates.Select(i => $"{i.Type}: {i.Date}"));
            DisplayList("Prices", item.Prices.Select(i => $"{i.Type}: {i.Price}"));
            DisplayList("Images", item.Images.Select(i => $"{i.Path}.{i.Extension}"));
        }

        private static void DisplayCreator(Creator item)
        {
            Display("Full Name", item.FullName);
            Display("First Name", item.FirstName);
            Display("Middle Name", item.MiddleName);
            Display("Last Name", item.LastName);
            Display("Suffix", item.Suffix);

            DisplayList("URLs", item.Urls.Select(u => $"{u.Value} ({u.Type})"));
            DisplayList("Comics", item.Comics.Items.Select(i => i.Name));
            DisplayList("Events", item.Events.Items.Select(i => i.Name));
            DisplayList("Series", item.Series.Items.Select(i => i.Name));
            DisplayList("Stories", item.Stories.Items.Select(i => i.Name));
        }

        private static void DisplayEvent(Event item)
        {
            Display("Title", item.Title);
            Display("Description", item.Description);
            Display("Start", item.Start);
            Display("End", item.End);
            Display("Next", item.Next?.Name);
            Display("Previous", item.Previous?.Name);

            DisplayList("URLs", item.Urls.Select(u => $"{u.Value} ({u.Type})"));
            DisplayList("Comics", item.Comics.Items.Select(i => i.Name));
            DisplayList("Characters", item.Characters.Items.Select(i => i.Name));
            DisplayList("Series", item.Series.Items.Select(i => i.Name));
            DisplayList("Stories", item.Stories.Items.Select(i => i.Name));
            DisplayList("Creators", item.Creators.Items.Select(i => i.Name));
        }

        private static void DisplaySeries(Series item)
        {
            Display("Title", item.Title);
            Display("Description", item.Description);
            Display("Start Year", item.StartYear);
            Display("End Year", item.EndYear);
            Display("Rating", item.Rating);
            Display("Type", item.Type);
            Display("Next", item.Next?.Name);
            Display("Previous", item.Previous?.Name);

            DisplayList("URLs", item.Urls.Select(u => $"{u.Value} ({u.Type})"));
            DisplayList("Comics", item.Comics.Items.Select(i => i.Name));
            DisplayList("Stories", item.Stories.Items.Select(i => i.Name));
            DisplayList("Events", item.Events.Items.Select(i => i.Name));
            DisplayList("Characters", item.Characters.Items.Select(i => i.Name));
            DisplayList("Creators", item.Creators.Items.Select(i => i.Name));
        }

        private static void DisplayStory(Story item)
        {
            Display("Title", item.Title);
            Display("Description", item.Description);
            Display("OriginalIssue", item.OriginalIssue);
            Display("Type", item.Type);

            DisplayList("Comics", item.Comics.Items.Select(i => i.Name));
            DisplayList("Series", item.Series.Items.Select(i => i.Name));
            DisplayList("Events", item.Events.Items.Select(i => i.Name));
            DisplayList("Characters", item.Characters.Items.Select(i => i.Name));
            DisplayList("Creators", item.Creators.Items.Select(i => i.Name));
        }
    }
}
