using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.Picture.Models
{
    public interface ISourceElement
    {
        ICollection<string> Srcset { get; set; }

        string Media { get; set; }

        string Type { get; set; }
    }
}
