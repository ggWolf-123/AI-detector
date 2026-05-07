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
        private static Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private static Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private static System.Drawing.Size originalSize;

        /// <summary>
        ///     Function to initialize the resizing of controls. It stores the original size of the parent control and the original bounds and font sizes of all child controls in dictionaries. This allows the application to resize controls proportionally when the form is resized, maintaining a consistent layout regardless of the form's size.
        /// </summary>
        /// <param name="parent">The parent control whose child controls are to be initialized for resizing.</param>
        public static void Initialize(Control parent)
        {
            originalSize = parent.Size;
            StoreOriginalBoundsRecursive(parent);
        }
        /// <summary>
        ///  Function to store the original bounds and font sizes of controls in a dictionary. It recursively traverses all child controls of the parent control and stores their bounds and font sizes in the originalControlBounds and originalFontSizes dictionaries, respectively. This allows the application to resize controls proportionally when the form is resized, maintaining a consistent layout regardless of the form's size.
        /// </summary>
        /// <param name="parent">The parent control whose child controls' bounds and font sizes are to be stored.</param>
        private static void StoreOriginalBoundsRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                    originalControlBounds[ctrl] = ctrl.Bounds;

                if (!originalFontSizes.ContainsKey(ctrl))
                    originalFontSizes[ctrl] = ctrl.Font.Size;

                if (ctrl.Controls.Count > 0)
                    StoreOriginalBoundsRecursive(ctrl);
            }
        }
        /// <summary>
        ///     Function to resize controls based on the original size and bounds stored in the dictionaries. It calculates the ratio of the current size of the parent control to the original size and resizes each control accordingly. It also resizes the font size of each control based on the smaller ratio of width or height to maintain readability. The function is called recursively for all child controls to ensure that the entire layout is resized proportionally when the form is resized.
        /// </summary>
        /// <param name="parent">The parent control whose child controls are to be resized.</param>
        public static void ResizeControlsRecursive(Control parent)
        {
            if (originalSize.Width == 0 || originalSize.Height == 0) return;

            float xRatio = (float)parent.Width / originalSize.Width;
            float yRatio = (float)parent.Height / originalSize.Height;

            foreach (Control ctrl in parent.Controls)
            {
                if (originalControlBounds.TryGetValue(ctrl, out Rectangle orig))
                {
                    int newX = (int)(orig.X * xRatio);
                    int newY = (int)(orig.Y * yRatio);
                    int newWidth = (int)(orig.Width * xRatio);
                    int newHeight = (int)(orig.Height * yRatio);
                    ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if(originalFontSizes.TryGetValue(ctrl, out float origFontSize))
                {
                    float newFontSize = origFontSize * Math.Min(xRatio, yRatio);
                    newFontSize=Math.Max(6,Math.Min(newFontSize, 40));
                    ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
                }
                if (ctrl.Controls.Count > 0)
                {
                    ResizeControlsRecursive(ctrl);
                }
            }
        }
    }
}
