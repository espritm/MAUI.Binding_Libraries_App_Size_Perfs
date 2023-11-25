using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Pspdfkit.UI
{
    public partial class PdfThumbnailBar
    {
        public sealed partial class ConvertToDrawable
        {
            public unsafe Java.Lang.Object Apply(Java.Lang.Object obj)
            {
                //We do nothing, we don't use it.
                //But may need to cast obj to Android.Graphics.Bitmap and call Apply(bitmap) ?
                //see path="/api/package[@name='com.pspdfkit.ui']/class[@name='PdfThumbnailBar.ConvertToDrawable']/method[@name='apply' and count(parameter)=1 and parameter[1][@type='android.graphics.Bitmap']]"
                return null;
            }
        }
    }
}

