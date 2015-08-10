using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests
{
    public class NativeWindowTest : WhiteTestBase
    {
        void BackgroundColor()
        {
            var colorref = new COLORREF {R = 200};
            Console.WriteLine(colorref.R);

            var nativeWindow = new NativeWindow(new IntPtr(MainWindow.Get<TextBox>("TextBox").AutomationElement.Current.NativeWindowHandle));
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);

            //nativeWindow = new NativeWindow(MainWindow.Get<Image>("image").Bounds.Center());
            //Console.WriteLine(nativeWindow.BackgroundColor);
            //Console.WriteLine(nativeWindow.TextColor);

            nativeWindow = new NativeWindow(MainWindow.Get<Button>("ButtonWithTooltip").Bounds.ImmediateInteriorEast());
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);
        }

        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(BackgroundColor);
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.NativeWindowRequirement);
        }

    }
}