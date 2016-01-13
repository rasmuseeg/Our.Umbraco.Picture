using System.Collections.Generic;

namespace Our.Umbraco.Picture.Models
{
    public class SourceElement : ISourceElement
    {
        public ICollection<string> Srcset { get; set; }

        public string Media { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("<source media=\"{0}\" srcset=\"{1}\">", this.Media, string.Join(",", this.Srcset));
        }

        #region contructors
        public SourceElement()
        {
            Srcset = new List<string>();
        }
        #endregion
    }
}
