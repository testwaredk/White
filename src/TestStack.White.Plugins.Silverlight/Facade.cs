using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Silverlight
{
    [WhitePlugin("Silverlight")]
    public class Facade : IPluginFacade
    {
        public ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            items.AddSilverlightPrimary(typeof(UIItems.TextBox), ControlType.Edit);
            items.AddSilverlightPrimary(typeof(UIItems.WPFSlider), ControlType.Slider);

            items.AddSilverlightPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.Menu);

            items.AddSilverlightPrimary(typeof(UIItems.ProgressBar), ControlType.ProgressBar);
            items.AddSilverlightPrimary(typeof(UIItems.Spinner), ControlType.Spinner);

            items.AddSilverlightPrimary(typeof(UIItems.WPFLabel), ControlType.Text);
            items.AddSilverlightPrimary(typeof(UIItems.ListBoxItems.SilverlightComboBox), ControlType.ComboBox);
            items.AddSilverlightPrimary(typeof(UIItems.WindowStripControls.WPFStatusBar), ControlType.StatusBar);

            items.AddSilverlightPrimary(typeof(UIItems.Image), ControlType.Image);

            items.AddSilverlightPrimary(typeof(UIItems.WindowItems.SilverlightChildWindow), ControlType.Window);

            items.Add(ControlDictionaryItem.SilverlightSecondary(typeof(UIItems.ListBoxItems.WPFListItem), ControlType.ListItem));

            items.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Pane, "DatePicker", true, true, false, WindowsFramework.Silverlight.FrameworkId(), false));
            

            return items;
        }


        public List<Type> GetEditableControls()
        {
            List<Type> editableControls = new List<Type>();
            return editableControls;
        }


        public object GetTestConfiguration()
        {
            throw new NotImplementedException();
        }

        public bool Supports(Type t)
        {
            throw new NotImplementedException();
        }
    }
}
