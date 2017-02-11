# Task-Automation

Windows API wrapper class for simulating mouse movement, clicking, window manipulation and more...

# API

The following is a summary of some of the methods that are available. There are more methods and classes than what is listed below but the purpose is to give a rough idea of what the wrapper can do. To see more details on what a particular methods does and what the parameters are, please take a look at the code itself as it is well commented.

## Mouse.cs

```c#
public static void LeftClick();
public static void RightClick();
public static void MiddleClick();

public static void LeftDown();
public static void LeftUp();

public static void RightDown();
public static void RightUp();

public static void MiddleDown();
public static void MiddleUp();

public static void Move(int x, int y);
public static void LeftDrag(Point point1, Point point2, int interval, int lag);
```

## Window.cs

```c#
public static bool DoesExist(string windowTitle);
public static IntPtr Get(string windowTitle);

public static IntPtr GetFocused();
public static void SetFocused(IntPtr hWnd);
public static bool IsFocused(IntPtr hWnd);

public static void Move(IntPtr hWnd, int x, int y);
public static void Resize(IntPtr hWnd, int width, int height);
public static void Hide(IntPtr hWnd);
public static void Show(IntPtr hWnd);

public static Rectangle GetDimensions(IntPtr hWnd);
public static Size GetSize(IntPtr hWnd);
public static Point GetLocation(IntPtr hWnd);
public static string GetTitle(IntPtr hWnd);
public static void SetTitle(IntPtr hWnd, string title);

public static void Maximize(IntPtr hWnd);
public static void Minimize(IntPtr hWnd);
public static void Normalize(IntPtr hWnd);

public static Bitmap Screenshot(IntPtr hWnd);

public static void RemoveMenu(IntPtr hWnd);
public static void Close(IntPtr hWnd);

public static void DisableCloseButton(IntPtr hWnd);
public static void DisableMaximizeButton(IntPtr hWnd);
public static void DisableMinimizeButton(IntPtr hWnd);

public static void EnableMouseTransparency(IntPtr hWnd);
public static Point ConvertToWindowCoordinates(IntPtr hWnd, int x, int y);
public static Point GetCoordinateRelativeToWindow(IntPtr hWnd);
```

## Desktop.cs
```c#
public static Bitmap Screenshot();
public static void HideTaskBar();
public static void ShowTaskBar();
public static int GetWidth();
public static int GetHeight();
```

# Usage

Compiling the code in the WindowsAPI folder produces a .dll file. Any C# code that references this .dll can utilize the wrapper.
