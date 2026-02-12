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
    internal class ResizeControl
    {
        public static void StoreOriginalBoundsRecursive(Control parent, Dictionary<Control, Rectangle> originalControlBounds)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                    originalControlBounds[ctrl] = ctrl.Bounds;

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
                if (ctrl.Controls.Count > 0)
                {
                    ResizeControlsRecursive(ctrl, originalControlBounds, originalSize);
                }
            }
        }
    }
}
