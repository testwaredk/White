using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.UIA
{
    public class AutomationElementXTest : WhiteTestBase
    {
        public void TestToString(string frameworkid)
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            string s = button.AutomationElement.Display();
            Assert.Equal(string.Format("AutomationId:ButtonWithTooltip, Name:Button with Tooltip, ControlType:button, FrameworkId:{0}", frameworkid), s);
        }

        protected override void ExecuteTestRun()
        {
            //FIXME: RunTest(()=>TestToString(framework.FrameworkId()));
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.UIA.AutomationElementXRequirement);
        }
    }
}