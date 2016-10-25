using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsAPI
{
    
    /// <summary>
    /// Wrapper for the Desktop related methods in the Windows API.
    /// </summary>
    public static class Desktop
    {
        /// <summary>
        /// Get a screenshot of the Desktop.
        /// </summary>
        /// <returns>Desktop screenshot</returns>
        public static Bitmap Screenshot()
        {
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmpScreenshot);
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            g.Dispose();
            return bmpScreenshot;
        }

        /// <summary>
        /// Hide the taskbar.
        /// </summary>
        public static void HideTaskBar()
        {
            IntPtr hWndDesktop = WinAPI.GetDesktopWindow();
            IntPtr hWndStartButton = WinAPI.FindWindowEx(hWndDesktop, 0, "button", 0);
            IntPtr hWndTaskBar = WinAPI.FindWindowEx(hWndDesktop, 0, "Shell_TrayWnd", 0);
            WinAPI.SetWindowPos(hWndStartButton, 0, 0, 0, 0, 0, 0x0080);
            WinAPI.SetWindowPos(hWndTaskBar, 0, 0, 0, 0, 0, 0x0080);
        }

        /// <summary>
        /// Show the taskbar.
        /// </summary>
        public static void ShowTaskBar()
        {
            IntPtr hWndDesktop = WinAPI.GetDesktopWindow();
            IntPtr hWndStartButton = WinAPI.FindWindowEx(hWndDesktop, 0, "button", 0);
            IntPtr hWndTaskBar = WinAPI.FindWindowEx(hWndDesktop, 0, "Shell_TrayWnd", 0);
            WinAPI.SetWindowPos(hWndStartButton, 0, 0, 0, 0, 0, 0x0040);
            WinAPI.SetWindowPos(hWndTaskBar, 0, 0, 0, 0, 0, 0x0040);
        }

        /// <summary>
        /// Get the width of the Desktop in pixels.
        /// </summary>
        /// <returns>Desktop width.</returns>
        public static int GetWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }

        /// <summary>
        /// Get the height of the Desktop in pixels.
        /// </summary>
        /// <returns>Desktop height.</returns>
        public static int GetHeight()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }
    }
}