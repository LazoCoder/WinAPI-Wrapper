using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsAPI
{

    /// <summary>
    /// Windows API wrapper class for window related functions.
    /// </summary>
    public static class Window
    {

        /// <summary>
        /// Check if a particular window is open.
        /// </summary>
        /// <param name="windowTitle">The title of the window.</param>
        /// <returns>True if the window is open.</returns>
        public static bool DoesExist(string windowTitle)
        {
            IntPtr hWnd = WinAPI.FindWindow(null, windowTitle);
            return hWnd != IntPtr.Zero;
        }

        /// <summary>
        /// Find and return a handle on the first window with the specified title.
        /// </summary>
        /// <param name="windowTitle">The title of the window.</param>
        /// <returns>The handle to the window.</returns>
        public static IntPtr Get(string windowTitle)
        {
            IntPtr hWnd = WinAPI.FindWindow(null, windowTitle);
            if (hWnd == IntPtr.Zero)
                throw new Exception("Window not found.");
            return hWnd;
        }

        /// <summary>
        /// Get the handle of the window that is currently in focus.
        /// </summary>
        /// <returns>The handle to the focused Window.</returns>
        public static IntPtr GetFocused()
        {
            return WinAPI.GetForegroundWindow();
        }

        /// <summary>
        /// Put focus on a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void SetFocused(IntPtr hWnd)
        {
            WinAPI.SetForegroundWindow(hWnd);
        }

        /// <summary>
        /// Check if the specified window is focused.
        /// </summary>
        /// <param name="windowTitle">The title of the window.</param>
        /// <returns>True if the window is focused.</returns>
        public static bool IsFocused(IntPtr hWnd)
        {
            IntPtr hWndFocused = WinAPI.GetForegroundWindow();
            if (hWnd == IntPtr.Zero || hWndFocused == IntPtr.Zero) return false;
            return hWnd == hWndFocused;
        }

        /// <summary>
        /// Move the specified window by the top left corner.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new position.</param>
        /// <param name="y">The y coordinate of the new position.</param>
        public static void Move(IntPtr hWnd, int x, int y)
        {
            WinAPI.SetWindowPos(hWnd, 0, x, y, 0, 0, 0x0001);
        }

        /// <summary>
        /// Resize the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The width of the new size.</param>
        /// <param name="y">The height of the new size.</param>
        public static void Resize(IntPtr hWnd, int width, int height)
        {
            WinAPI.SetWindowPos(hWnd, 0, 0, 0, width, height, 0x002);
        }

        /// <summary>
        /// Hide the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Hide(IntPtr hWnd)
        {
            WinAPI.SetWindowPos(hWnd, 0, 0, 0, 0, 0, 0x0080);
        }

        /// <summary>
        /// Show the specified hidden window. Hidden is not the same as minimized.
        /// For minimized windows use the normalize method instead.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Show(IntPtr hWnd)
        {
            WinAPI.SetWindowPos(hWnd, 0, 0, 0, 0, 0, 0x0040);
        }

        /// <summary>
        /// Get the dimensions of the specified window. Includes location and size.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <returns>The dimensions of the window.</returns>
        public static Rectangle GetDimensions(IntPtr hWnd)
        {
            Structs.Rect hWndRect = new Structs.Rect();
            WinAPI.GetWindowRect(hWnd, out hWndRect);

            return new Rectangle(hWndRect.X, hWndRect.Y, hWndRect.Width, hWndRect.Height);
        }

        /// <summary>
        /// Get the size of the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <returns>The size of the window.</returns>
        public static Size GetSize(IntPtr hWnd)
        {
            Rectangle rec = GetDimensions(hWnd);
            Size size = new Size(rec.Width, rec.Height);
            return size;
        }

        /// <summary>
        /// Get the location of the specified window by the top left corner.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <returns>The location of the window.</returns>
        public static Point GetLocation(IntPtr hWnd)
        {
            Rectangle rec = GetDimensions(hWnd);
            Point point = new Point(rec.X, rec.Y);
            return point;
        }

        /// <summary>
        /// Get the title of the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <returns>The title of the window.</returns>
        public static string GetTitle(IntPtr hWnd)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);

            if (WinAPI.GetWindowText(hWnd, Buff, nChars) > 0)
                return Buff.ToString();

            return null;
        }

        /// <summary>
        /// Change the specified window's title.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="title">The new title.</param>
        public static void SetTitle(IntPtr hWnd, string title)
        {
            WinAPI.SetWindowText(hWnd, title);
        }

        /// <summary>
        /// Maximize the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Maximize(IntPtr hWnd)
        {
            WinAPI.ShowWindow(hWnd, 3);
        }

        /// <summary>
        /// Minimize the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Minimize(IntPtr hWnd)
        {
            WinAPI.ShowWindow(hWnd, 6);
        }

        /// <summary>
        /// Restore the specified window to its original position if it is maximized or minimized.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Normalize(IntPtr hWnd)
        {
            WinAPI.ShowWindow(hWnd, 1);
        }

        /// <summary>
        /// Get a screenshot of the specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <returns></returns>
        public static Bitmap Screenshot(IntPtr hWnd)
        {
            Normalize(hWnd);
            Structs.Rect rc;
            WinAPI.GetWindowRect(hWnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            WinAPI.PrintWindow(hWnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            // If you want to leave out the window title and borders use this:
            //bmp = ImageProcessing.Crop(bmp, new Rectangle(8, 30, bmp.Width - 16, bmp.Height - 30 - 8));

            return bmp;
        }

        /// <summary>
        /// Remove the entire menu bar of a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void RemoveMenu(IntPtr hWnd)
        {
            IntPtr hMenu = WinAPI.GetMenu(hWnd);
            int count = WinAPI.GetMenuItemCount(hMenu);
            //loop & remove
            for (int i = 0; i < count; i++)
                WinAPI.RemoveMenu(hMenu, 0, (0x400 | 0x1000));

            //force a redraw
            WinAPI.DrawMenuBar(hWnd);
        }

        /// <summary>
        /// Close a window, but prompts the option to save before closing.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void Close(IntPtr hWnd)
        {
            // fShutDown = true will kill the window instantly
            // fShutDown = false will show the message box before closing for Saving Changes
            WinAPI.EndTask(hWnd, true, true);
        }

        /// <summary>
        /// Disable a window's close button.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        public static void DisableCloseButton(IntPtr hWnd)
        {
            IntPtr hMenu;
            int n;
            hMenu = WinAPI.GetSystemMenu(hWnd, false);
            if (hMenu != IntPtr.Zero)
            {
                n = WinAPI.GetMenuItemCount(hMenu);
                if (n > 0)
                {
                    WinAPI.RemoveMenu(hMenu, (uint)(n - 1), 0x400 | 0x1000);
                    WinAPI.RemoveMenu(hMenu, (uint)(n - 2), 0x400 | 0x1000);
                    WinAPI.DrawMenuBar(hWnd);
                }
            }
        }

        /// <summary>
        /// Disable a window's maximize button.
        /// </summary>
        /// <param name="hWnd"></param>
        public static void DisableMaximizeButton(IntPtr hWnd)
        {
            var currentStyle = WinAPI.GetWindowLong(hWnd, -16);
            WinAPI.SetWindowLong(hWnd, -16, (currentStyle & ~0x10000));
        }

        /// <summary>
        /// Disable a window's minimize button.
        /// </summary>
        /// <param name="hWnd"></param>
        public static void DisableMinimizeButton(IntPtr hWnd)
        {
            var currentStyle = WinAPI.GetWindowLong(hWnd, -16);
            WinAPI.SetWindowLong(hWnd, -16, (currentStyle & ~0x20000));
        }

        /// <summary>
        /// Allow a user to click through a window.
        /// </summary>
        /// <param name="Handle">The handle to the window.</param>
        public static void EnableMouseTransparency(IntPtr hWnd)
        {
            WinAPI.SetWindowLong(hWnd, -20, Convert.ToInt32(WinAPI.GetWindowLong(hWnd, -20) | 0x00080000 | 0x00000020L));
        }

        /// <summary>
        /// Convert a global coordinate to a window coordinate.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The coordinate.</returns>
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