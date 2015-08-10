using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ImageTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            RunTest(Get);
        }

        void Get()
        {
            SelectOtherControls();
            var image = MainWindow.Get<Image>("Image");
            Assert.NotNull(image);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.ImageRequirement);
        }

    }
}