using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Our.Umbraco.Picture.Models
{
    public interface IPictureElement
    {
        List<ISourceElement> Sources { get; set; }

        string Alt { get; set; }

        string Src { get; set; }

        ICollection<string> Srcset { get; set; }

        Dictionary<string, string> Attributes { get; set; }

        string ToString();
    }
}