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
    public class CharacterCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new CharacterCriteria
            {
                Name = "TestName456",
                NameStartsWith = "TestStartName789",
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Comics = new List<int> { 1, 2, 3 },
                Series = new List<int> { 12 },
                Events = new List<int>(),
                Stories = new List<int> { 0 },
                OrderBy = new List<CharacterOrder> { CharacterOrder.NameAscending, CharacterOrder.ModifiedDescending }
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(MarvelApiResources.ParameterName, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterComics, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSeries, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStories, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterEvents));

            Assert.AreEqual(sut.Name, result[MarvelApiResources.ParameterName]);
            Assert.AreEqual(sut.NameStartsWith, result[MarvelApiResources.ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Comics), result[MarvelApiResources.ParameterComics]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Series), result[MarvelApiResources.ParameterSeries]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Stories), result[MarvelApiResources.ParameterStories]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[MarvelApiResources.ParameterOrderBy]);
        }
    }
}
