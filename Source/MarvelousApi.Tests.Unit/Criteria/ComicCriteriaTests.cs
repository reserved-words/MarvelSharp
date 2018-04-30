using System;
using System.Collections.Generic;
using System.Linq;
using MarvelousApi.Criteria;
using MarvelousApi.Enum;
using MarvelousApi.Internal.Extensions;
using MarvelousApi.Model;
using NUnit.Framework;

namespace MarvelousApi.Tests.Unit.Criteria
{
    [TestFixture]
    public class ComicCriteriaTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new ComicCriteria
            {
                Title = "TestTitle456",
                TitleStartsWith = "TestStartTitle789",
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Format = Format.Comic,
                FormatType = FormatType.Collection,
                Series = new List<int> { 12 },
                Stories = new List<int>(),
                Events = new List<int> { 0 },
                Creators = new List<int> { 11, 15 },
                OrderBy = new List<ComicOrder> { ComicOrder.FocDateDescending },
                NoVariants = false,
                DateDescriptor = DateDescriptor.LastWeek,
                DateRange = new DateRange
                {
                    StartDate = new DateTime(2000, 1, 1, 15, 0, 0),
                    EndDate = new DateTime(2005, 2, 2, 19, 10, 15)
                },
                StartYear = 2000,
                IssueNumber = 2,
                DiamondCode = "TestDC",
                DigitalId = 5,
                Upc = "TestUPC",
                Isbn = "TestISBN",
                Ean = "TestEAN",
                Issn = "TestISSN",
                HasDigitalIssue = true,
                SharedAppearances = new List<int> { 20, 15 },
                Collaborators = new List<int> { 2, 3 }
            };

            // Act
            var result = sut.ToDictionary();

            // Assert
            Assert.AreEqual(23, result.Count);

            Assert.Contains(MarvelApiResources.ParameterTitle, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterTitleStartsWith, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterModifiedSince, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterFormat, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterFormatType, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCreators, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSeries, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterEvents, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterNoVariants, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterDateDescriptor, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterDateRange, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterOrderBy, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterStartYear, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterIssueNumber, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterDiamondCode, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterDigitalId, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterUpc, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterIsbn, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterEan, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterIssn, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterHasDigitalIssue, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterSharedAppearances, result.Keys);
            Assert.Contains(MarvelApiResources.ParameterCollaborators, result.Keys);

            Assert.IsFalse(result.Keys.Contains(MarvelApiResources.ParameterStories));

            Assert.AreEqual(sut.Title, result[MarvelApiResources.ParameterTitle]);
            Assert.AreEqual(sut.TitleStartsWith, result[MarvelApiResources.ParameterTitleStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(MarvelApiResources.ParameterDateTimeFormat), result[MarvelApiResources.ParameterModifiedSince]);
            Assert.AreEqual(sut.Format.GetStringValue(), result[MarvelApiResources.ParameterFormat]);
            Assert.AreEqual(sut.FormatType.GetStringValue(), result[MarvelApiResources.ParameterFormatType]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Creators), result[MarvelApiResources.ParameterCreators]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Series), result[MarvelApiResources.ParameterSeries]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Events), result[MarvelApiResources.ParameterEvents]);
            Assert.AreEqual(MarvelApiResources.ParameterValueFalse, result[MarvelApiResources.ParameterNoVariants]);
            Assert.AreEqual(sut.DateDescriptor.GetStringValue(), result[MarvelApiResources.ParameterDateDescriptor]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.DateRange.Value.StartDate, sut.DateRange.Value.EndDate), result[MarvelApiResources.ParameterDateRange]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[MarvelApiResources.ParameterOrderBy]);
            Assert.AreEqual(sut.StartYear.ToString(), result[MarvelApiResources.ParameterStartYear]);
            Assert.AreEqual(sut.IssueNumber.ToString(), result[MarvelApiResources.ParameterIssueNumber]);
            Assert.AreEqual(sut.DiamondCode, result[MarvelApiResources.ParameterDiamondCode]);
            Assert.AreEqual(sut.DigitalId.ToString(), result[MarvelApiResources.ParameterDigitalId]);
            Assert.AreEqual(sut.Upc, result[MarvelApiResources.ParameterUpc]);
            Assert.AreEqual(sut.Isbn, result[MarvelApiResources.ParameterIsbn]);
            Assert.AreEqual(sut.Ean, result[MarvelApiResources.ParameterEan]);
            Assert.AreEqual(sut.Issn, result[MarvelApiResources.ParameterIssn]);
            Assert.AreEqual(MarvelApiResources.ParameterValueTrue, result[MarvelApiResources.ParameterHasDigitalIssue]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.SharedAppearances), result[MarvelApiResources.ParameterSharedAppearances]);
            Assert.AreEqual(string.Join(MarvelApiResources.ParameterListSeparator, sut.Collaborators), result[MarvelApiResources.ParameterCollaborators]);
        }
    }
}
