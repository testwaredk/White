using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Core;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests;
using Xunit;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class WindowForWinFormTests : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectOtherControls();
            RunTest(WindowWithoutTitleBarWinForm);
            RunTest(WindowWithAmerstandWinForm);
            RunTest(HandlesInvisibleControlsWinforms);
        }


        void WindowWithoutTitleBarWinForm()
        {
            using (var window = StartScenario("OpenWindowWithNoTitleBar", "WindowWithNoTitleBar"))
            {
                Assert.NotNull(window);
            }
        }

        void WindowWithAmerstandWinForm()
        {
            using (var window = StartScenario("OpenWindowWithAmperstand", "WindowWithAmperstand&1"))
                Assert.NotNull(window);
        }


        void HandlesInvisibleControlsWinforms()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>("HiddenTextBox"));
                Assert.Equal("Failed to get (ControlType=document or ControlType=edit),AutomationId=HiddenTextBox",
                    exception.Message);
            }

            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.True(textBox.Visible);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.WindowRequirement);
        }
    }
}