using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsAPI
{
    public static class Mouse
    {

        /// <summary>
        /// Hold the left mouse button down and drag it from one point to another linearly.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="point1">The initial point.</param>
        /// <param name="point2">The destination.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="lag">The delay between intervals in milliseconds.</param>
        public static void LeftDrag(IntPtr hWnd, Point point1, Point point2, int interval, int lag)
        {
            point1 = Conversion.ConvertToWindowCoordinates(hWnd, point1.X, point1.Y);
            point2 = Conversion.ConvertToWindowCoordinates(hWnd, point2.X, point2.Y);
            LeftDrag(point1, point2, interval, lag);
        }

        /// <summary>
        /// Hold the left mouse button down and drag it from one point to another linearly.
        /// </summary>
        /// <param name="point1">The initial point.</param>
        /// <param name="point2">The destination.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="lag">The delay between intervals in milliseconds.</param>
        public static void LeftDrag(Point point1, Point point2, int interval, int lag)
        {
            MouseDrag.LeftDrag(point1, point2, interval, lag);
        }

        #region Left Click

        /// <summary>
        /// Perform a left mouse button click at the current location.
        /// </summary>
        public static void LeftClick()
        {
            LeftClick(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Perform a left mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftClick(int x, int y)
        {
            LeftClick(x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a left mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftClick(IntPtr hWnd, int x, int y)
        {
            // No need to convert the coordinates here since we are calling a method that will.
            LeftClick(hWnd, x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a left mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void LeftClick(IntPtr hWnd, int x, int y, int delay)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            LeftClick(point.X, point.Y, delay);
        }

        /// <summary>
        /// Perform a left mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void LeftClick(int x, int y, int delay)
        {
            Move(x, y);
            LeftDown();
            System.Threading.Thread.Sleep(delay);
            LeftUp();
        }

        #endregion

        #region Right Click

        /// <summary>
        /// Perform a right mouse button click at the current location.
        /// </summary>
        public static void RightClick()
        {
            RightClick(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Perform a right mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void RightClick(int x, int y)
        {
            RightClick(x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a right mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void RightClick(IntPtr hWnd, int x, int y)
        {
            RightClick(hWnd, x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a right mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void RightClick(IntPtr hWnd, int x, int y, int delay)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            RightClick(point.X, point.Y, delay);
        }

        /// <summary>
        /// Perform a right mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void RightClick(int x, int y, int delay)
        {
            Mouse.Move(x, y);
            RightDown();
            System.Threading.Thread.Sleep(delay);
            RightUp();
        }

        #endregion

        #region Middle Click

        /// <summary>
        /// Perform a middle mouse button click at the current location.
        /// </summary>
        public static void MiddleClick()
        {
            MiddleClick(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Perform a middle mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleClick(int x, int y)
        {
            MiddleClick(x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a middle mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleClick(IntPtr hWnd, int x, int y)
        {
            // No need to convert the coordinates here since we are calling a method that will.
            MiddleClick(hWnd, x, y, (new Random()).Next(20, 30));
        }

        /// <summary>
        /// Perform a middle mouse button click at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void MiddleClick(IntPtr hWnd, int x, int y, int delay)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            MiddleClick(point.X, point.Y, delay);
        }

        /// <summary>
        /// Perform a middle mouse button click at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        /// <param name="delay">The delay between the mouse down and mouse up action in milliseconds.</param>
        public static void MiddleClick(int x, int y, int delay)
        {
            Move(x, y);
            MiddleDown();
            System.Threading.Thread.Sleep(delay);
            MiddleUp();
        }

        #endregion

        #region Left Down & Up

        /// <summary>
        /// Press and hold the left mouse button down.
        /// </summary>
        public static void LeftDown()
        {
            LeftDown(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Press and hold the left mouse button down at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftDown(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            LeftDown(point.X, point.Y);
        }

        /// <summary>
        /// Press and hold the left mouse button down at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftDown(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0002);
        }

        /// <summary>
        /// Lift the left mouse button up.
        /// </summary>
        public static void LeftUp()
        {
            LeftUp(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Lift the left mouse button up at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftUp(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            LeftUp(point.X, point.Y);
        }

        /// <summary>
        /// Lift the left mouse button up at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void LeftUp(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0004);
        }

        #endregion

        #region Right Down & Up

        /// <summary>
        /// Press and hold the right mouse button down.
        /// </summary>
        public static void RightDown()
        {
            RightDown(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Press and hold the right mouse button down at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void RightDown(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            RightDown(point.X, point.Y);
        }

        /// <summary>
        /// Press and hold the right mouse button down at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void RightDown(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0008);
        }

        /// <summary>
        /// Lift the right mouse button up.
        /// </summary>
        public static void RightUp()
        {
            RightUp(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Lift the right mouse button up at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void RightUp(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            RightUp(point.X, point.Y);
        }

        /// <summary>
        /// Lift the right mouse button up at a new location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void RightUp(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0010);
        }

        #endregion

        #region Middle Down & Up

        /// <summary>
        /// Press and hold the middle mouse button down.
        /// </summary>
        public static void MiddleDown()
        {
            MiddleDown(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Press and holds the middle mouse button down at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleDown(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            MiddleDown(point.X, point.Y);
        }

        /// <summary>
        /// Press and hold the middle mouse button down at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleDown(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0020);
        }

        /// <summary>
        /// Lift the middle mouse button up.
        /// </summary>
        public static void MiddleUp()
        {
            MiddleUp(Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Lift the middle mouse button up at a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleUp(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            MiddleUp(point.X, point.Y);
        }

        /// <summary>
        /// Lift the middle mouse button up at a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void MiddleUp(int x, int y)
        {
            Move(x, y);
            MouseFunction(0x0040);
        }

        #endregion

        /// <summary>
        /// Relocate the mouse to a new location relative to a window.
        /// </summary>
        /// <param name="hWnd">The handle to the window.</param>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void Move(IntPtr hWnd, int x, int y)
        {
            Point point = Conversion.ConvertToWindowCoordinates(hWnd, x, y);
            Move(point.X, point.Y);
        }

        /// <summary>
        /// Relocate the mouse to a new location.
        /// </summary>
        /// <param name="x">The x coordinate of the new location.</param>
        /// <param name="y">The y coordinate of the new location.</param>
        public static void Move(int x, int y)
        {
            Cursor.Position = new Point(x, y);
        }

        /// <summary>
        /// Perform a specific mouse action.
        /// </summary>
        /// <param name="flag">The flag for the specified action. </param>
        private static void MouseFunction(uint flag)
        {
            Structs.INPUT inputMouseDown = new Structs.INPUT();
            inputMouseDown.Type = 0; /// Input type = mouse.
            inputMouseDown.Data.Mouse.Flags = flag;
            WinAPI.SendInput(1, ref inputMouseDown, Marshal.SizeOf(new Structs.INPUT()));
        }

    }
}
