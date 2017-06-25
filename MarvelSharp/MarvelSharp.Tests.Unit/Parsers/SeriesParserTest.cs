using MarvelSharp.Model;
using MarvelSharp.Parsers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests.Unit.Parsers
{
    [TestFixture]
    public class SeriesParserTests
    {
        [Test]
        public void Parse_ReturnsSeries()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("series"));

            var sut = new SeriesParser();

            // Act
            Series result = sut.Parse(json);

            // Assert
            Assert.AreEqual(18454, result.Id);
            Assert.AreEqual("100th Anniversary Special (2014 - Present)", result.Title);
            Assert.AreEqual("Test description", result.Description);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454", result.ResourceUri);
            Assert.AreEqual(1, result.Urls.Count);
            Assert.AreEqual("detail", result.Urls.Single().Type);
            Assert.AreEqual("http://marvel.com/comics/series/18454/100th_anniversary_special_2014_-_present?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.Single().Value);
            Assert.AreEqual(2014, result.StartYear);
            Assert.AreEqual(2099, result.EndYear);
            Assert.AreEqual("Rated T", result.Rating);
            Assert.AreEqual("limited", result.Type);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2015,1,14,8,48,32), new TimeSpan(-5,0,0)), result.Modified);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available", result.Thumbnail.Path);
            Assert.AreEqual("jpg", result.Thumbnail.Extension);

            Assert.AreEqual(5, result.Creators.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454/creators", result.Creators.CollectionUri);
            Assert.AreEqual(5, result.Creators.Items.Count);
            Assert.AreEqual("Andy Lanning", result.Creators.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/485", result.Creators.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.First().Type);
            Assert.AreEqual("writer", result.Creators.Items.First().Role);
            Assert.AreEqual("David Lopez", result.Creators.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12392", result.Creators.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.Last().Type);
            Assert.AreEqual("penciller (cover)", result.Creators.Items.Last().Role);
            Assert.AreEqual(5, result.Creators.Returned);

            Assert.AreEqual(0, result.Characters.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454/characters", result.Characters.CollectionUri);
            Assert.AreEqual(0, result.Characters.Items.Count);
            Assert.AreEqual(0, result.Characters.Returned);

            Assert.AreEqual(10, result.Stories.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454/stories", result.Stories.CollectionUri);
            Assert.AreEqual(10, result.Stories.Items.Count);
            Assert.AreEqual("cover from 100th Anniversary Special (2014) #1", result.Stories.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/110101", result.Stories.Items.First().ResourceUri);
            Assert.AreEqual("cover", result.Stories.Items.First().Type);
            Assert.AreEqual(null, result.Stories.Items.First().Role);
            Assert.AreEqual("story from 100th Anniversary Special (2014) #5", result.Stories.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/110110", result.Stories.Items.Last().ResourceUri);
            Assert.AreEqual("interiorStory", result.Stories.Items.Last().Type);
            Assert.AreEqual(null, result.Stories.Items.Last().Role);
            Assert.AreEqual(10, result.Stories.Returned);

            Assert.AreEqual(5, result.Comics.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454/comics", result.Comics.CollectionUri);
            Assert.AreEqual(5, result.Comics.Items.Count);
            Assert.AreEqual("100th Anniversary Special (2014) #1", result.Comics.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/49008", result.Comics.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Comics.Items.First().Type);
            Assert.AreEqual(null, result.Comics.Items.First().Role);
            Assert.AreEqual("100th Anniversary Special (2014) #1", result.Comics.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/49007", result.Comics.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Comics.Items.Last().Type);
            Assert.AreEqual(null, result.Comics.Items.Last().Role);
            Assert.AreEqual(5, result.Comics.Returned);

            Assert.AreEqual(0, result.Events.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/18454/events", result.Events.CollectionUri);
            Assert.AreEqual(0, result.Events.Items.Count);
            Assert.AreEqual(0, result.Events.Returned);

            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/240", result.Next.ResourceUri);
            Assert.AreEqual("Days of Future Present", result.Next.Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/233", result.Previous.ResourceUri);
            Assert.AreEqual("Atlantis Attacks", result.Previous.Name);
        }
    }
}
