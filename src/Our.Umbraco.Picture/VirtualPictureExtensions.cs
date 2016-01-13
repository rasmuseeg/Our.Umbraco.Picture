using Our.Umbraco.Picture.Models;
using Umbraco.Web;
using System.Collections.Generic;

namespace Our.Umbraco.Picture
{
    public static class VirtualPictureExtensions
    {
        #region Constructors
        public static VirtualPictureElement Picture(this UmbracoHelper helper, string src)
        {
            return new VirtualPictureElement(src);
        }
        #endregion

        #region Linq

        public static VirtualPictureElement Srcset(this VirtualPictureElement picture, int width, int? height)
        {
            string croppedUrl = string.Format("{0}?width={1}", picture.VirtualPath, width);

            if (height.HasValue)
                croppedUrl += "?" + height.Value;

            croppedUrl += "&mode=crop";

            picture.Srcset.Add(croppedUrl);

            return picture;
        }

        public static VirtualPictureElement Srcset(this VirtualPictureElement picture, int width, int? height, params double[] devicePixelRatio)
        {
            if (string.IsNullOrEmpty(picture.VirtualPath))
                throw new System.ArgumentNullException("VirtualPath", "Missing VirtualPath from Picture. Use Umbraco.Picture(String)");

            var srcsets = new List<string>();
            foreach (double ratio in devicePixelRatio)
            {
                int newWidth = (int)(width * ratio);
                int? newHeight = height.HasValue ? (int)(height.Value * ratio) : height;

                string croppedUrl = string.Format("{0}?width={1}", picture.VirtualPath, newWidth);

                if (newHeight.HasValue)
                    croppedUrl += "?" + newHeight.Value;

                croppedUrl += "&mode=crop";
                croppedUrl += " x" + string.Format("{0:0.##}", ratio).Replace(',', '.');

                picture.Srcset.Add(croppedUrl);
            }

            return picture;
        }

        public static VirtualPictureElement Source(this VirtualPictureElement picture, string media, int width, int? height)
        {
            if (string.IsNullOrEmpty(picture.VirtualPath))
                throw new System.ArgumentNullException("VirtualPath", "Missing VirtualPath from Picture. Use Umbraco.Picture(IPublishedContent)");

            string croppedUrl = string.Format("{0}?width={1}", picture.VirtualPath, width);

            if (height.HasValue)
                croppedUrl += "?" + height.Value;

            croppedUrl += "&mode=crop";

            picture.Sources.Add(new SourceElement {
                Media = media,
                Srcset = new List<string> {
                    { croppedUrl }
                }
            });
            return picture;
        }

        public static VirtualPictureElement Source(this VirtualPictureElement picture, string media, int width, int? height, params double[] devicePixelRatio)
        {
            if (string.IsNullOrEmpty(picture.VirtualPath))
                throw new System.ArgumentNullException("VirtualPath", "Missing VirtualPath from Picture. Use Umbraco.Picture(String)");

            var srcsets = new List<string>();
            foreach (double pixelRatio in devicePixelRatio)
            {
                if (pixelRatio <= 0.9) continue;

                int newWidth = (int)(width * pixelRatio);
                int? newHeight = height.HasValue ? (int?)(height.Value * pixelRatio) : height;

                string croppedUrl = string.Format("{0}?width={1}&height={2}&mode=crop", picture.VirtualPath, newWidth, newHeight);
                srcsets.Add(string.Format("{0} {1}", croppedUrl, string.Format("{0:0.##}x", pixelRatio).Replace(',', '.')));
            }

            picture.Sources.Add(new SourceElement
            {
                Media = media,
                Srcset = srcsets
            });
            return picture;
        }
        #endregion
    }
}
