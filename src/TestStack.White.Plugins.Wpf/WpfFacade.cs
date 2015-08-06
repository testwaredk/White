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
        public WpfFacade()
        {
            // Primary controls
            ControlItems.AddWPFPrimary(typeof(UIItems.TextBox), ControlType.Edit);
            ControlItems.AddWPFPrimary(typeof(UIItems.WPFSlider), ControlType.Slider);

            ControlItems.AddWPFPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.Menu);

            ControlItems.AddWPFPrimary(typeof(UIItems.WPFLabel), ControlType.Text);
            ControlItems.AddWPFPrimary(typeof(UIItems.ListBoxItems.WPFComboBox), ControlType.ComboBox);
            ControlItems.AddWPFPrimary(typeof(UIItems.WindowStripControls.WPFStatusBar), ControlType.StatusBar);

            ControlItems.AddWPFPrimary(typeof(UIItems.Custom.CustomUIItem), ControlType.Custom);
            ControlItems.AddWPFPrimary(typeof(UIItems.Image), ControlType.Image);

            // Secondary controls

            ControlItems.AddWPFSecondary(typeof(UIItems.ListBoxItems.WPFListItem), ControlType.ListItem);

            ControlItems.AddWPFSecondary(typeof(UIItems.TreeItems.WPFTreeNode), ControlType.TreeItem);

            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Custom, "DatePicker", true, true, false, WindowsFramework.Wpf.FrameworkId(), false));

        }
    }
}
