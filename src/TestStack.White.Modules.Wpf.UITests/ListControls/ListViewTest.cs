using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using Xunit;
using Tests = TestStack.White.UITests.ControlTests.ListControls;

namespace TestStack.White.Modules.Wpf.UITests.ListControls
{
    public class ListViewTest : Tests.ListViewTest
    {
        protected override void ExecuteTestRun()
        {
            RunTest(SelectWhenHorizontalScrollIsPresent);
        }
    }
}
