using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    public class MenuTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            RunTest(FindMenuBar);
            RunTest(Click);
            RunTest(FindMultiLevelMenuItem);
        }

        public void FindMenuBar()
        {
            Assert.NotNull(MainWindow.MenuBar);
            Assert.NotNull(MainWindow.MenuBar.MenuItem("File"));
            Assert.Equal(1, MainWindow.MenuBars.Count);
        }

        public void Click()
        {
            Menu menu = MainWindow.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            Assert.Equal(MainScreen.GetHelpText(), "Click Me Clicked");
        }

        public void FindMultiLevelMenuItem()
        {
            MenuBar menuBar = MainWindow.MenuBar;
            Menu menu = menuBar.MenuItem("Multi-Level Menu");
            Assert.NotNull(menu.SubMenu(SearchCriteria.ByText("Level 1"))
                .SubMenu("Level 2")
                .SubMenu("Level 3"));
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.MenuItems.MenuRequirement);
        }

    }
}