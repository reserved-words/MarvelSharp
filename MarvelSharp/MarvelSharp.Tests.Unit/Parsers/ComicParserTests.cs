using MarvelSharp.Model;
using MarvelSharp.Parsers;
using MarvelSharp.Tests.Unit.Helpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Linq;

namespace MarvelSharp.Tests.Unit.Parsers
{
    [TestFixture]
    public class ComicParserTests
    {
        [Test]
        public void Parse_ReturnsComic()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("comic"));

            var sut = new ComicParser();

            // Act
            Comic result = sut.Parse(json);

            // Assert
            Assert.AreEqual(21472, result.Id);
            Assert.AreEqual(0, result.DigitalId);
            Assert.AreEqual("Ultimate Spider-Man (Spanish Language Edition) (2000) #8", result.Title);
            Assert.AreEqual(8, result.IssueNumber);
            Assert.AreEqual("Variant description", result.VariantDescription);
            Assert.AreEqual("Test description", result.Description);
            Assert.AreEqual(null, result.Modified);
            Assert.AreEqual("TestIsbn0001", result.Isbn);
            Assert.AreEqual("TestUpc0001", result.Upc);
            Assert.AreEqual("TestDiamondCode0001", result.DiamondCode);
            Assert.AreEqual("TestEan0001", result.Ean);
            Assert.AreEqual("TestIssn0001", result.Issn);
            Assert.AreEqual("Comic", result.Format);
            Assert.AreEqual(0, result.PageCount);

            Assert.AreEqual(1, result.TextObjects.Count);
            Assert.AreEqual("issue_solicit_text", result.TextObjects.Single().Type);
            Assert.AreEqual("en-us", result.TextObjects.Single().Language);
            Assert.AreEqual("\"The Marvel Age of Comics continues! This time around, Spidey meets his match against such classic villains as Electro and the Lizard, and faces the return of one of his first foes: the Vulture! Plus: Spider-Man vs. the Living Brain, Peter Parker's fight with Flash Thompson, and the wall-crawler tackles the high-flying Human Torch!\"", result.TextObjects.Single().Text);

            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21472", result.ResourceUri);

            Assert.AreEqual(1, result.Urls.Count);
            Assert.AreEqual("detail", result.Urls.Single().Type);
            Assert.AreEqual("http://marvel.com/comics/issue/21472/ultimate_spider-man_spanish_language_edition_2000_8?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.Single().Value);

            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/5105", result.Series.ResourceUri);
            Assert.AreEqual("Ultimate Spider-Man (Spanish Language Edition) (2000 - 2001)", result.Series.Name);

            Assert.AreEqual(2, result.Variants.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/56155", result.Variants.First().ResourceUri);
            Assert.AreEqual("Old Man Logan (2016) #8", result.Variants.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/60075", result.Variants.Last().ResourceUri);
            Assert.AreEqual("Old Man Logan (2016) #8 (Albuquerque Death of X Variant)", result.Variants.Last().Name);

            Assert.AreEqual(0, result.Collections.Count);

            Assert.AreEqual(4, result.CollectedIssues.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/546", result.CollectedIssues.First().ResourceUri);
            Assert.AreEqual("Marvel Age Spider-Man (2004) #8", result.CollectedIssues.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/681", result.CollectedIssues.Last().ResourceUri);
            Assert.AreEqual("Marvel Age Spider-Man (2004) #5", result.CollectedIssues.Last().Name);

            Assert.AreEqual(2, result.Dates.Count);
            Assert.AreEqual("onsaleDate", result.Dates.First().Type);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2029, 12, 31), new TimeSpan(-5, 0, 0)), result.Dates.First().Date);
            Assert.AreEqual("focDate", result.Dates.Last().Type);
            Assert.AreEqual(null, result.Dates.Last().Date);
            
            Assert.AreEqual(1, result.Prices.Count);
            Assert.AreEqual("printPrice", result.Prices.Single().Type);
            Assert.AreEqual(2.25, result.Prices.Single().Price);

            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available", result.Thumbnail.Path);
            Assert.AreEqual("jpg", result.Thumbnail.Extension);

            Assert.AreEqual(4, result.Images.Count);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/a/40/4bc689a4ce796", result.Images.First().Path);
            Assert.AreEqual("jpg", result.Images.First().Extension);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/9/20/4bc665483c3aa", result.Images.Last().Path);
            Assert.AreEqual("jpg", result.Images.Last().Extension);

            Assert.AreEqual(0, result.Creators.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21472/creators", result.Creators.CollectionUri);
            Assert.AreEqual(0, result.Creators.Items.Count);
            Assert.AreEqual(0, result.Creators.Returned);

            Assert.AreEqual(1, result.Characters.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21472/characters", result.Characters.CollectionUri);
            Assert.AreEqual(1, result.Characters.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011010", result.Characters.Items.Single().ResourceUri);
            Assert.AreEqual("Spider-Man (Ultimate)", result.Characters.Items.Single().Name);
            Assert.AreEqual(null, result.Characters.Items.Single().Type);
            Assert.AreEqual(null, result.Characters.Items.Single().Role);
            Assert.AreEqual(1, result.Characters.Returned);

            Assert.AreEqual(2, result.Stories.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21472/stories", result.Stories.CollectionUri);
            Assert.AreEqual(2, result.Stories.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/48972", result.Stories.Items.First().ResourceUri);
            Assert.AreEqual("Cover #48972", result.Stories.Items.First().Name);
            Assert.AreEqual("cover", result.Stories.Items.First().Type);
            Assert.AreEqual(null, result.Stories.Items.First().Role);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/48973", result.Stories.Items.Last().ResourceUri);
            Assert.AreEqual("Interior #48973", result.Stories.Items.Last().Name);
            Assert.AreEqual("interiorStory", result.Stories.Items.Last().Type);
            Assert.AreEqual(null, result.Stories.Items.Last().Role);
            Assert.AreEqual(2, result.Stories.Returned);

            Assert.AreEqual(0, result.Events.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21472/events", result.Events.CollectionUri);
            Assert.AreEqual(0, result.Events.Items.Count);
            Assert.AreEqual(0, result.Events.Returned);
        }
    }
}
