using OpenCvSharp.Aruco;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{

//spróbuj przerobić tą klasę tak aby wystarczyła jedna linijka w dowolnym formularzu, a ona będzie sama wszysko skalować
    internal class ResizeControl
    {
        
        private static Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>(); 
        public static void StoreOriginalBoundsRecursive(Control parent, Dictionary<Control, Rectangle> originalControlBounds)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                    originalControlBounds[ctrl] = ctrl.Bounds;

                if (!originalFontSizes.ContainsKey(ctrl))
                    originalFontSizes[ctrl] = ctrl.Font.Size;

                if (ctrl.Controls.Count > 0)
                    StoreOriginalBoundsRecursive(ctrl, originalControlBounds);
            }
        }
        public static void ResizeControlsRecursive(Control parent, Dictionary<Control, Rectangle> originalControlBounds, Size originalSize)
        {
            if (originalSize.Width == 0 || originalSize.Height == 0) return;

            float xRatio = (float)parent.Width / originalSize.Width;
            float yRatio = (float)parent.Height / originalSize.Height;

            foreach (Control ctrl in parent.Controls)
            {
                if (originalControlBounds.ContainsKey(ctrl))
                {
                    Rectangle orig = originalControlBounds[ctrl];
                    int newX = (int)(orig.X * xRatio);
                    int newY = (int)(orig.Y * yRatio);
                    int newWidth = (int)(orig.Width * xRatio);
                    int newHeight = (int)(orig.Height * yRatio);
                    ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if(originalFontSizes.ContainsKey(ctrl))
                {
                    float origFontSize = originalFontSizes[ctrl];
                    float newFontSize = origFontSize * Math.Min(xRatio, yRatio);
                    newFontSize=Math.Max(6,Math.Min(newFontSize, 40));
                    ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
                }
                if (ctrl.Controls.Count > 0)
                {
                    ResizeControlsRecursive(ctrl, originalControlBounds, originalSize);
                }
            }
        }
    }
}
