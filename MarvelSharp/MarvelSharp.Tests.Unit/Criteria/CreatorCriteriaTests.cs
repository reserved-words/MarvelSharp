using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Extensions;
using NUnit.Framework;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Criteria
{
    [TestFixture]
    public class CreatorCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new CreatorCriteria
            {
                FirstName = "TestFirstName456",
                MiddleName = "TestMiddleName5325",
                LastName = "TestLastName9999",
                Suffix = "TestSuffix0",
                NameStartsWith = "TestName757",
                FirstNameStartsWith = "TestName159",
                MiddleNameStartsWith = "TestName333",
                LastNameStartsWith = "TestName987",
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Series = new List<int> { 12 },
                Events = new List<int> { 15, 999 },
                Stories = new List<int> { 0, 1 },
                OrderBy = new List<CreatorOrder> { CreatorOrder.LastNameAscending }
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(13, result.Count);

            Assert.Contains(ParameterFirstName, result.Keys);
            Assert.Contains(ParameterMiddleName, result.Keys);
            Assert.Contains(ParameterLastName, result.Keys);
            Assert.Contains(ParameterSuffix, result.Keys);
            Assert.Contains(ParameterNameStartsWith, result.Keys);
            Assert.Contains(ParameterFirstNameStartsWith, result.Keys);
            Assert.Contains(ParameterMiddleNameStartsWith, result.Keys);
            Assert.Contains(ParameterLastNameStartsWith, result.Keys);
            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterSeries, result.Keys);
            Assert.Contains(ParameterEvents, result.Keys);
            Assert.Contains(ParameterStories, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(ParameterComics));

            Assert.AreEqual(sut.FirstName, result[ParameterFirstName]);
            Assert.AreEqual(sut.MiddleName, result[ParameterMiddleName]);
            Assert.AreEqual(sut.LastName, result[ParameterLastName]);
            Assert.AreEqual(sut.Suffix, result[ParameterSuffix]);
            Assert.AreEqual(sut.FirstNameStartsWith, result[ParameterFirstNameStartsWith]);
            Assert.AreEqual(sut.MiddleNameStartsWith, result[ParameterMiddleNameStartsWith]);
            Assert.AreEqual(sut.LastNameStartsWith, result[ParameterLastNameStartsWith]);
            Assert.AreEqual(sut.NameStartsWith, result[ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Series), result[ParameterSeries]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Events), result[ParameterEvents]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Stories), result[ParameterStories]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[ParameterOrderBy]);
        }
    }
}
