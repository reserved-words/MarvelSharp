using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Extensions;
using NUnit.Framework;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Criteria
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
            Assert.AreEqual(12, result.Count);

            Assert.Contains(ParameterTitle, result.Keys);
            Assert.Contains(ParameterTitleStartsWith, result.Keys);
            Assert.Contains(ParameterStartYear, result.Keys);
            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterCharacters, result.Keys);
            Assert.Contains(ParameterComics, result.Keys);
            Assert.Contains(ParameterCreators, result.Keys);
            Assert.Contains(ParameterEvents, result.Keys);
            Assert.Contains(ParameterStories, result.Keys);
            Assert.Contains(ParameterContains, result.Keys);
            Assert.Contains(ParameterSeriesType, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);

            Assert.AreEqual(sut.Title, result[ParameterTitle]);
            Assert.AreEqual(sut.TitleStartsWith, result[ParameterTitleStartsWith]);
            Assert.AreEqual(sut.StartYear.ToString(), result[ParameterStartYear]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Comics), result[ParameterComics]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Stories), result[ParameterStories]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Characters), result[ParameterCharacters]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Creators), result[ParameterCreators]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Events), result[ParameterEvents]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Contains.Select(c => c.GetStringValue())), result[ParameterContains]);
            Assert.AreEqual(sut.SeriesType.GetStringValue(), result[ParameterSeriesType]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[ParameterOrderBy]);
        }
    }
}
