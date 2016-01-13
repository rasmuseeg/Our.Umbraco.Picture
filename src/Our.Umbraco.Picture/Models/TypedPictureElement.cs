using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Core.Models;

namespace Our.Umbraco.Picture.Models
{
    public class TypedPictureElement : PictureElement
    {
        public IPublishedContent Content { get; set; }
        private string PropertyAlias { get; set; }

        private ImageCropMode ImageCropMode { get; set; }

        public TypedPictureElement(IPublishedContent content, string propertyAlias = "umbracoFile", ImageCropMode imageCropMode = ImageCropMode.Crop)
            : base()
        {
            if (content == null)
                throw new System.ArgumentNullException("Content", "Missing Content from Picture. Use Umbraco.Picture(IPublishedContent)");

            ImageCropMode = imageCropMode;
            Content = content;
            PropertyAlias = propertyAlias;
        }

        public string GetCropUrl(int width, int? height, double? devicePixelRatio = null)
        {
            string url = this.Content.GetCropUrl(width: width, height: height, imageCropMode: this.ImageCropMode);

            if(devicePixelRatio.HasValue)
                url += " " + string.Format("{0:0.##}x", devicePixelRatio).Replace(',', '.');

            return url;
        }
    }
}
