using System;
using System.Collections.Generic;
using System.Linq;
using MarvelousApi.Criteria;
using MarvelousApi.Enum;
using MarvelousApi.Internal.Extensions;
using NUnit.Framework;

namespace MarvelousApi.Tests.Unit.Criteria
{
    [TestFixture]
    public class EventCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new EventCriteria
            {
                Name = "TestName999",
                NameStartsWith = "TestStartName0",
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Comics = new List<int>(),
                Series = new List<int>(),
                Characters = new List<int> { 1, 2, 3 },
                Stories = new List<int> { 0 },
                Creators = new List<int> { 11111, 558, 123 },
                OrderBy = new List<EventOrder> { EventOrder.StartDateAscending, EventOrder.ModifiedDescending }
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(MarvelApiResources.ParameterName, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCharacters, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCreators, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStories, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterEvents));
            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterSeries));

            Assert.AreEqual(sut.Name, result[MarvelApiResources.ParameterName]);
            Assert.AreEqual(sut.NameStartsWith, result[MarvelApiResources.ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Characters), result[MarvelApiResources.ParameterCharacters]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Creators), result[MarvelApiResources.ParameterCreators]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Stories), result[MarvelApiResources.ParameterStories]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[MarvelApiResources.ParameterOrderBy]);
        }
    }
}
