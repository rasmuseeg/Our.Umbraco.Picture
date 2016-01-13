using System.Web;
using Our.Umbraco.Picture.Models;
using Umbraco.Web;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Our.Umbraco.Picture
{
    public static class TypedPictureExtensions
    {
        #region Constructors
        public static TypedPictureElement Picture(this UmbracoHelper helper, IPublishedContent content)
        {
            return new TypedPictureElement(content);
        }

        public static TypedPictureElement Picture(this IPublishedContent content)
        {
            return new TypedPictureElement(content);
        }
        #endregion

        #region Linq

        public static TypedPictureElement Srcset(this TypedPictureElement picture, int width, int? height)
        {
            string croppedUrl = picture.Content.GetCropUrl(width: width, height: height, imageCropMode: ImageCropMode.Crop);

            picture.Srcset.Add(croppedUrl);

            return picture;
        }

        public static TypedPictureElement Srcset(this TypedPictureElement picture, int width, int? height, params double[] devicePixelRatioArgs)
        {
            var srcsets = new List<string>();
            foreach (double devicePixelRatio in devicePixelRatioArgs)
            {
                int newWidth = (int)(width * devicePixelRatio);
                int? newHeight = height.HasValue ? (int)(height.Value * devicePixelRatio) : height;

                picture.Srcset.Add(picture.GetCropUrl(newWidth, newHeight, devicePixelRatio));
            }

            return picture;
        }

        public static TypedPictureElement Source(this TypedPictureElement picture, string media, int width, int? height)
        {
            picture.Sources.Add(new SourceElement {
                Media = media,
                Srcset = new List<string> {
                    { picture.GetCropUrl(width, height) }
                }
            });

            return picture;
        }

        public static TypedPictureElement Source(this TypedPictureElement picture, string media, int width, int? height, params double[] devicePixelRatioArgs)
        {
            if (picture.Content == null)
                throw new System.ArgumentNullException("Content", "Missing Content from Picture. Use Umbraco.Picture(IPublishedContent)");

            var srcsets = new List<string>();
            foreach (double devicePixelRatio in devicePixelRatioArgs)
            {
                int newWidth = (int)(width * devicePixelRatio);
                int? newHeight = height.HasValue ? (int?)(height.Value * devicePixelRatio) : height;

                srcsets.Add(picture.GetCropUrl(newWidth, newHeight, devicePixelRatio));
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
