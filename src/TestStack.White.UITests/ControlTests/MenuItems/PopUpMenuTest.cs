using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    public class PopUpMenuTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectListControls();
            RunTest(ClickOnPopupMenu);
            RunTest(ClickOnNestedMenu);
        }


        void ClickOnPopupMenu()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            Assert.True(MainWindow.HasPopup());
            Menu menu = MainWindow.PopupMenu("Root2");
            menu.Click();
            Assert.Equal("Root2 Clicked", listBox.HelpText);
        }

        void ClickOnNestedMenu()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            MainWindow.PopupMenu("Root", "Level1", "Level2").Click();
            Assert.Equal("Level 2 Clicked", listBox.HelpText);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.MenuItems.PopUpMenuRequirement);
        }
    }
}