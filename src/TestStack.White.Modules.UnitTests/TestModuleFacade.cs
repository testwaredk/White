using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Core.Requirements.InputControls;

namespace TestStack.White.Modules.UnitTests
{
    [WhiteModule("TestModule")]
    public class TestModuleFacade : ModuleFacade
    {
        public TestModuleFacade()
        {
            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.TextBox), ControlType.Edit, "ThunderRT6", true, true, false, WindowsFramework.Win32.FrameworkId(), false));
            SupportedRequirements.Add(typeof(TextBoxRequirement));
        }

        public override TestConfiguration GetTestConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
