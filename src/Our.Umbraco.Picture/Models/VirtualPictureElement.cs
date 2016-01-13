using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Core.Models;

namespace Our.Umbraco.Picture.Models
{
    public class VirtualPictureElement : PictureElement
    {
        public string VirtualPath { get; set; }

        #region Constructors
        public VirtualPictureElement(string virtualPath)
            : base()
        {
            VirtualPath = virtualPath;
        }
        #endregion
    }
}
