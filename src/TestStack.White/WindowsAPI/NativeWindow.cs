using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace TestStack.White.WindowsAPI
{
    public class NativeWindow
    {
        private readonly IntPtr handle;

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetBkColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetTextColor(IntPtr hdc);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private const uint WM_CLOSE = 0x0010;

        public static IEnumerable<NativeWindow> GetProcessWindows(int processId)
        {
            var result = new List<NativeWindow>();
            Func<IntPtr, bool> processWindow = hwnd =>
            {
                if (IsWindowEnabled(hwnd))
                {
                    int pid;
                    GetWindowThreadProcessId(hwnd, out pid);
                    if (pid == processId)
                        result.Add(new NativeWindow(hwnd));
                }
                return true;
            };
            EnumWindows((wnd, param) => processWindow(wnd), IntPtr.Zero);
            return result;
        }

        public NativeWindow(Point point)
        {
            handle = WindowFromPoint(new POINT((int) point.X, (int) point.Y));
        }

        public NativeWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        public virtual COLORREF BackgroundColor
        {
            get
            {
                return GetBkColor(GetDC(handle));
            }
        }

        public virtual COLORREF TextColor
        {
            get
            {
                return GetTextColor(GetDC(handle));
            }
        }
        
        public virtual void PostCloseMessage()
        {
            PostMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Positions within the rect.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public virtual bool Move(System.Windows.Rect rect)
        {
            return MoveWindow(handle, (int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, true);
        }

        //Native methods needed for highlighting UIItems
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetForegroundWindow(IntPtr windowHandle);

        /// <summary>
        ///     The MoveWindow function changes the position and dimensions of the specified window. For a top-level window, the
        ///     position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative
        ///     to the upper-left corner of the parent window's client area.
        ///     <para>
        ///     Go to https://msdn.microsoft.com/en-us/library/windows/desktop/ms633534%28v=vs.85%29.aspx for more
        ///     information
        ///     </para>
        /// </summary>
        /// <param name="hWnd">C++ ( hWnd [in]. Type: HWND )<br /> Handle to the window.</param>
        /// <param name="X">C++ ( X [in]. Type: int )<br />Specifies the new position of the left side of the window.</param>
        /// <param name="Y">C++ ( Y [in]. Type: int )<br /> Specifies the new position of the top of the window.</param>
        /// <param name="nWidth">C++ ( nWidth [in]. Type: int )<br />Specifies the new width of the window.</param>
        /// <param name="nHeight">C++ ( nHeight [in]. Type: int )<br />Specifies the new height of the window.</param>
        /// <param name="bRepaint">
        ///     C++ ( bRepaint [in]. Type: bool )<br />Specifies whether the window is to be repainted. If this
        ///     parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This
        ///     applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the
        ///     parent window uncovered as a result of moving a child window.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.<br /> If the function fails, the return value is zero.
        ///     <br />To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
