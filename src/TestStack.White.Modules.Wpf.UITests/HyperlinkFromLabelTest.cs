using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class HyperlinkFromLabelTest : WhiteTestBase
    {
        public void ClickHyperlinkFromLabel()
        {
            var labelContainingHyperlink = MainWindow.Get<WPFLabel>("LinkLabelContainer");
            var hyperlink = labelContainingHyperlink.Hyperlink("Link Text");
            hyperlink.Click();
            Assert.Equal("Hyperlink Clicked", hyperlink.HelpText);
        }

        protected override void ExecuteTestRun()
        {
            SelectOtherControls();
            RunTest(ClickHyperlinkFromLabel);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.HyperlinkRequirement);
        }

    }
}