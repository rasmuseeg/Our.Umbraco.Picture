# Our.Umbraco.Picture
A extension library for generating HTML5 Picture element with ease.

## Installation

    PM > Install-Package Our.Umbraco.Picture

Download `picturefill.min.js` from https://github.com/scottjehl/picturefill
and place in the `~/scripts/` folder of your umbaco solution.

Include this in the header:

    @Html.RequiresJs("~/Scripts/picturefill.min.js", 101);

## How to
There a multiple ways to use this.

### Basic
This way you can have multiple images, and sources.
Lets say a cat, swapped with a tiger, if width > 480px

    @{
        IPublishedContent cat = Umbraco.TypedMedia(1000);
        IPublishedContent tiger = Umbraco.TypedMedia(1001);
        var picture = Umbraco.Picture()
            .Source("(min-width:480px)", tiger.GetCropUrl(768, 300))
            .Source("(min-width:320px)", cat.GetCropUrl(480, 300) + " x1", cat.GetCropUrl(960, 600) + " x2")
            .Srcset(cat.GetCropUrl(768, 300))
            .Attr("class", "img-responsive")
            .Alt("Cat becomes tiger");
    
        @Html.RenderPicture(picture);
    }


#### HTML

    <picture class="img-responsive">
        <!--[if IE 9]><video style="display: none;"><![endif]-->
        <source media="(min-width:480px)" 
                srcset="/media/1001/tiger.jpg?width=768&height=300&mode=crop">
        <source media="(min-width:320px)" 
                srcset="/media/1000/cat.jpg?width=480&height=300&mode=crop 1x, 
                        /media/1000/cat.jpgwidth=960&height=600&mode=crop 2x">
        <!--[if IE 9]></video><![endif]-->
        <img src="data:image/gif;base64,R0lGODlhAQABAAAAADs=" srcset="" alt="Cat becomes tiger" /> 
    </picture>

### Typed
Simple but effective.

    @{
        IPublishedContent media = Umbraco.TypedMedia(1000);
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

#### HTML

    <picture class="img-responsive">
        <!--[if IE 9]><video style="display: none;"><![endif]-->
        <source media="(min-width:480px)" 
                srcset="/media/1001/image.jpg?width=1200&height=300&mode=crop x1,
                        /media/1001/image.jpg?width=2400&height=600&mode=crop x2">
        ...
        <!--[if IE 9]></video><![endif]-->
        <img src="data:image/gif;base64,R0lGODlhAQABAAAAADs=" srcset="/media/1001/image.jpg?width=768&height=300&mode=crop" alt="..." /> 
    </picture>


## In-action:
* http://perspektiv.wideroe.no/

## References
* http://scottjehl.github.io/picturefill/
* http://www.html5rocks.com/en/tutorials/responsive/picture-element/

## Known Issues
none