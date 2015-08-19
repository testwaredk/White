using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.Core;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class ListBoxWithScrollBarTest : WhiteTestBase
    {
        protected ListBox ListBoxUnderTest { get; set; }

        protected override void ExecuteTestRun()
        {
            ListBoxUnderTest = MainScreen.GetListBoxWithVScrollBar();
            RunTest(SelectItemNotVisibleBecauseOfScrollBar);
            RunTest(SelectItemByIndex);
        }

        void SelectItemNotVisibleBecauseOfScrollBar()
        {
            ListBoxUnderTest.Select("0");
            ListItem selectedItem = ListBoxUnderTest.SelectedItem;
            Assert.Equal("0", selectedItem.Text);
        }

        void SelectItemByIndex()
        {
            ListBoxUnderTest.Select(8);
            ListItem selectedItem = ListBoxUnderTest.SelectedItem;
            Assert.Equal("9", selectedItem.Text);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.ListControls.ListBoxRequirement);
        }

    }
}