using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class CheckedListBoxTest : WhiteTestBase
    {
        private ListBox listBoxUnderTest;

        protected override void ExecuteTestRun()
        {
            listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            RunTest(CanCheckItem);
            RunTest(CheckSelectedItem);
            RunTest(CheckUncheckItem);
        }

        void CanCheckItem()
        {
            Assert.False(listBoxUnderTest.IsChecked("Item1"));
            listBoxUnderTest.Check("Item1");
            Assert.True(listBoxUnderTest.IsChecked("Item1"));
        }

        void CheckSelectedItem()
        {
            Assert.False(listBoxUnderTest.IsSelected("Item2"), "The item should be unselected");
            listBoxUnderTest.Select("Item2");
            Assert.True(listBoxUnderTest.IsSelected("Item2"), "The item should be selected");
            // selecting another item should unselect the current item
            listBoxUnderTest.Select("Item4");
            Assert.False(listBoxUnderTest.IsSelected("Item2"), "The item should be unselected");
        }

        public void CheckUncheckItem()
        {
            Assert.False(listBoxUnderTest.IsChecked("Item3"));
            listBoxUnderTest.Check("Item3");
            Assert.True(listBoxUnderTest.IsChecked("Item3"));

            listBoxUnderTest.UnCheck("Item3");
            Assert.False(listBoxUnderTest.IsChecked("Item3"));
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.ListControls.CheckedlistBoxRequirement);
        }
    }
}