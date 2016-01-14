
# Our.Umbraco.Picture
A extension library for generating HTML5 Picture element

## How to use

Download ``picturefill.min.js`` from https://github.com/scottjehl/picturefill

```
    @Html.RequiresJs("~/Scripts/picturefill.min.js", 101);
```

### Basic
This way you can have multiple images, and sources.
Lets say a cat, becomes a tiger, if width > 480px

```
@{
    var cat = Umbraco.Media(1000);
    var tiger = Umbraco.Media(1001);
    var picture = Umbraco.Picture()
        .Source("(min-width:480px)", tiger.GetCropUrl(768, 300))
        .Source("(min-width:320px)", cat.GetCropUrl(480, 300) + " x1", cat.GetCropUrl(960, 600) + " x2")
        .Srcset(cat.GetCropUrl(768, 300))
        .Attr("class", "img-responsive img-fluid")
        .Alt("Cat becomes tiger");

    @Html.RenderPicture(picture);
}
```

### Typed
Simple but effective.
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

## In-action:
http://perspektiv.wideroe.no/