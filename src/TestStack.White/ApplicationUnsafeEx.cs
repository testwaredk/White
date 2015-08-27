using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TestStack.White
{
    public static class ApplicationUnsafeEx
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetForegroundWindow(IntPtr windowHandle);
        /// <summary>
        /// Sets the applications window handle as foreground
        /// </summary>
        /// <returns></returns>
        public static bool SetForeground(this Application application)
        {
            try
            {
                return SetForegroundWindow(application.Process.MainWindowHandle);
            }
            catch
            {
                return false;
            }
        }
    }
}
