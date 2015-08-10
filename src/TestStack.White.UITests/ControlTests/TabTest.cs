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
            //FIXME: RunTest(()=>AssertChildrenCount(framework));
            RunTest(ShouldSelectTabPage);
            RunTest(ShouldSelectTabPageWithName);
            RunTest(FindControlsInsideTab);
            //FIXME: RunTest(TabWithReverseDisplayOrderTest, WindowsFramework.WinForms);
        }

        void Find()
        {
            Assert.NotNull(tab);
        }

        void AssertChildrenCount(WindowsFramework framework)
        {
            Assert.Equal(framework == WindowsFramework.Wpf ? 4 : 5, tab.TabCount);
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

        void TabWithReverseDisplayOrderTest()
        {
            MainWindow.Get<Button>("ReverseTabOrderButton").Click();
            var controlsTab = MainWindow.Get<Tab>("ControlsTab");
            controlsTab.SelectTabPage(2);
            Assert.Equal("Other Controls", controlsTab.SelectedTab.Name);
            controlsTab.SelectTabPage(1);
            Assert.Equal("Input Controls", controlsTab.SelectedTab.Name);
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