namespace TestStack.White.Core
{
    public enum WindowsFramework
    {
        [FrameworkId("")]
        None,
        [FrameworkId("WPF")]
        Wpf,
        Win32,
        [FrameworkId("WinForm")]
        WinForms,
        Silverlight,
        [FrameworkId("SWT")]
        Swt
    }
}