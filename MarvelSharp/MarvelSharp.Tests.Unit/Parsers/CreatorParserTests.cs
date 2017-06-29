using MarvelSharp.Model;
using MarvelSharp.Parsers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Linq;

namespace MarvelSharp.Tests.Unit.Parsers
{
    [TestFixture]
    public class CreatorParserTests
    {
        [Test]
        public void Parse_ReturnsCreator()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("creator"));

            var sut = new CreatorParser();

            // Act
            Creator result = sut.Parse(json);

            // Assert
            Assert.AreEqual(12844, result.Id);
            Assert.AreEqual("Aco", result.FirstName);
            Assert.AreEqual("Middle Name", result.MiddleName);
            Assert.AreEqual("Last Name", result.LastName);
            Assert.AreEqual("Suffix", result.Suffix);
            Assert.AreEqual("Aco", result.FullName);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2016,4,15,16,42,10), new TimeSpan(-4,0,0)), result.Modified);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available", result.Thumbnail.Path);
            Assert.AreEqual("jpg", result.Thumbnail.Extension);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12844", result.ResourceUri);

            Assert.AreEqual(2, result.Comics.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12844/comics", result.Comics.CollectionUri);
            Assert.AreEqual(2, result.Comics.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/55740", result.Comics.Items.First().ResourceUri);
            Assert.AreEqual("Squadron Supreme Vol. 2: Civil War II (Trade Paperback)", result.Comics.Items.First().Name);
            Assert.AreEqual(null, result.Comics.Items.First().Type);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/60051", result.Comics.Items.Last().ResourceUri);
            Assert.AreEqual("Uncanny X-Men Annual (2016) #1", result.Comics.Items.Last().Name);
            Assert.AreEqual(null, result.Comics.Items.Last().Type);
            Assert.AreEqual(2, result.Comics.Returned);

            Assert.AreEqual(2, result.Series.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12844/series", result.Series.CollectionUri);
            Assert.AreEqual(2, result.Series.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/20519", result.Series.Items.First().ResourceUri);
            Assert.AreEqual("Squadron Supreme Vol. 2: Civil War II (2016)", result.Series.Items.First().Name);
            Assert.AreEqual(null, result.Series.Items.First().Type);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/22014", result.Series.Items.Last().ResourceUri);
            Assert.AreEqual("Uncanny X-Men Annual (2016)", result.Series.Items.Last().Name);
            Assert.AreEqual(null, result.Series.Items.Last().Type);
            Assert.AreEqual(2, result.Series.Returned);

            Assert.AreEqual(2, result.Stories.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12844/stories", result.Stories.CollectionUri);
            Assert.AreEqual(2, result.Stories.Items.Count);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/122524", result.Stories.Items.First().ResourceUri);
            Assert.AreEqual("story from Squadron Supreme (2016)", result.Stories.Items.First().Name);
            Assert.AreEqual("interiorStory", result.Stories.Items.First().Type);
            Assert.AreEqual(null, result.Stories.Items.First().Role);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/130633", result.Stories.Items.Last().ResourceUri);
            Assert.AreEqual("cover from Uncanny X-Men Annual (2020) #1", result.Stories.Items.Last().Name);
            Assert.AreEqual("cover", result.Stories.Items.Last().Type);
            Assert.AreEqual(null, result.Stories.Items.Last().Role);
            Assert.AreEqual(2, result.Stories.Returned);

            Assert.AreEqual(0, result.Events.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/12844/events", result.Events.CollectionUri);
            Assert.AreEqual(0, result.Events.Items.Count);
            Assert.AreEqual(0, result.Events.Returned);

            Assert.AreEqual(1, result.Urls.Count);
            Assert.AreEqual("detail", result.Urls.Single().Type);
            Assert.AreEqual("http://marvel.com/comics/creators/12844/aco?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.Single().Value);
        }
    }
}
