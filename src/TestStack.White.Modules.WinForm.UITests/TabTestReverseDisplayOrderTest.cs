using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class TabTest : WhiteTestBase
    {
        Tab tab;

        protected override void ExecuteTestRun()
        {
            tab = MainWindow.Get<Tab>("ControlsTab");
            RunTest(TabWithReverseDisplayOrderTest);
        }

        void TabWithReverseDisplayOrderTest()
        {
            MainWindow.Get<Button>("ReverseTabOrderButton").Click();
            var controlsTab = MainWindow.Get<Tab>("ControlsTab");
            controlsTab.SelectTabPage(2);
            Assert.Equal("Other Controls", controlsTab.SelectedTab.Name);
            controlsTab.SelectTabPage(1);
            Assert.Equal("Input Controls", controlsTab.SelectedTab.Name);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.TabRequirement);
        }
    }
}