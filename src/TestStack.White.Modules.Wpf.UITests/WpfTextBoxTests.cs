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

namespace TestStack.White.Modules.Wpf.UITests
{
    public class WpfTextBoxTests : TextBoxTest
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(base.HelpTextShouldContainTextChanged);
            RunTest(base.CopyTest);
        }
    }
}
