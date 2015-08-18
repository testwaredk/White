using System;
using System.Collections.Generic;
using System.Windows;
using TestStack.White.Core;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class TextBoxTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(IsReadOnly);
            RunTest(EnterText);
            RunTest(EnterBulkText);
        }

        /// <summary>
        /// Only for Winform and Wpf
        /// </summary>
        public void HelpTextShouldContainTextChanged()
        {
            var textBox = MainScreen.GetTextBox();
            textBox.Text = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
            Assert.Equal("Text Changed", textBox.HelpText);
        }

        void EnterText()
        {
            var textBox = MainScreen.GetTextBox();
            textBox.Text = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
            textBox.Text = "";
            Assert.Equal("", textBox.Text);
            textBox.Text = "againSomethingElse";
            Assert.Equal("againSomethingElse", textBox.Text);
        }

        void EnterBulkText()
        {
            var textBox = MainScreen.GetTextBox();
            textBox.BulkText = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
        }

        /// <summary>
        /// Only for Winform and Wpf
        /// </summary>
        public void CopyTest()
        {
            var textBox = MainScreen.GetTextBox();
            AttachedKeyboard attachedKeyboard = MainWindow.Keyboard;
            textBox.Text = "userText";
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);


            //check the text is the same as that on the clipboard
            Retry.For(() =>
            {
                string clipbrdText = Clipboard.GetText();
                Assert.Equal(textBox.Text, clipbrdText);
            }, TimeSpan.FromSeconds(5));
        }

        void IsReadOnly()
        {
            var textBox = MainScreen.GetTextBox();
            Assert.Equal(false, textBox.IsReadOnly);
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
 	        yield return typeof(Core.Requirements.InputControls.TextBoxRequirement);
        }
    }
}