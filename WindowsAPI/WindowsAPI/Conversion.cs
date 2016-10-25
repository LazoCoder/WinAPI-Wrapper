using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsAPI
{

    /// <summary>
    /// For switching back and forth between global coordinates and coordinates relative to a window.
    /// </summary>
    class Conversion
    {
        /// <summary>
        /// Convert a global coordinate to a window coordinate.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The converted coordinate.</returns>
        public static Point ConvertToWindowCoordinates(IntPtr hWnd, int x, int y)
        {
            Structs.Rect hWndRect = new Structs.Rect();
            WinAPI.GetWindowRect(hWnd, out hWndRect);
            Point point = new Point(hWndRect.X + x, hWndRect.Y + y);
            return point;
        }

        /// <summary>
        /// Get the mouse position relative to the top left corner of a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The mouse position.</returns>
        public static Point GetCoordinateRelativeToWindow(IntPtr hWnd)
        {
            Structs.Rect hWndRect = new Structs.Rect();
            WinAPI.GetWindowRect(hWnd, out hWndRect);
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point point = new Point(x - hWndRect.X, y - hWndRect.Y);
            return point;
        }
    }
}