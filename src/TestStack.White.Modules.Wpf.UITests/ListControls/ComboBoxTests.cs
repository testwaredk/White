using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;
using Tests = TestStack.White.UITests.ControlTests.ListControls;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class ComboBoxTests : Tests.ComboBoxTests
    {
        protected override void ExecuteTestRun()
        {
            SelectListControls();
            RunTest(ListItemInComboBoxWithoutTextAvailableInitially);
            RunTest(ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved);
            base.ExecuteTestRun();
        }
    }
}
