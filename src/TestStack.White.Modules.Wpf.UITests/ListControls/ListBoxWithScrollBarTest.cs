using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.Core;
using Xunit;
using TestStack.White.Modules.Wpf.Screens;
using Tests = TestStack.White.UITests.ControlTests.ListControls;

namespace TestStack.White.Modules.Wpf.UITests.ListControls
{
    public class ListBoxWithScrollBarTest : Tests.ListBoxWithScrollBarTest
    {
        protected override void ExecuteTestRun()
        {
            base.ExecuteTestRun();
            RunTest(ListItemContainingTextbox, WindowsFramework.Wpf);
            RunTest(FindNonExistentObject, WindowsFramework.Wpf);
            RunTest(ListBoxWithScrollBarWithChangingItems, WindowsFramework.Wpf);

        }

        void ListItemContainingTextbox()
        {
            var ListBoxWpf = (MainScreen as Screens.WpfMainScreen).GetListBoxWpf();
            var listItem = (WPFListItem)ListBoxWpf.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var textBox = listItem.Get<TextBox>(SearchCriteria.All);
            Assert.NotNull(textBox);
            textBox.Text = "Hrishikesh M";
            Assert.Equal("Hrishikesh M", listItem.Text);
        }

        void FindNonExistentObject()
        {
            var listBox = (MainScreen as Screens.WpfMainScreen).GetListBoxWpf();
            WPFListItem listItem = (WPFListItem)listBox.Items.Find(item => item.Text.StartsWith("Hrishikesh"));
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => listItem.Get<TextBox>(SearchCriteria.ByAutomationId("foo")));
                Assert.Equal("Failed to get ControlType=edit,AutomationId=foo", exception.Message);
            }
        }

        void ListBoxWithScrollBarWithChangingItems()
        {
            var listBox = (MainScreen as Screens.WpfMainScreen).GetListBoxWpf();
            listBox.Select("Spielberg");
            listBox.Select("Whedon");
            (MainScreen as Screens.WpfMainScreen).GetChangeListItems().Click();
            listBox.Select("Jackson");
            listBox.Select("Allen");
        }
    }
}
