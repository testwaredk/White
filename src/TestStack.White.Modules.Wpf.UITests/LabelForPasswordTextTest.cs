using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class LabelForPasswordTextTest : WhiteTestBase
    {
        void FindTextBlock()
        {
            var label = MainWindow.Get<Label>("PasswordTextBlock");
            Assert.NotEqual(null, label);
        }

        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(FindTextBlock);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.LabelRequirement);
        }
    }
}