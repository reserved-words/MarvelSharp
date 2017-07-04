using System;
using System.Collections.Generic;
using MarvelSharp.Criteria;
using NUnit.Framework;
using static MarvelSharp.MarvelApiResources;
using MarvelSharp.Internal.Extensions;

namespace MarvelSharp.Tests.Unit.Criteria
{
    public class StoryCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new StoryCriteria
            {
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Characters = new List<int> { 1, 2, 3 },
                Comics = new List<int> { 21, 22, 23 },
                Creators = new List<int> { 11, 12, 13 },
                Events = new List<int> { 0, 56 },
                Series = new List<int> { 0 },
                OrderBy = StoryOrder.IdAscending
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterCharacters, result.Keys);
            Assert.Contains(ParameterComics, result.Keys);
            Assert.Contains(ParameterCreators, result.Keys);
            Assert.Contains(ParameterEvents, result.Keys);
            Assert.Contains(ParameterSeries, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);

            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Comics), result[ParameterComics]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Series), result[ParameterSeries]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Characters), result[ParameterCharacters]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Creators), result[ParameterCreators]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Events), result[ParameterEvents]);
            Assert.AreEqual(sut.OrderBy.GetStringValue(), result[ParameterOrderBy]);
        }
    }
}
