using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class EditableComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void ExecuteTestRun()
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("EditableComboBox");
            RunTest(SetValueInEditableComboBox);
            RunTest(SelectItemInEditableComboBox);
        }

        private void SetValueInEditableComboBox()
        {
            ComboBoxUnderTest.EditableText = "foobar";
            Assert.Equal("foobar", ComboBoxUnderTest.EditableText);
        }

        private void SelectItemInEditableComboBox()
        {
            ComboBoxUnderTest.Select("Test3");
            Assert.Equal("Test3", ComboBoxUnderTest.EditableText);
            Assert.Equal("Test3", ComboBoxUnderTest.SelectedItemText);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.ListControls.EditableCombpBoxRequirement);
        }

    }
}