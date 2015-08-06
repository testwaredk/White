﻿using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class EditableComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void ExecuteTestRun(WindowsFramework framework)
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

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }

        protected override IEnumerable<System.Type> CoveredControls()
        {
            throw new System.NotImplementedException();
        }

        protected override void ExecuteTestRun()
        {
            throw new System.NotImplementedException();
        }
    }
}