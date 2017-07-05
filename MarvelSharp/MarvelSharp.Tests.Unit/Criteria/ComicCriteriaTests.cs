using System;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Extensions;
using MarvelSharp.Model;
using NUnit.Framework;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Criteria
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

            Assert.Contains(ParameterTitle, result.Keys);
            Assert.Contains(ParameterTitleStartsWith, result.Keys);
            Assert.Contains(ParameterModifiedSince, result.Keys);
            Assert.Contains(ParameterFormat, result.Keys);
            Assert.Contains(ParameterFormatType, result.Keys);
            Assert.Contains(ParameterCreators, result.Keys);
            Assert.Contains(ParameterSeries, result.Keys);
            Assert.Contains(ParameterEvents, result.Keys);
            Assert.Contains(ParameterNoVariants, result.Keys);
            Assert.Contains(ParameterDateDescriptor, result.Keys);
            Assert.Contains(ParameterDateRange, result.Keys);
            Assert.Contains(ParameterOrderBy, result.Keys);
            Assert.Contains(ParameterStartYear, result.Keys);
            Assert.Contains(ParameterIssueNumber, result.Keys);
            Assert.Contains(ParameterDiamondCode, result.Keys);
            Assert.Contains(ParameterDigitalId, result.Keys);
            Assert.Contains(ParameterUpc, result.Keys);
            Assert.Contains(ParameterIsbn, result.Keys);
            Assert.Contains(ParameterEan, result.Keys);
            Assert.Contains(ParameterIssn, result.Keys);
            Assert.Contains(ParameterHasDigitalIssue, result.Keys);
            Assert.Contains(ParameterSharedAppearances, result.Keys);
            Assert.Contains(ParameterCollaborators, result.Keys);

            Assert.IsFalse(result.Keys.Contains(ParameterStories));

            Assert.AreEqual(sut.Title, result[ParameterTitle]);
            Assert.AreEqual(sut.TitleStartsWith, result[ParameterTitleStartsWith]);
            Assert.AreEqual(sut.ModifiedSince.Value.ToString(ParameterDateTimeFormat), result[ParameterModifiedSince]);
            Assert.AreEqual(sut.Format.GetStringValue(), result[ParameterFormat]);
            Assert.AreEqual(sut.FormatType.GetStringValue(), result[ParameterFormatType]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Creators), result[ParameterCreators]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Series), result[ParameterSeries]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Events), result[ParameterEvents]);
            Assert.AreEqual(ParameterValueFalse, result[ParameterNoVariants]);
            Assert.AreEqual(sut.DateDescriptor.GetStringValue(), result[ParameterDateDescriptor]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.DateRange.Value.StartDate, sut.DateRange.Value.EndDate), result[ParameterDateRange]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.OrderBy.Select(o => o.GetStringValue())), result[ParameterOrderBy]);
            Assert.AreEqual(sut.StartYear.ToString(), result[ParameterStartYear]);
            Assert.AreEqual(sut.IssueNumber.ToString(), result[ParameterIssueNumber]);
            Assert.AreEqual(sut.DiamondCode, result[ParameterDiamondCode]);
            Assert.AreEqual(sut.DigitalId.ToString(), result[ParameterDigitalId]);
            Assert.AreEqual(sut.Upc, result[ParameterUpc]);
            Assert.AreEqual(sut.Isbn, result[ParameterIsbn]);
            Assert.AreEqual(sut.Ean, result[ParameterEan]);
            Assert.AreEqual(sut.Issn, result[ParameterIssn]);
            Assert.AreEqual(ParameterValueTrue, result[ParameterHasDigitalIssue]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.SharedAppearances), result[ParameterSharedAppearances]);
            Assert.AreEqual(string.Join(ParameterListSeparator, sut.Collaborators), result[ParameterCollaborators]);
        }
    }
}
