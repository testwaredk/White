using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.WinForm
{
    [WhitePlugin("WinForm")]
    public class WinFormFacade : PluginFacade
    {
        public override ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            items.AddWinFormPrimary(typeof(UIItems.TextBox), ControlType.Document);
            items.AddWinFormPrimary(typeof(UIItems.WinFormTextBox), ControlType.Edit);
            items.AddWinFormPrimary(typeof(UIItems.WinFormSlider), ControlType.Slider);

            items.AddWinFormPrimary(typeof(UIItems.Label), ControlType.Text);
            items.AddWinFormPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.MenuBar);
            items.AddWinFormPrimary(typeof(UIItems.WindowStripControls.StatusStrip), ControlType.StatusBar);
            items.AddWinFormPrimary(typeof(UIItems.ListBoxItems.WinFormComboBox), ControlType.ComboBox);

            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TreeItems.Win32TreeNode), ControlType.TreeItem));
            
            items.Add(new ControlDictionaryItem(typeof(UIItems.DateTimePicker), ControlType.Pane, "SysDateTimePick32", true, true, false, WindowsFramework.WinForms.FrameworkId(), false));

            return items;
        }


        public override object GetTestConfiguration()
        {
            throw new NotImplementedException();
        }

        public override Type[] GetSupportedGenericControls()
        {
            return new Type[] { 
                typeof(UIItems.TextBox),
                typeof(UIItems.WinFormTextBox),
                typeof(UIItems.Label) 
            };
        }
    }
}
