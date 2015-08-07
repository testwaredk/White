using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Modules;

namespace TestStack.White.Modules.Silverlight
{
    [WhiteModule("Silverlight")]
    public class SilverlightFacade : ModuleFacade
    {
        public SilverlightFacade()
        {
            ControlItems.AddSilverlightPrimary(typeof(UIItems.TextBox), ControlType.Edit);
            ControlItems.AddSilverlightPrimary(typeof(UIItems.WPFSlider), ControlType.Slider);

            ControlItems.AddSilverlightPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.Menu);

            ControlItems.AddSilverlightPrimary(typeof(UIItems.ProgressBar), ControlType.ProgressBar);
            ControlItems.AddSilverlightPrimary(typeof(UIItems.Spinner), ControlType.Spinner);

            ControlItems.AddSilverlightPrimary(typeof(UIItems.WPFLabel), ControlType.Text);
            ControlItems.AddSilverlightPrimary(typeof(UIItems.ListBoxItems.SilverlightComboBox), ControlType.ComboBox);
            ControlItems.AddSilverlightPrimary(typeof(UIItems.WindowStripControls.WPFStatusBar), ControlType.StatusBar);

            ControlItems.AddSilverlightPrimary(typeof(UIItems.Image), ControlType.Image);

            ControlItems.AddSilverlightPrimary(typeof(UIItems.WindowItems.SilverlightChildWindow), ControlType.Window);

            ControlItems.Add(ControlDictionaryItem.SilverlightSecondary(typeof(UIItems.ListBoxItems.WPFListItem), ControlType.ListItem));

            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Pane, "DatePicker", true, true, false, WindowsFramework.Silverlight.FrameworkId(), false));

        }


        public override TestConfiguration GetTestConfiguration()
        {
            return new SilverlightTestConfiguration();
        }
    }
}
