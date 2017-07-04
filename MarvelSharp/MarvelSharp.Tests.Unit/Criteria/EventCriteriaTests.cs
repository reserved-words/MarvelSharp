using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using NUnit.Framework;
using MarvelSharp.Internal.Extensions;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Criteria
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
                OrderBy = EventOrder.StartDateAscending
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(ParameterName, result.Keys);
            Assert.Contains(ParameterNameStartsWith, result.Keys);
            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterCharacters, result.Keys);
            Assert.Contains(ParameterCreators, result.Keys);
            Assert.Contains(ParameterStories, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(ParameterEvents));
            Assert.IsFalse(result.Keys.Contains(ParameterSeries));

            Assert.AreEqual(sut.Name, result[ParameterName]);
            Assert.AreEqual(sut.NameStartsWith, result[ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Characters), result[ParameterCharacters]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Creators), result[ParameterCreators]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Stories), result[ParameterStories]);
            Assert.AreEqual(sut.OrderBy.GetStringValue(), result[ParameterOrderBy]);
        }
    }
}
