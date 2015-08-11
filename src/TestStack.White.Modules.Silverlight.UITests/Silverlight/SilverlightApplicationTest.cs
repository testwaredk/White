using System.Collections.Generic;
using Xunit;
using TestStack.White.Core;
using TestStack.White.WebBrowser;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Silverlight.UITests
{
    public class SilverlightApplicationTest : WhiteTestBase
    {
        public void FindSilverlightDocument()
        {
            var document = MainWindow;
            Assert.NotEqual(null, document);
        }

        protected override void ExecuteTestRun()
        {
            RunTest(FindSilverlightDocument);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.WebBrowserWindowRequirement);
        }
    }
}