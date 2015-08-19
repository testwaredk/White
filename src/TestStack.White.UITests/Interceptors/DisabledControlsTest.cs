using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;
using Xunit;

namespace TestStack.White.UITests.Interceptors
{
    //TODO: Check all operations and write tests possible on all disabled uiitem
    public class DisabledControlsTest : WhiteTestBase
    {
        protected Button BottonDisableControls { get { return MainScreen.GetButtonDisableControls(); } }
        

        protected override void ExecuteTestRun()
        {
            RunTest(DoNotAllowActionOnDisabledControls);
            RunTest(AllowActionsPossibleOnDisabledInputControls);
            RunTest(AllowActionsPossibleOnDisabledListControls);
        }

        void DoNotAllowActionOnDisabledControls()
        {
            SelectInputControls();
            var textBox = MainScreen.GetTextBox();
            BottonDisableControls.Click();
            Retry.For(() => !textBox.Enabled, TimeSpan.FromSeconds(2));
            Assert.Throws<ElementNotEnabledException>(() => { textBox.Text = "blah"; });
            BottonDisableControls.Click();
        }

        void AllowActionsPossibleOnDisabledInputControls()
        {
            SelectInputControls();
            var textBox = MainScreen.GetTextBox();

            // Set Values
            textBox.Text = "blah";

            BottonDisableControls.Click();

            // Assert we can still read the values
            Assert.Equal("blah", textBox.Text);
            BottonDisableControls.Click();
        }

        void AllowActionsPossibleOnDisabledListControls()
        {
            SelectListControls();
            var comboBox = MainScreen.GetComboBox();

            // Set Values
            comboBox.Select("Test2");

            BottonDisableControls.Click();

            // Assert we can still read the values
            Assert.Equal("Test2", comboBox.SelectedItem.Text);
            BottonDisableControls.Click();
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Interceptors.DisabledControlsRequirement);
        }

    }
}