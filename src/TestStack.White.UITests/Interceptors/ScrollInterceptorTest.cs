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

        protected override void ExecuteTestRun()
        {
            GetItemOutsideWindowButWithoutScroll();
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Interceptors.ScollInterceptorsRequirement);
        }

    }
}