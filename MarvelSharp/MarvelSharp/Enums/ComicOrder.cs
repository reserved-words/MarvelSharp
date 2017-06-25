using MarvelSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Enums
{
    public enum ComicOrder
    {
        [StringValue("focDate")]
        FocDateAscending,
        [StringValue("onsaleDate")]
        OnSaleDateAscending,
        [StringValue("title")]
        TitleAscending,
        [StringValue("issueNumber")]
        IssueNumberAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-focDate")]
        FocDateDescending,
        [StringValue("-onsaleDate")]
        OnSaleDateDescending,
        [StringValue("-title")]
        TitleDescending,
        [StringValue("-issueNumber")]
        IssueNumberDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
