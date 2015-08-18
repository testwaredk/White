using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class CheckboxTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(SelectUnselect);
            RunTest(CheckAndUncheckCheckbox);
        }

        private void SelectUnselect()
        {
            var checkBox = MainScreen.GetCheckBox();
            Assert.False(checkBox.IsSelected);
            Assert.False(checkBox.Checked);
            checkBox.Select();
            Assert.True(checkBox.IsSelected);
            Assert.True(checkBox.Checked);
            checkBox.UnSelect();
            Assert.False(checkBox.IsSelected);
            Assert.False(checkBox.Checked);
        }

        private void CheckAndUncheckCheckbox()
        {
            var checkBox = MainScreen.GetCheckBox();
            Assert.False(checkBox.Checked);

            checkBox.Checked = true;
            Assert.True(checkBox.Checked);


            checkBox.Checked = false;
            Assert.False(checkBox.Checked);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.InputControls.CheckboxRequirement);
        }

    }
}