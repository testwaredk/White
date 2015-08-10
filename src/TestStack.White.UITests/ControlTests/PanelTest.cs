using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class PanelTest : WhiteTestBase
    {
        public void Text()
        {
            var panel = MainWindow.Get<Panel>("PanelWithText");
            Assert.Equal("PanelText", panel.Text);
        }

        protected override void ExecuteTestRun()
        {
            SelectOtherControls();
            RunTest(Text);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.PanelRequirment);
        }
    }
}