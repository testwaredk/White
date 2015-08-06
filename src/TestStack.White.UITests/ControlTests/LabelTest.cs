using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class LabelTest : WhiteTestBase
    {
        void Text()
        {
            var label = MainWindow.Get<Label>("DateTimePickerLabel");
            Assert.NotEqual(null, label.Text);
        }

        void FindTextBlock()
        {
            var label = MainWindow.Get<Label>("PasswordTextBlock");
            Assert.NotEqual(null, label);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            RunTest(Text);
            RunTest(FindTextBlock, WindowsFramework.Wpf);
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