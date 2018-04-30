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

            Assert.Contains(MarvelApiResources.ParameterFirstName, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterMiddleName, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterLastName, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSuffix, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterFirstNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterMiddleNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterLastNameStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSeries, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterEvents, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStories, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterOrderBy, result.Keys);

            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterComics));

            Assert.AreEqual(sut.FirstName, result[MarvelApiResources.ParameterFirstName]);
            Assert.AreEqual(sut.MiddleName, result[MarvelApiResources.ParameterMiddleName]);
            Assert.AreEqual(sut.LastName, result[MarvelApiResources.ParameterLastName]);
            Assert.AreEqual(sut.Suffix, result[MarvelApiResources.ParameterSuffix]);
            Assert.AreEqual(sut.FirstNameStartsWith, result[MarvelApiResources.ParameterFirstNameStartsWith]);
            Assert.AreEqual(sut.MiddleNameStartsWith, result[MarvelApiResources.ParameterMiddleNameStartsWith]);
            Assert.AreEqual(sut.LastNameStartsWith, result[MarvelApiResources.ParameterLastNameStartsWith]);
            Assert.AreEqual(sut.NameStartsWith, result[MarvelApiResources.ParameterNameStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Series), result[MarvelApiResources.ParameterSeries]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Events), result[MarvelApiResources.ParameterEvents]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Stories), result[MarvelApiResources.ParameterStories]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[MarvelApiResources.ParameterOrderBy]);
        }
    }
}
