using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Repository
{
    public class RepositoryTests : WhiteTestBase
    {
        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Requirement);
        }

        protected override void ExecuteTestRun()
        {
            
        }
    }
}