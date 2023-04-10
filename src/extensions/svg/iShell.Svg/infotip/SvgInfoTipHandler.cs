
using System;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpInfoTipHandler;
using Svg;

namespace iShell.Svg;

/// <summary>
/// The <c>SvgInfoTipHandler</c> shell handler provides an info tip for SVG file.
/// </summary>
[ComVisible(true)]
[DisplayName("SVG File Info Tip Handler")]
[COMServerAssociation(AssociationType.ClassOfExtension, ".svg")]
public class SvgInfoTipHandler : SharpInfoTipHandler
{
    /// <summary>
    /// Gets info for the selected item (SelectedItemPath).
    /// </summary>
    /// <param name="infoType">Type of info to return.</param>
    /// <param name="singleLine">if set to <c>true</c>, put the info in a single line.</param>
    /// <returns>
    /// Specified info for the selected file.
    /// </returns>
    protected override string GetInfo(RequestedInfoType infoType, bool singleLine)
    {
        switch (infoType)
        {
            case RequestedInfoType.InfoTip:
                try
                {
                    Log($"Creating info for '{SelectedItemPath}'");

                    var svg = SvgDocument.Open(SelectedItemPath);
                    var svgSize = svg.GetDimensions().ToSize();

                    return $"Dimensions: {svgSize.Width} x {svgSize.Height}";
                }
                catch(Exception e)
                {
                    LogError("An exception occured opening the svg file.", e);

                    return "Dimensions: Unknown";
                }

            default:
                return string.Empty;
        }
    }
}
