using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Core;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class WindowHandleInvisibleControlsTests : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectOtherControls();
            RunTest(HandlesInvisibleControlsWpf);
        }

        void HandlesInvisibleControlsWpf()
        {
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.False(textBox.Visible);
            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            Assert.True(textBox.Visible);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.WindowRequirement);
        }
    }
}