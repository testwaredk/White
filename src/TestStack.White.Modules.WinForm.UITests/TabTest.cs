using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using Xunit;
using TestStack.White.UITests;
using Tests = TestStack.White.UITests.ControlTests;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class TabTest : Tests.TabTest
    {
        
        protected override void ExecuteTestRun()
        {
            RunTest(TabWithReverseDisplayOrderTest);
            RunTest(FindControlsInsideTab);
        }

        void TabWithReverseDisplayOrderTest()
        {
            MainWindow.Get<Button>("ReverseTabOrderButton").Click();
            var controlsTab = MainScreen.GetControlsTab();
            controlsTab.SelectTabPage(2);
            Assert.Equal("Other Controls", controlsTab.SelectedTab.Name);
            controlsTab.SelectTabPage(1);
            Assert.Equal("Input Controls", controlsTab.SelectedTab.Name);
        }
    }
}