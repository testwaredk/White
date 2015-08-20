using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;
using Tests = TestStack.White.UITests.ControlTests.MenuItems;

namespace TestStack.White.Modules.Wpf.UITests.MenuItems
{
    public class MenuTest : Tests.MenuTest
    {
        protected override void ExecuteTestRun()
        {
            RunTest(FindByAutomationId);
        }

        public void FindByAutomationId()
        {
            MenuBar menuBar = MainWindow.MenuBar;
            Assert.NotNull(menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")));
        }


    }
}
