using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class PopUpMenuItemsCountTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectListControls();
            RunTest(GetPopupMenuItems);
        }

        void GetPopupMenuItems()
        {
            MainWindow.Get<ListBox>("ListBoxWithVScrollBar").RightClick();
            var popup = MainWindow.Popup;
            int numberOfItems = 2;
            Assert.Equal(numberOfItems, popup.Items.Count);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.MenuItems.PopUpMenuRequirement);
        }
    }
}