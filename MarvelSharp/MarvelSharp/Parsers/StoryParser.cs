using MarvelSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Parsers
{
    internal class StoryParser : BaseParser<Story>
    {
        public override Story Parse(dynamic result)
        {
            return new Story
            {
                Id = result.id
            };
        }
    }
}
