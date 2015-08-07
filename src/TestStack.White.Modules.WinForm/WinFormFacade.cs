using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Modules;

namespace TestStack.White.Modules.WinForm
{
    [WhiteModule("WinForm")]
    public class WinFormFacade : ModuleFacade
    {
        public WinFormFacade()
        {
            ControlItems.AddWinFormPrimary(typeof(UIItems.TextBox), ControlType.Document);
            ControlItems.AddWinFormPrimary(typeof(UIItems.WinFormTextBox), ControlType.Edit);
            ControlItems.AddWinFormPrimary(typeof(UIItems.WinFormSlider), ControlType.Slider);

            ControlItems.AddWinFormPrimary(typeof(UIItems.Label), ControlType.Text);
            ControlItems.AddWinFormPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.MenuBar);
            ControlItems.AddWinFormPrimary(typeof(UIItems.WindowStripControls.StatusStrip), ControlType.StatusBar);
            ControlItems.AddWinFormPrimary(typeof(UIItems.ListBoxItems.WinFormComboBox), ControlType.ComboBox);

            ControlItems.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            ControlItems.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TreeItems.Win32TreeNode), ControlType.TreeItem));

            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.DateTimePicker), ControlType.Pane, "SysDateTimePick32", true, true, false, WindowsFramework.WinForms.FrameworkId(), false));

            SupportedControls.Add(typeof(UIItems.TextBox));

        }

        public override TestConfiguration GetTestConfiguration()
        {
            return new WinformsTestConfiguration();
        }
    }
}
