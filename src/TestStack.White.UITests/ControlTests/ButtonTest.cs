using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ButtonTest : WhiteTestBase
    {
        public void Click()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.Click();
            
            Assert.Equal(button.Text, "Button Clicked with Mouse");
        }

        public void ThrowsWhenNotFound()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.FindWindowTimeout = 500))
            {
                var exception = Assert.Throws<AutomationException>(()=>MainWindow.Get<Button>(SearchCriteria.ByAutomationId("foo")));
                Assert.Equal("Failed to get (ControlType=button or ControlType=check box),AutomationId=foo", exception.Message);
            }
        }

        public void RaiseClickEvent()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.RaiseClickEvent();
            Assert.Equal(button.Text, "Clicked");
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }

        protected override IEnumerable<System.Type> CoveredControls()
        {
            yield return typeof(Button);
        }

        protected override void ExecuteTestRun()
        {
            RunTest(RaiseClickEvent);
            RunTest(Click);
            RunTest(ThrowsWhenNotFound);
        }
    }
}