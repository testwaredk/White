using System.Collections.Generic;
using System.Linq;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Text.RegularExpressions;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    /// <summary>
    /// When dealing with Wpf the controls can be placed in control arrays, therefor you should be able to find multiple controls
    /// based on automationid and classname
    /// </summary>
    public class GetMultipleTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            RunTest(GetMultipleButtons);
        }

        void GetMultipleButtons()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");

            try
            {
                var buttons = window.GetMultiple(SearchCriteria.ByAutomationId("Test")).OfType<Button>();
                Assert.Equal(3, buttons.Count());

                var checkboxes = window.GetMultiple(SearchCriteria.ByAutomationId("Test2")).OfType<CheckBox>();
                Assert.Equal(3, checkboxes.Count());

                var customControls = window.GetMultiple(SearchCriteria.ByClassName("CustomItem"));

                Assert.Equal(3, customControls.Length);
            }
            finally
            {
                window.Close();
            }
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Scenarios.GetMultipleRequirement);
        }
    }
}