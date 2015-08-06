using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class GroupBoxTest : WhiteTestBase
    {
        void Find()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            Assert.NotNull(groupBox);
        }

        void GetItem()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            var button = groupBox.Get<Button>("ButtonWithTooltip");
            Assert.NotNull(button);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Find);
            RunTest(GetItem);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
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