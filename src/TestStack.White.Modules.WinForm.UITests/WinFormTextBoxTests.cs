using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;
using TestStack.White.UITests.ControlTests.InputControls;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class WinFormTextBoxTests : TextBoxTest
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(SuggestionList);
            RunTest(SelectFromSuggestionList);
            RunTest(base.HelpTextShouldContainTextChanged);
            RunTest(base.CopyTest);
        }

        void SuggestionList()
        {
            var textBox = (WinFormTextBox)MainScreen.GetTextBox();
            textBox.Text = "h";
            SuggestionList suggestionList = textBox.SuggestionList;
            Assert.Equal(2, suggestionList.Items.Count);
            Assert.Equal("hello", suggestionList.Items[0]);
            Assert.Equal("hi", suggestionList.Items[1]);
        }

        void SelectFromSuggestionList()
        {
            var textBox = (WinFormTextBox)MainScreen.GetTextBox();
            textBox.Enter("h");
            SuggestionList suggestionList = textBox.SuggestionList;
            suggestionList.Select("hello");
            Assert.Equal("hello", textBox.Text);
        }
    }
}
