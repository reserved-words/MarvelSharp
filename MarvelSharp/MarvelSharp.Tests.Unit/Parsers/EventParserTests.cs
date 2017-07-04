using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Linq;
using MarvelSharp.Internal.Parsers;
using MarvelSharp.Model;
using MarvelSharp.Tests.Unit.Helpers;

namespace MarvelSharp.Tests.Unit.Parsers
{
    [TestFixture]
    public class EventParserTests
    {
        [Test]
        public void Parse_ReturnsEvent()
        {
            // Arrange
            dynamic json = JObject.Parse(TestJson.Get("event"));

            var sut = new EventParser();

            // Act
            Event result = sut.Parse(json);

            // Assert
            Assert.AreEqual(116, result.Id);
            Assert.AreEqual("Acts of Vengeance!", result.Title);
            Assert.AreEqual("Loki sets about convincing the super-villains of Earth to attack heroes other than those they normally fight in an attempt to destroy the Avengers to absolve his guilt over inadvertently creating the team in the first place.", result.Description);

            Assert.AreEqual(2, result.Urls.Count);
            Assert.AreEqual("detail", result.Urls.First().Type);
            Assert.AreEqual("http://marvel.com/comics/events/116/acts_of_vengeance?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.First().Value);
            Assert.AreEqual("wiki", result.Urls.Last().Type);
            Assert.AreEqual("http://marvel.com/universe/Acts_of_Vengeance!?utm_campaign=apiRef&utm_source=20f18f98d97b8d7b9733fa6bdcfaea77", result.Urls.Last().Value);

            Assert.AreEqual(new DateTimeOffset(new DateTime(2013,6,28,16,31,24), new TimeSpan(-4,0,0)), result.Modified);
            Assert.AreEqual(new DateTime(1989,12,10), result.Start);
            Assert.AreEqual(new DateTime(2008, 1, 4), result.End);
            Assert.AreEqual("http://i.annihil.us/u/prod/marvel/i/mg/9/40/51ca10d996b8b", result.Thumbnail.Path);
            Assert.AreEqual("jpg", result.Thumbnail.Extension);

            Assert.AreEqual(117, result.Creators.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/116/creators", result.Creators.CollectionUri);
            Assert.AreEqual(20, result.Creators.Items.Count);
            Assert.AreEqual("Jeff Albrecht", result.Creators.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/2707", result.Creators.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.First().Type);
            Assert.AreEqual("inker", result.Creators.Items.First().Role);
            Assert.AreEqual("John Byrne", result.Creators.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/creators/1827", result.Creators.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Creators.Items.Last().Type);
            Assert.AreEqual("artist", result.Creators.Items.Last().Role);
            Assert.AreEqual(20, result.Creators.Returned);

            Assert.AreEqual(85, result.Characters.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/116/characters", result.Characters.CollectionUri);
            Assert.AreEqual(20, result.Characters.Items.Count);
            Assert.AreEqual("Alpha Flight", result.Characters.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1010370", result.Characters.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Characters.Items.First().Type);
            Assert.AreEqual(null, result.Characters.Items.First().Role);
            Assert.AreEqual("Dazzler", result.Characters.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/characters/1009267", result.Characters.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Characters.Items.Last().Type);
            Assert.AreEqual(null, result.Characters.Items.Last().Role);
            Assert.AreEqual(20, result.Characters.Returned);

            Assert.AreEqual(145, result.Stories.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/116/stories", result.Stories.CollectionUri);
            Assert.AreEqual(20, result.Stories.Items.Count);
            Assert.AreEqual("Cover #12960", result.Stories.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/12960", result.Stories.Items.First().ResourceUri);
            Assert.AreEqual("cover", result.Stories.Items.First().Type);
            Assert.AreEqual(null, result.Stories.Items.First().Role);
            Assert.AreEqual("Thieves Honor", result.Stories.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/stories/14921", result.Stories.Items.Last().ResourceUri);
            Assert.AreEqual("interiorStory", result.Stories.Items.Last().Type);
            Assert.AreEqual(null, result.Stories.Items.Last().Role);
            Assert.AreEqual(20, result.Stories.Returned);

            Assert.AreEqual(52, result.Comics.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/116/comics", result.Comics.CollectionUri);
            Assert.AreEqual(20, result.Comics.Items.Count);
            Assert.AreEqual("Alpha Flight (1983) #79", result.Comics.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/12744", result.Comics.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Comics.Items.First().Type);
            Assert.AreEqual(null, result.Comics.Items.First().Role);
            Assert.AreEqual("Doctor Strange, Sorcerer Supreme (1988) #11", result.Comics.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/comics/20170", result.Comics.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Comics.Items.Last().Type);
            Assert.AreEqual(null, result.Comics.Items.Last().Role);
            Assert.AreEqual(20, result.Comics.Returned);

            Assert.AreEqual(22, result.Series.Available);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/116/series", result.Series.CollectionUri);
            Assert.AreEqual(20, result.Series.Items.Count);
            Assert.AreEqual("Alpha Flight (1983 - 1994)", result.Series.Items.First().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/2116", result.Series.Items.First().ResourceUri);
            Assert.AreEqual(null, result.Series.Items.First().Type);
            Assert.AreEqual(null, result.Series.Items.First().Role);
            Assert.AreEqual("Web of Spider-Man (1985 - 1995)", result.Series.Items.Last().Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/series/2092", result.Series.Items.Last().ResourceUri);
            Assert.AreEqual(null, result.Series.Items.Last().Type);
            Assert.AreEqual(null, result.Series.Items.Last().Role);
            Assert.AreEqual(20, result.Series.Returned);

            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/240", result.Next.ResourceUri);
            Assert.AreEqual("Days of Future Present", result.Next.Name);
            Assert.AreEqual("http://gateway.marvel.com/v1/public/events/233", result.Previous.ResourceUri);
            Assert.AreEqual("Atlantis Attacks", result.Previous.Name);
        }
    }
}
