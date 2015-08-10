using System.Collections.Generic;
using System.Windows;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class HyperlinkTest : WhiteTestBase
    {
        public void Click()
        {
            var hyperlink = MainWindow.Get<Hyperlink>("LinkLabel");
            hyperlink.Click(10, 10);
            Assert.Equal("Hyperlink Clicked", hyperlink.HelpText);
        }

        public void ClickablePoint()
        {
            var hyperlink = MainWindow.Get<Hyperlink>("LinkLabel");
            hyperlink.Focus();
            var clickablePoint = hyperlink.ClickablePoint;

            Assert.NotEqual(new Point(0, 0), clickablePoint);
            hyperlink.Click();
            Assert.Equal("Hyperlink Clicked", hyperlink.HelpText);
        }

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
            RunTest(Click);
            //FIXME: RunTest(ClickablePoint, WindowsFramework.Wpf); //TODO Figure out why this fails for Windows Forms
            //FIXME: RunTest(ClickHyperlinkFromLabel, WindowsFramework.Wpf);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.HyperlinkRequirement);
        }

    }
}