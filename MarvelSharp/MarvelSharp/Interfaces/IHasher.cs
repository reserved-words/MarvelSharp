using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Interfaces
{
    public interface IHasher
    {
        string Hash(string input);
    }
}
