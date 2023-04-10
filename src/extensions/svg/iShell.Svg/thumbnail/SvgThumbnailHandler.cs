
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpThumbnailHandler;

using Svg;

namespace iShell.Svg;

/// <summary>
/// The <c>SvgThumbnailHandler</c> shell handler provides a thumbnail for SVG files.
/// </summary>
[ComVisible(true)]
[DisplayName("SVG File Thumbnail Handler")]
[COMServerAssociation(AssociationType.FileExtension, ".svg")]
public class SvgThumbnailHandler : SharpThumbnailHandler
{
    /// <summary>
    /// Gets the thumbnail image.
    /// </summary>
    /// <param name="width">The width of the image that should be returned.</param>
    /// <returns>
    /// The image for the thumbnail.
    /// </returns>
    protected override Bitmap GetThumbnailImage(uint width)
    {
        Log($"Creating thumbnail for '{SelectedItemStream.Name}'");

        try
        {
            var thumbnailSize = new Size((int)width, (int)width);
            var svg = SvgDocument.Open<SvgDocument>(SelectedItemStream);
            svg.Width = new SvgUnit(SvgUnitType.Pixel, thumbnailSize.Width);
            svg.Height = new SvgUnit(SvgUnitType.Pixel, thumbnailSize.Height);

            var bitmap = new Bitmap(thumbnailSize.Width, thumbnailSize.Height, PixelFormat.Format32bppArgb);
            svg.Draw(bitmap);

            return bitmap;
        }
        catch (Exception exception)
        {
            LogError("An exception occured opening the svg file.", exception);

            return null;
        }
    }
}
