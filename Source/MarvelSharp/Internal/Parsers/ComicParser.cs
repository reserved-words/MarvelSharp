
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Parsers
{
    internal class ComicParser : BaseParser<Comic>
    {
        public override Comic Parse(dynamic result)
        {
            return new Comic
            {
                Id = result.id,
                DigitalId = result.digitalId,
                Title = result.title,
                IssueNumber = result.issueNumber,
                VariantDescription = result.variantDescription,
                Description = result.description,
                Modified = ParseDateOffset(result.modified),
                Isbn = result.isbn,
                Upc = result.upc,
                DiamondCode = result.diamondCode,
                Ean = result.ean,
                Issn = result.issn,
                Format = result.format,
                PageCount = result.pageCount,
                TextObjects = ParseComicTextObjects(result.textObjects),
                ResourceUri = result.resourceURI,
                Urls = ParseUrls(result.urls),
                Series = ParseItem(result.series),
                Variants = ParseItems(result.variants),
                Collections = ParseItems(result.collections),
                CollectedIssues = ParseItems(result.collectedIssues),
                Dates = ParseDates(result.dates),
                Prices = ParsePrices(result.prices),
                Thumbnail = ParseImage(result.thumbnail),
                Images = ParseImages(result.images),
                Creators = ParseItemCollection(result.creators, false, true),
                Characters = ParseItemCollection(result.characters),
                Stories = ParseItemCollection(result.stories, true),
                Events = ParseItemCollection(result.events)
            };
        }
    }
}
