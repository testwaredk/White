using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class TooltipTests : WhiteTestBase
    {
        private void CanGetTooltip()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Assert.Equal("I have a tooltip", MainWindow.GetToolTipOn(button).Text);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.TooltipRequirement);
        }

        protected override void ExecuteTestRun()
        {
            RunTest(CanGetTooltip);
        }
    }
}