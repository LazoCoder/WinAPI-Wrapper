using System;
using System.Drawing;

namespace WindowsAPI
{

    /// <summary>
    /// Draws directly to the desktop or a window.
    /// </summary>
    public static class Draw
    {

        /// <summary>
        /// Draws a circle on top of a specified window relative to the top left corner.
        /// </summary>
        /// <param name="color">The color of the circle.</param>
        /// <param name="x">The x coordinate of the center of the ccircle.</param>
        /// <param name="y">The y coordinate of the center of the ccircle.</param>
        /// <param name="size">The size of the circle.</param>
        /// <param name="thickness">The thickness of the circle.</param>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Circle(Color color, int x, int y, int size, int thickness, IntPtr hWnd)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            Circle(color, point.X, point.Y, size, thickness);
        }

        /// <summary>
        /// Draws a circle directly on top of the desktop.
        /// </summary>
        /// <param name="color">The color of the circle.</param>
        /// <param name="x">The x coordinate of the center of the circle.</param>
        /// <param name="y">The y coordinate of the center of the circle.</param>
        /// <param name="size">The size of the circle.</param>
        /// <param name="thickness">The thickness of the circle.</param>
        public static void Circle(Color color, int x, int y, int size, int thickness)
        {
            IntPtr desktop = WinAPI.GetDC(IntPtr.Zero);
            Pen pen = new Pen(color, thickness);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawEllipse(pen, (x - size / 2), (y - size / 2), size, size);
            }
            WinAPI.ReleaseDC(IntPtr.Zero, desktop);
        }

        /// <summary>
        ///  Draws a rectangle on top of a specified window.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="rec">The rectangle to draw.</param>
        /// <param name="thickness">The thickness of the rectangle.</param>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Rectangle(Color color, Rectangle rec, int thickness, IntPtr hWnd)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, rec.X, rec.Y);
            Rectangle(color, point.X, point.Y, rec.Width, rec.Height, thickness);
        }

        /// <summary>
        /// Draws a rectangle on top of a specified window.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="x">The x coordinate of the top left corner.</param>
        /// <param name="y">The y coordinate of the top left corner.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="thickness">The thickness of the rectangle.</param>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Rectangle(Color color, int x, int y, int width, int height, int thickness, IntPtr hWnd)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            Rectangle(color, point.X, point.Y, width, height, thickness);
        }

        /// <summary>
        /// Draws a rectangle directly on top of the desktop.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="rec">The rectangle to draw.</param>
        /// <param name="thickness">The thickness of the rectangle.</param>
        public static void Rectangle(Color color, Rectangle rec, int thickness)
        {
            Rectangle(color, rec.X, rec.Y, rec.Width, rec.Height, thickness);
        }

        /// <summary>
        /// Draws a rectangle directly on top of the desktop.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="x">The x coordinate of the top left corner.</param>
        /// <param name="y">The y coordinate of the top left corner.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="thickness">The thickness of the rectangle.</param>
        public static void Rectangle(Color color, int x, int y, int width, int height, int thickness)
        {
            IntPtr desktop = WinAPI.GetDC(IntPtr.Zero);
            Pen pen = new Pen(color, thickness);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawRectangle(pen, new Rectangle(x, y, width, height));
            }
            WinAPI.ReleaseDC(IntPtr.Zero, desktop);
        }

        /// <summary>
        /// Draws text on top of a specified window.
        /// </summary>
        /// <param name="str">The text to draw.</param>
        /// <param name="x">The x coordinate of the text.</param>
        /// <param name="y">The y coordinate of the text.</param>
        /// <param name="color">he color of the text.</param>
        /// <param name="fontSize">The size of the text font.</param>
        /// <param name="hWnd">The handle to the window.</param>
        public static void String(string str, int x, int y, Color color, int fontSize, IntPtr hWnd)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            String(str, point.X, point.Y, color, fontSize);
        }

        /// <summary>
        /// Draws text directly on top of the desktop.
        /// </summary>
        /// <param name="str">The text to draw.</param>
        /// <param name="x">The x coordinate of the text.</param>
        /// <param name="y">The y coordinate of the text.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="fontSize">The size of the font.</param>
        public static void String(string str, int x, int y, Color color, int fontSize)
        {
            IntPtr desktop = WinAPI.GetDC(IntPtr.Zero);
            Brush br = new SolidBrush(color);
            Font font = new Font("Arial", fontSize); // Lucida Console is also nice.

            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawString(str, font, br, new Point(x, y));
            }
            WinAPI.ReleaseDC(IntPtr.Zero, desktop);
        }
        
    }

}