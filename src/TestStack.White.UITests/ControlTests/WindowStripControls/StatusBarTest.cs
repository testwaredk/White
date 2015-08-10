using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UITests.ControlTests.WindowStripControls
{
    public class StatusBarTest : WhiteTestBase
    {
        WPFStatusBar statusBar;

        protected override void ExecuteTestRun()
        {
            statusBar = MainWindow.Get<WPFStatusBar>("StatusBar");
            RunTest(StatusBar);
            RunTest(StatusBarItem);
        }

        void StatusBar()
        {
            Assert.NotEqual(null, statusBar);
        }

        void StatusBarItem()
        {
            UIItemCollection collection = statusBar.Items;
            Assert.Equal(2, collection.Count);
            var label = (Label) collection[0];
            Assert.Equal("Status Item 1", label.Text);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.WindowStripControls.StatusBarRequirement);
        }

    }
}