using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelSharp.Parsers
{
    internal abstract class BaseParser<T> : IParser<T>
    {
        public Response<T1> GetResponse<T1>(dynamic parsed)
        {
            if (parsed.code != MarvelApi.SuccessCode)
            {
                return new Response<T1>
                {
                    Success = false,
                    Code = parsed.code,
                    Status = parsed.status
                };
            }
            else
            {
                return new Response<T1>
                {
                    Success = true,
                    Code = parsed.code,
                    Status = parsed.status,
                    Copyright = parsed.copyright,
                    AttributionText = parsed.attributionText,
                    AttributionHtml = parsed.attributionHtml,
                    Data = new Data<T1>
                    {
                        Offset = parsed.data.offset,
                        Limit = parsed.data.limit,
                        Total = parsed.data.total,
                        Count = parsed.data.count,
                        Result = typeof(T1).IsGenericType ? ParseList(parsed.data.results) : ParseSingle(parsed.data.results)
                    },
                    ETag = parsed.eTag
                };
            }
        }

        public abstract T Parse(dynamic result);

        public List<T> ParseList(dynamic results)
        {
            var items = new List<T>();

            foreach (var result in results)
            {
                items.Add(Parse(result));
            }

            return items;
        }

        public T ParseSingle(dynamic results)
        {
            List<T> list = ParseList(results);

            return list.Single();
        }

        protected Image ParseImage(dynamic result)
        {
            return result == null
                ? null
                : new Image { Path = result.path, Extension = result.extension };
        }

        protected List<Image> ParseImages(dynamic images)
        {
            var list = new List<Image>();

            foreach (var image in images)
            {
                list.Add(new Image { Path = image.path, Extension = image.extension });
            }

            return list;
        }

        protected List<Url> ParseUrls(dynamic urls)
        {
            var list = new List<Url>();

            foreach (var url in urls)
            {
                list.Add(new Url { Type = url.type, Value = url.url });
            }

            return list;
        }

        protected List<ComicTextObject> ParseComicTextObjects(dynamic items)
        {
            var list = new List<ComicTextObject>();

            foreach (var item in items)
            {
                list.Add(new ComicTextObject
                {
                    Type = item.type,
                    Language = item.language,
                    Text = item.text
                });
            }

            return list;
        }

        protected List<PriceItem> ParsePrices(dynamic items)
        {
            var list = new List<PriceItem>();

            foreach (var item in items)
            {
                list.Add(new PriceItem
                {
                    Type = item.type,
                    Price = item.price
                });
            }

            return list;
        }

        protected List<DateItem> ParseDates(dynamic items)
        {
            var list = new List<DateItem>();

            foreach (var item in items)
            {
                list.Add(new DateItem
                {
                    Type = item.type,
                    Date = ParseDateOffset(item.date)
                });
            }

            return list;
        }

        protected DateTime? ParseDate(dynamic date)
        {
            if (date == null)
                return null;
            
            var dateType = date.Type;

            if (dateType == JTokenType.Date)
                return date;

            if (dateType == JTokenType.String)
            {
                DateTime dateValue;
                return DateTime.TryParse((string)date, out dateValue) ? dateValue : (DateTime?)null;
            }

            return null;
        }

        protected DateTimeOffset? ParseDateOffset(dynamic date)
        {
            if (date == null)
                return null;

            var dateType = date.Type;

            if (dateType == JTokenType.Date)
                return date;

            if (dateType == JTokenType.String)
            {
                DateTimeOffset dateValue;
                return DateTimeOffset.TryParse((string)date, out dateValue) ? dateValue : (DateTimeOffset?)null;
            }

            return null;
        }

        protected ItemCollection ParseItemCollection(dynamic collection, bool includeType = false, bool includeRole = false)
        {
            if (collection == null)
                return null;

            return new ItemCollection
            {
                Available = collection.available,
                CollectionUri = collection.collectionURI,
                Items = ParseItems(collection.items, includeType, includeRole),
                Returned = collection.returned
            };
        }

        protected List<Item> ParseItems(dynamic items, bool includeType = false, bool includeRole = false)
        {
            var list = new List<Item>();

            foreach (var item in items)
            {
                if (item != null)
                {
                    list.Add(ParseItem(item, includeType, includeRole));
                }
            }

            return list;
        }

        protected Item ParseItem(dynamic item, bool includeType = false, bool includeRole = false)
        {
            return item == null
                ? null
                : new Item
                {
                    Name = item.name,
                    ResourceUri = item.resourceURI,
                    Type = includeType ? item.type : null,
                    Role = includeRole ? item.role : null
                };
        }
    }
}
