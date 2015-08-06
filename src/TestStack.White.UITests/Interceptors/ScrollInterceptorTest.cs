using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.Interceptors
{
    public class ScrollInterceptorTest : WhiteTestBase
    {
        public void GetItemOutsideWindowButWithoutScroll()
        {
            using (var window = StartScenario("OpenFormWithoutScrollAndItemOutside", "FormWithoutScrollAndItemOutside"))
            {
                var listBox = window.Get<ListBox>("ListBox");
                Assert.NotEqual(null, listBox);
                Assert.Equal(0, listBox.Items.Count);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            GetItemOutsideWindowButWithoutScroll();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
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