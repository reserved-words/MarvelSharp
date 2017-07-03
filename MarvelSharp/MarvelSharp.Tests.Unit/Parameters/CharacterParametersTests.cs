using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MarvelSharp.Extensions;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Parameters
{
    [TestFixture]
    public class CharacterParametersTests
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
                OrderBy = CharacterOrder.NameAscending
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(7, result.Count);

            Assert.Contains(ParameterName, result.Keys);
            Assert.Contains(ParameterNameStartsWith, result.Keys);
            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterComics, result.Keys);
            Assert.Contains(ParameterSeries, result.Keys);
            Assert.Contains(ParameterStories, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(ParameterEvents));

            Assert.AreEqual(sut.Name, result[ParameterName]);
            Assert.AreEqual(sut.NameStartsWith, result[ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Comics), result[ParameterComics]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Series), result[ParameterSeries]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Stories), result[ParameterStories]);
            Assert.AreEqual(sut.OrderBy.GetStringValue(), result[ParameterOrderBy]);
        }
    }
}
