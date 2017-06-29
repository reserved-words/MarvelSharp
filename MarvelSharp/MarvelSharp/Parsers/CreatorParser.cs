using MarvelSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Parsers
{
    internal class CreatorParser : BaseParser<Creator>
    {
        public override Creator Parse(dynamic result)
        {
            return new Creator
            {
                Id = result.id
            };
        }
    }
}
