
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using SharpShell.SharpPreviewHandler;
using Svg;

namespace iShell.Svg;

/// <summary>
/// A user control that shows the svg file.
/// </summary>
public partial class SvgPreviewHandlerControl : PreviewHandlerControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SvgPreviewHandlerControl"/> class.
    /// </summary>
    public SvgPreviewHandlerControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Adds the svg content file to the control.
    /// </summary>
    public void DoPreview(string selectedFilePath)
    {
        try
        {
            var svg = SvgDocument.Open(selectedFilePath);
            var svgSize = svg.GetDimensions().ToSize();
                
            using var bitmap = new Bitmap(svgSize.Width, svgSize.Height, PixelFormat.Format32bppArgb);
            svg.Draw(bitmap);
                
            svgPictureBox.Image = bitmap;
        }
        catch
        {
            using var fakeBitmap = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
            using var graphics = Graphics.FromImage(fakeBitmap);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(Color.Red);

            svgPictureBox.Image = fakeBitmap;
        }
    }
}
