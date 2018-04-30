using System;
using System.Collections.Generic;
using System.Linq;
using MarvelousApi.Criteria;
using MarvelousApi.Enum;
using MarvelousApi.Internal.Extensions;
using NUnit.Framework;

namespace MarvelousApi.Tests.Unit.Criteria
{
    public class SeriesCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new SeriesCriteria
            {
                Title = "TestTitle159",
                TitleStartsWith = "Tr",
                StartYear = 2005,
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Characters = new List<int> { 1, 2, 3 },
                Comics = new List<int> { 21, 22, 23 },
                Creators = new List<int> { 11, 12, 13 },
                Events = new List<int> { 0, 56 },
                Stories = new List<int> { 0 },
                Contains = new List<Format> { Format.Comic, Format.Digest },
                SeriesType = SeriesType.OneShot,
                OrderBy = new List<SeriesOrder>()
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(11, result.Count);

            Assert.Contains(MarvelApiResources.ParameterTitle, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterTitleStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStartYear, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCharacters, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterComics, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCreators, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterEvents, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStories, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterContains, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSeriesType, result.Keys);

            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterOrderBy));

            Assert.AreEqual(sut.Title, result[MarvelApiResources.ParameterTitle]);
            Assert.AreEqual(sut.TitleStartsWith, result[MarvelApiResources.ParameterTitleStartsWith]);
            Assert.AreEqual(sut.StartYear.ToString(), result[MarvelApiResources.ParameterStartYear]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Comics), result[MarvelApiResources.ParameterComics]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Stories), result[MarvelApiResources.ParameterStories]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Characters), result[MarvelApiResources.ParameterCharacters]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Creators), result[MarvelApiResources.ParameterCreators]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Events), result[MarvelApiResources.ParameterEvents]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Contains.Select(c => c.GetStringValue())), result[MarvelApiResources.ParameterContains]);
            Assert.AreEqual(sut.SeriesType.GetStringValue(), result[MarvelApiResources.ParameterSeriesType]);
        }
    }
}
