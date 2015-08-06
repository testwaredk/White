using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Wpf
{
    [WhitePlugin("Wpf")]
    public class WpfFacade : PluginFacade
    {
        public override ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            // Primary controls
            items.AddWPFPrimary(typeof(UIItems.TextBox), ControlType.Edit);
            items.AddWPFPrimary(typeof(UIItems.WPFSlider), ControlType.Slider);

            items.AddWPFPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.Menu);

            items.AddWPFPrimary(typeof(UIItems.WPFLabel), ControlType.Text);
            items.AddWPFPrimary(typeof(UIItems.ListBoxItems.WPFComboBox), ControlType.ComboBox);
            items.AddWPFPrimary(typeof(UIItems.WindowStripControls.WPFStatusBar), ControlType.StatusBar);

            items.AddWPFPrimary(typeof(UIItems.Custom.CustomUIItem), ControlType.Custom);
            items.AddWPFPrimary(typeof(UIItems.Image), ControlType.Image);
            
            // Secondary controls
            
            items.AddWPFSecondary(typeof(UIItems.ListBoxItems.WPFListItem), ControlType.ListItem);

            items.AddWPFSecondary(typeof(UIItems.TreeItems.WPFTreeNode), ControlType.TreeItem);
            
            items.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Custom, "DatePicker", true, true, false, WindowsFramework.Wpf.FrameworkId(), false));
            



            return items;
        }

        public override Type[] GetSupportedGenericControls()
        {
            return new Type[] {
                typeof(UIItems.TextBox)
            };
        }
    }
}
