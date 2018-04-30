using System;
using System.Collections.Generic;
using System.Linq;
using MarvelousApi.Criteria;
using MarvelousApi.Enum;
using MarvelousApi.Internal.Extensions;
using NUnit.Framework;

namespace MarvelousApi.Tests.Unit.Criteria
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
                OrderBy = new List<StoryOrder> { StoryOrder.IdAscending }
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCharacters, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterComics, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCreators, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterEvents, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSeries, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterOrderBy, result.Keys);

            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Comics), result[MarvelApiResources.ParameterComics]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Series), result[MarvelApiResources.ParameterSeries]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Characters), result[MarvelApiResources.ParameterCharacters]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Creators), result[MarvelApiResources.ParameterCreators]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Events), result[MarvelApiResources.ParameterEvents]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[MarvelApiResources.ParameterOrderBy]);
        }
    }
}
