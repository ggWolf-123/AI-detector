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
        private static Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        /// <summary>
        ///  Function to store original bounds of controls in a dictionary for later resizing. It also stores original font sizes to maintain readability when resizing.
        /// </summary>
        /// <param name="parent">The parent control whose child controls' bounds and font sizes are to be stored.</param>
        /// <param name="originalControlBounds">A dictionary to store the original bounds of the controls.</param>
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
        /// <summary>
        ///     Function to resize controls based on the original bounds stored in the dictionary. It calculates the new position and size of each control based on the ratio of the current size of the parent control to the original size. It also adjusts font sizes to maintain readability.
        /// </summary>
        /// <param name="parent">The parent control whose child controls are to be resized.</param>
        /// <param name="originalControlBounds">A dictionary containing the original bounds of the controls.</param>
        /// <param name="originalSize">The original size of the parent control.</param>
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
