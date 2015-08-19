using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;
using Tests=TestStack.White.UITests.ControlTests.ListControls;

namespace TestStack.White.Modules.WinForm.UITests.ListControls
{
    public class ComboBoxTests : Tests.ComboBoxTests
    {
        protected override void ExecuteTestRun()
        {
            // Execute all the basic tests for ComboBox
            base.ExecuteTestRun();

            // Execute the specialized test 
            RunTest(ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved);
        }
    }
}
