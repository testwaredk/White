using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.AutomationElementSearch
{
    public class RawAutomationElementFinderTest : WhiteTestBase, IDisposable
    {
        readonly IDisposable cleanup;

        public RawAutomationElementFinderTest()
        {
            cleanup = CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c =>
            {
                c.RawElementBasedSearch = true;
                c.MaxElementSearchDepth = 2;
            });
        }

        protected override void ExecuteTestRun()
        {
            RunTest(Descendant);
        }

        public void Descendant()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var finder = new RawAutomationElementFinder(listView.AutomationElement);
                Assert.NotEqual(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.HeaderItem).OfName("Key")));
                Assert.Equal(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.Header).OfName("Key")));
            }
        }

        public void Dispose()
        {
            cleanup.Dispose();
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.AutomationElementSearch.RawAutomationElementFinderTest);
        }

    }
}