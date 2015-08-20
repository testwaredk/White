using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UITests.ControlTests.WindowStripControls
{
    public class StatusBarTest : WhiteTestBase
    {
        StatusBar statusBar;

        protected override void ExecuteTestRun()
        {
            statusBar = MainScreen.GetStatusBar();
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
            Assert.Equal(MainScreen.GetExpectedStatusBarText(), label.Text);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.WindowStripControls.StatusBarRequirement);
        }

    }
}