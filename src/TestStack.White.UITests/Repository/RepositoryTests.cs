using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Repository
{
    public class RepositoryTests : WhiteTestBase
    {
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
            throw new System.NotImplementedException();
        }

        protected override void ExecuteTestRun()
        {
            throw new System.NotImplementedException();
        }
    }
}