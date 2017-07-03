
// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class Story : ItemBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public ItemCollection Creators { get; set; }
        public ItemCollection Characters { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Events { get; set; }
        public Item OriginalIssue { get; set; }

        public override string ToString() => Title;
    }
}
