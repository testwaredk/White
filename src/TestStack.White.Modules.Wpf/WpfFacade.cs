using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Modules;

namespace TestStack.White.Modules.Wpf
{
    [WhiteModule("Wpf")]
    public class WpfFacade : ModuleFacade
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

            ControlItems.Add(ControlDictionaryItem.WPFSecondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            
            ControlItems.AddWPFSecondary(typeof(UIItems.TreeItems.WPFTreeNode), ControlType.TreeItem);

            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Custom, "DatePicker", true, true, false, WindowsFramework.Wpf.FrameworkId(), false));

            SupportedRequirements.AddRange(new List<Type>() 
            {
                typeof(Core.Requirements.InputControls.RadioButtonRequirement),
                typeof(Core.Requirements.InputControls.CheckboxRequirement),
                typeof(Core.Requirements.InputControls.DateTimePickerRequirement),
                typeof(Core.Requirements.InputControls.PasswordTextBox),
                typeof(Core.Requirements.InputControls.RadioButtonRequirement),
                typeof(Core.Requirements.InputControls.TristateItemReqiurement),
                typeof(Core.Requirements.InputControls.TextBoxRequirement),

                typeof(Core.Requirements.ListControls.CheckedlistBoxRequirement),
                typeof(Core.Requirements.ListControls.ComboBoxRequirement),
                typeof(Core.Requirements.ListControls.DataBoundComboBoxRequirement),
                typeof(Core.Requirements.ListControls.EditableComboBoxRequirement),
                typeof(Core.Requirements.ListControls.ListBoxRequirement),
                typeof(Core.Requirements.ListControls.ListViewRequirement),

                typeof(Core.Requirements.MenuItems.MenuRequirement),
                typeof(Core.Requirements.MenuItems.PopUpMenuRequirement),

                typeof(Core.Requirements.Splitters.HorizontalThumbRequirement),
                typeof(Core.Requirements.Splitters.VerticalThumbRequirement),

                typeof(Core.Requirements.TreeItems.TreeNodeRequirement),
                typeof(Core.Requirements.TreeItems.TreeRequirement),

                typeof(Core.Requirements.WindowStripControls.StatusBarRequirement),

                typeof(Core.Requirements.Standard.ButtonRequirement),
                typeof(Core.Requirements.Standard.CustomUIItemRequirement),
                typeof(Core.Requirements.Standard.GroupBoxRequirement),
                typeof(Core.Requirements.Standard.HotKeyRequirement),
                typeof(Core.Requirements.Standard.HScrollBarRequirement),
                typeof(Core.Requirements.Standard.HyperlinkRequirement),
                typeof(Core.Requirements.Standard.ImageRequirement),
                typeof(Core.Requirements.Standard.LabelRequirement),
                typeof(Core.Requirements.Standard.ProgressBarRequirement),
                typeof(Core.Requirements.Standard.SliderRequirement),
                typeof(Core.Requirements.Standard.TabRequirement),
                typeof(Core.Requirements.Standard.TooltipRequirement),
                typeof(Core.Requirements.Standard.UIItemsRequirement),
                typeof(Core.Requirements.Standard.VScrollBarRequirement),

                typeof(Core.Requirements.Windows.MessageBoxRequirement),
                typeof(Core.Requirements.Windows.ModalWindowRequirement),
                typeof(Core.Requirements.Windows.NativeWindowRequirement),
                typeof(Core.Requirements.Windows.GenericScreenTypeRequirement),
                typeof(Core.Requirements.Windows.WindowRequirement),

                typeof(Core.Requirements.UIA.AutomationElementXRequirement),

                typeof(Core.Requirements.Interceptors.DisabledControlsRequirement),
                typeof(Core.Requirements.Interceptors.ScollInterceptorsRequirement),
                
                typeof(Core.Requirements.InputDevices.AttachedKeyboardRequirement),
                typeof(Core.Requirements.InputDevices.DragAndDropRequirement),
                typeof(Core.Requirements.InputDevices.KeyboardRequirement),
                typeof(Core.Requirements.InputDevices.MouseRequirement),

                typeof(Core.Requirements.Factory.InitializeOptionRequirement),

                typeof(Core.Requirements.Scenarios.GetMultipleRequirement), 

                typeof(Core.Requirements.AutomationElementSearch.RawAutomationElementFinderTest),

                typeof(Modules.Wpf.Requirements.DataGridRequirement),
            });
        }

        public override TestConfiguration GetTestConfiguration()
        {
            return new WpfTestConfiguration();
        }
    }
}
