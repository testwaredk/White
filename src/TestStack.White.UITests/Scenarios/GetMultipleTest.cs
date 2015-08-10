using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Xunit;

namespace TestStack.White.UITests.Scenarios
{
    public class GetMultipleTest : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            RunTest(() => GetMultipleButtons());
            RunTest(() => GetControlBasedOnIndex());
        }

        void GetControlBasedOnIndex()
        {
            using (var window = StartScenario("GetMultipleButton", "GetMultiple"))
            {
                var button = window.Get<Button>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(0));
                Assert.NotNull(button);

                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(4)));
                
                //FIXME: this assertion should be placed in the Wpf Module
                /*
                var expected = framework == WindowsFramework.Wpf?
                    "Failed to get ControlType=edit,AutomationElementIdentifiers.NameProperty=Button,Index=4":
                    "Failed to get (ControlType=edit or ControlType=document),AutomationElementIdentifiers.NameProperty=Button,Index=4";
                Assert.Equal(expected, exception.Message);
                 */
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

                //FIXME: these assertions should be placed in the Wpf Module
                /*
                if (framework == WindowsFramework.Wpf)
                {
                    buttons = window.GetMultiple(SearchCriteria.ByAutomationId("Test")).OfType<Button>();
                    Assert.Equal(3, buttons.Count());
                }
                */
                var checkboxes = window.GetMultiple(SearchCriteria.ByControlType(ControlType.CheckBox)).OfType<CheckBox>();
                Assert.Equal(3, checkboxes.Count());

                checkboxes = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Checkbox")).OfType<CheckBox>();
                Assert.Equal(3, checkboxes.Count());

                //FIXME: these assertions should be placed in the Wpf Module
                /*
                if (framework == WindowsFramework.Wpf)
                {
                    checkboxes = window.GetMultiple(SearchCriteria.ByAutomationId("Test2")).OfType<CheckBox>();
                    Assert.Equal(3, checkboxes.Count());
                }
                */

                /*
                if (framework == WindowsFramework.Wpf)
                {
                    var customControls = window.GetMultiple(SearchCriteria.ByClassName("CustomItem"));

                    Assert.Equal(3, customControls.Length);
                }
                */
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