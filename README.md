# Basic usage

Download ``picturefill.min.js`` from https://github.com/scottjehl/picturefill

```
    @Html.RequiresJs("~/Scripts/picturefill.min.js", 101);
```

## Basic
```
@{
    var media = Umbraco.Media(1000);
    var picture = Umbraco.Picture()
        .Source("(min-width:992px)", media.GetCropUrl(1200, 300))
        .Source("(min-width:768px)", media.GetCropUrl(992, 300))
        .Source("(min-width:480px)", media.GetCropUrl(768, 300))
        .Source("(min-width:320px)", media.GetCropUrl(480, 300) + " x1", media.GetCropUrl(960, 600) + " x2")
        .Srcset(media.GetCropUrl(768, 300))
        .Attr("class", "img-responsive")
        .Alt(media.GetPropertyValue<string>("alt", ""));

    @Html.RenderPicture(picture);
}
```

## Typed

```
@{
    var picture = Umbraco.Picture(media)
        .Source("(min-width:992px)", 1200, 300, 1.0, 2.0)
        .Source("(min-width:768px)", 992, 300, 1.0, 2.0)
        .Source("(min-width:480px)", 768, 300, 1.0, 2.0)
        .Source("(min-width:320px)", 480, 300, 1.0, 2.0)
        .Srcset(768, 300)
        .Attr("class", "img-responsive")
        .Alt(media.GetPropertyValue<string>("alt", ""));

    @Html.RenderPicture(picture);
}
```

# Our.Umbraco.Picture
A extension library for generating HTML5 Picture element