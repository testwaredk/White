using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;
using ListControls=TestStack.White.UITests.ControlTests.ListControls;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class ComboBoxTests : ListControls.ComboBoxTests
    {
        protected override void ExecuteTestRun()
        {
            base.ExecuteTestRun();
            RunTest(ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved);
            RunTest(ListItemInComboBoxWithoutTextAvailableInitially);
        }
    }
}
