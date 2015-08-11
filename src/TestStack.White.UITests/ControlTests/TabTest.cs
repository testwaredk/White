using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class TabTest : WhiteTestBase
    {
        Tab tab;

        protected override void ExecuteTestRun()
        {
            tab = MainWindow.Get<Tab>("ControlsTab");

            RunTest(Find);
            RunTest(AssertChildrenCount);
            RunTest(ShouldSelectTabPage);
            RunTest(ShouldSelectTabPageWithName);
            RunTest(FindControlsInsideTab);
        }

        void Find()
        {
            Assert.NotNull(tab);
        }

        void AssertChildrenCount()
        {
            Assert.Equal(5, tab.TabCount);
        }

        void ShouldSelectTabPage()
        {
            tab.SelectTabPage(0);
            Assert.Equal("List Controls", tab.SelectedTab.Name);
            tab.SelectTabPage(1);
            Assert.Equal("Input Controls", tab.SelectedTab.Name);
        }

        void ShouldSelectTabPageWithName()
        {
            tab.SelectTabPage("List Controls");
            Assert.Equal("List Controls", tab.SelectedTab.Name);
            tab.SelectTabPage("Input Controls");
            Assert.Equal("Input Controls", tab.SelectedTab.Name);
        }

        void FindControlsInsideTab()
        {
            tab.SelectTabPage(1);
            ITabPage selectedTab = tab.SelectedTab;
            Assert.NotNull(selectedTab);
            Assert.NotNull(selectedTab.Get<TextBox>("TextBox"));
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.TabRequirement);
        }
    }
}