using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using Xunit;
using System.Text.RegularExpressions;

namespace TestStack.White.UITests.UIA
{
    public class AutomationElementXTest : WhiteTestBase
    {
        public void TestToString()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            string s = button.AutomationElement.Display();
            string pattern = @"AutomationId:ButtonWithTooltip, Name:Button with Tooltip, ControlType:button, FrameworkId:\w+";
            Assert.True(Regex.IsMatch(s, pattern));
        }

        protected override void ExecuteTestRun()
        {
            RunTest(TestToString);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.UIA.AutomationElementXRequirement);
        }
    }
}