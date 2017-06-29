using MarvelSharp.Model;
using MarvelSharp.Parsers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Linq;
using MarvelSharp.Tests.Unit.Helpers;

namespace MarvelSharp.Tests.Unit.Parsers
{
    [TestFixture]
    public class CharacterParserTests
    {
        [Test]
        public void Parse_ReturnsCharacter()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("character"));

            var sut = new CharacterParser();

            // Act
            Character result = sut.Parse(json);

            // Assert
            Assert.AreEqual(1011334, result.Id);
            Assert.AreEqual("3-D Man", result.Name);
            Assert.AreEqual("Test description", result.Description);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2014, 4, 29, 14, 18, 17), new TimeSpan(-4,0,0)), result.Modified);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/c/e0/535fecbbb9784", result.Thumbnail.Path);
            Assert.AreEqual("jpg", result.Thumbnail.Extension);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011334", result.ResourceUri);

            Assert.AreEqual(12, result.Comics.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011334/comics", result.Comics.CollectionUri);
            Assert.AreEqual(12, result.Comics.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/21366", result.Comics.Items.First().ResourceUri);
            Assert.AreEqual("Avengers: The Initiative (2007) #14", result.Comics.Items.First().Name);
            Assert.AreEqual(null, result.Comics.Items.First().Type);
            Assert.AreEqual(null, result.Comics.Items.First().Role);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/10225", result.Comics.Items.Last().ResourceUri);
            Assert.AreEqual("Marvel Premiere (1972) #37", result.Comics.Items.Last().Name);
            Assert.AreEqual(null, result.Comics.Items.Last().Type);
            Assert.AreEqual(null, result.Comics.Items.Last().Role);
            Assert.AreEqual(12, result.Comics.Returned);

            Assert.AreEqual(3, result.Series.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011334/series", result.Series.CollectionUri);
            Assert.AreEqual(3, result.Series.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/1945", result.Series.Items.First().ResourceUri);
            Assert.AreEqual("Avengers: The Initiative (2007 - 2010)", result.Series.Items.First().Name);
            Assert.AreEqual(null, result.Series.Items.First().Type);
            Assert.AreEqual(null, result.Series.Items.First().Role);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/2045", result.Series.Items.Last().ResourceUri);
            Assert.AreEqual("Marvel Premiere (1972 - 1981)", result.Series.Items.Last().Name);
            Assert.AreEqual(null, result.Series.Items.Last().Type);
            Assert.AreEqual(null, result.Series.Items.Last().Role);
            Assert.AreEqual(3, result.Series.Returned);

            Assert.AreEqual(21, result.Stories.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011334/stories", result.Stories.CollectionUri);
            Assert.AreEqual(20, result.Stories.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/19947", result.Stories.Items.First().ResourceUri);
            Assert.AreEqual("Cover #19947", result.Stories.Items.First().Name);
            Assert.AreEqual("cover", result.Stories.Items.First().Type);
            Assert.AreEqual(null, result.Stories.Items.First().Role);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/54371", result.Stories.Items.Last().ResourceUri);
            Assert.AreEqual("Avengers: The Initiative (2007) #14, Spotlight Variant - Int", result.Stories.Items.Last().Name);
            Assert.AreEqual("interiorStory", result.Stories.Items.Last().Type);
            Assert.AreEqual(null, result.Stories.Items.Last().Role);
            Assert.AreEqual(20, result.Stories.Returned);

            Assert.AreEqual(1, result.Events.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1011334/events", result.Events.CollectionUri);
            Assert.AreEqual(1, result.Events.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/269", result.Events.Items.Single().ResourceUri);
            Assert.AreEqual("Secret Invasion", result.Events.Items.Single().Name);
            Assert.AreEqual(null, result.Events.Items.Single().Type);
            Assert.AreEqual(null, result.Events.Items.Single().Role);
            Assert.AreEqual(1, result.Events.Returned);

            Assert.AreEqual(3, result.Urls.Count);
            Assert.AreEqual("detail", result.Urls.First().Type);
            Assert.AreEqual("http://marvel.com/characters/74/3-d_man?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.First().Value);
            Assert.AreEqual("comiclink", result.Urls.Last().Type);
            Assert.AreEqual("http://marvel.com/comics/characters/1011334/3-d_man?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.Last().Value);
        }
    }
}
