using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using Xunit;
using TestStack.White.UITests;
using Tests = TestStack.White.UITests.ControlTests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class TabTest : Tests.TabTest
    {
        Tab tab;
        protected override void ExecuteTestRun()
        {
            tab = MainScreen.GetControlsTab();
            RunTest(FindControlsInsideTab);
        }

    }
}