using System.Web;
using System.Web.Mvc;
using Our.Umbraco.Picture.Models;
using Umbraco.Web;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using System.Text.RegularExpressions;

namespace Our.Umbraco.Picture
{
    public static class PictureExtensions
    {
        public static IPictureElement Picture(this UmbracoHelper helper)
        {
            return new PictureElement();
        }

        public static IPictureElement Picture(this HtmlHelper helper) {
            return new PictureElement();
        }

        public static IHtmlString RenderPicture(this HtmlHelper helper, IPictureElement picture) {
            return new HtmlString(picture.ToString());
        }

        #region Linq
        public static IPictureElement Attrs(this IPictureElement picture, Dictionary<string, string> attrs)
        {
            picture.Attributes = attrs;
            return picture;
        }

        public static IPictureElement Attr(this IPictureElement picture, string key, string value)
        {
            picture.Attributes.Add(key, value);
            return picture;
        }

        /// <summary>
        /// You should leave this empty
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        public static IPictureElement Src(this IPictureElement picture, string src)
        {
            picture.Src = src;
            return picture;
        }

        /// <summary>
        /// Add multiple sources in the srcset attribute on img element
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="srcset"></param>
        /// <returns></returns>
        public static IPictureElement Srcset(this IPictureElement picture, params string[] srcset)
        {
            picture.Srcset = srcset;
            return picture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="media"></param>
        /// <param name="srcsets"></param>
        /// <returns></returns>
        public static IPictureElement Source(this IPictureElement picture, string media, params string[] srcsets)
        {
            foreach (string src in srcsets)
            {
                picture.Sources.Add(new SourceElement { Media = media, Srcset = srcsets });
            }
            return picture;
        }

        public static IPictureElement Alt(this IPictureElement picture, string alt)
        {
            picture.Alt = alt;
            return picture;
        }

        public static IHtmlString Html(this IPictureElement picture)
        {
            return new HtmlString(picture.ToString());
        }

        public static void RenderHere(this IPictureElement picture)
        {
            HttpContext.Current.Response.Output.WriteLine(picture.ToString());
        }
        #endregion
    }
}
