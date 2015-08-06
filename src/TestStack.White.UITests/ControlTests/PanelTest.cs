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

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            RunTest(Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }

        protected override IEnumerable<System.Type> CoveredControls()
        {
            throw new System.NotImplementedException();
        }

        protected override void ExecuteTestRun()
        {
            throw new System.NotImplementedException();
        }
    }
}