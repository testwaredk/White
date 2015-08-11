using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Text.RegularExpressions;
using Xunit;

namespace TestStack.White.UITests.Scenarios
{
    public class GetMultipleTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            RunTest(GetMultipleButtons);
            RunTest(GetControlBasedOnIndex);
        }

        void GetControlBasedOnIndex()
        {
            using (var window = StartScenario("GetMultipleButton", "GetMultiple"))
            {
                var button = window.Get<Button>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(0));
                Assert.NotNull(button);

                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(4)));


                string pattern = "Failed to get (\\()?.*(\\))?,AutomationElementIdentifiers\\.NameProperty=Button,Index=4";

                Assert.True(Regex.IsMatch(exception.Message, pattern));
                
            }
        }

        void GetMultipleButtons()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");

            try
            {
                var buttons = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button")).OfType<Button>();
                Assert.Equal(3, buttons.Count());

                var checkboxes = window.GetMultiple(SearchCriteria.ByControlType(ControlType.CheckBox)).OfType<CheckBox>();
                Assert.Equal(3, checkboxes.Count());

                checkboxes = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Checkbox")).OfType<CheckBox>();
                Assert.Equal(3, checkboxes.Count());

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