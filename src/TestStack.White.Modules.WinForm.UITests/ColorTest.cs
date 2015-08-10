using System.Collections.Generic;
using System.Drawing;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Modules;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class ColorTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(BorderColour);
            RunTest(DisplayAsImage);
        }

        void BorderColour()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            Color color = blueTextBox.BorderColor;
            Assert.Equal(100, color.R);
            Assert.Equal(100, color.G);
            Assert.Equal(100, color.B);
        }

        void DisplayAsImage()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            Bitmap bitmap = blueTextBox.VisibleImage;
            Color color = bitmap.GetPixel(3, 3);
            Assert.Equal(color.B, color.B);
            Assert.Equal(color.G, color.G);
            Assert.Equal(color.R, color.R);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Modules.WinForm.Requirements.ColorRequirement);
        }

    }
}