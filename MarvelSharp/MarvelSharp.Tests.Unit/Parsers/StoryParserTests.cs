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
    public class StoryParserTests
    {
        [Test]
        public void Parse_ReturnsStory()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("story"));

            var sut = new StoryParser();

            // Act
            Story result = sut.Parse(json);

            // Assert
            Assert.AreEqual(26, result.Id);
            Assert.AreEqual("Haunted by her own father's death, Elektra finds that killing her latest target's daughter Ñ the only witness to the murder Ñ is", result.Title);
            Assert.AreEqual("Test description", result.Description);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26", result.ResourceUri);
            Assert.AreEqual("story", result.Type);
            Assert.AreEqual(new DateTimeOffset(new DateTime(1969,12,31,19,0,0), new TimeSpan(-5,0,0)), result.Modified);
            Assert.AreEqual(null, result.Thumbnail);

            Assert.AreEqual(2, result.Creators.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26/creators", result.Creators.CollectionUri);
            Assert.AreEqual(2, result.Creators.Items.Count);
            Assert.AreEqual("Yoshitaka Amano", result.Creators.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/29", result.Creators.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.First().Type);
            Assert.AreEqual("penciller", result.Creators.Items.First().Role);
            Assert.AreEqual("Greg Rucka", result.Creators.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/28", result.Creators.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.Last().Type);
            Assert.AreEqual("writer", result.Creators.Items.Last().Role);
            Assert.AreEqual(2, result.Creators.Returned);

            Assert.AreEqual(0, result.Characters.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26/characters", result.Characters.CollectionUri);
            Assert.AreEqual(0, result.Characters.Items.Count);
            Assert.AreEqual(0, result.Characters.Returned);

            Assert.AreEqual(1, result.Series.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26/series", result.Series.CollectionUri);
            Assert.AreEqual(1, result.Series.Items.Count);
            Assert.AreEqual("Elektra & Wolverine: The Redeemer (1999)", result.Series.Items.Single().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/25", result.Series.Items.Single().ResourceUri);
            Assert.AreEqual(null, result.Series.Items.Single().Type);
            Assert.AreEqual(null, result.Series.Items.Single().Role);
            Assert.AreEqual(1, result.Series.Returned);

            Assert.AreEqual(1, result.Comics.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26/comics", result.Comics.CollectionUri);
            Assert.AreEqual(1, result.Comics.Items.Count);
            Assert.AreEqual("Elektra & Wolverine: The Redeemer (Hardcover)", result.Comics.Items.Single().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/960", result.Comics.Items.Single().ResourceUri);
            Assert.AreEqual(null, result.Comics.Items.Single().Type);
            Assert.AreEqual(null, result.Comics.Items.Single().Role);
            Assert.AreEqual(1, result.Comics.Returned);

            Assert.AreEqual(0, result.Events.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/26/events", result.Events.CollectionUri);
            Assert.AreEqual(0, result.Events.Items.Count);
            Assert.AreEqual(0, result.Events.Returned);
            
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/960", result.OriginalIssue.ResourceUri);
            Assert.AreEqual("Elektra & Wolverine: The Redeemer (Hardcover)", result.OriginalIssue.Name);
        }
    }
}
