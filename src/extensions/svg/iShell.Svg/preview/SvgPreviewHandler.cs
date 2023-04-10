
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpPreviewHandler;

namespace iShell.Svg;

/// <summary>
/// The <see cref="SvgPreviewHandler"/> is a preview handler that shows the <strong>SVG</strong> file.
/// </summary>
[ComVisible(true)]
[COMServerAssociation(AssociationType.ClassOfExtension, ".svg")]
[DisplayName("SVG Preview Handler")]
[Guid("D5B86923-10E3-4381-8785-DB27A283AA4F")]
[PreviewHandler(DisableLowILProcessIsolation = false)]
public class SvgPreviewHandler : SharpPreviewHandler
{
    /// <summary>
    /// DoPreview must create the preview handler user interface and initialize it with data provided by the shell.
    /// </summary>
    /// <returns>
    /// The preview handler user interface.
    /// </returns>
    protected override PreviewHandlerControl DoPreview()
    {
        //  Create the handler control.
        var handler = new SvgPreviewHandlerControl();

        //  Do we have a file path? If so, we can do a preview.
        if (!string.IsNullOrEmpty(SelectedFilePath))
        {
            handler.DoPreview(SelectedFilePath);
        }

        //  Return the handler control.
        return handler;
    }
}
