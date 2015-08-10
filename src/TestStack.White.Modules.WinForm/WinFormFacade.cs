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

            SupportedRequirements.AddRange(new List<Type>() {
                typeof(Core.Requirements.InputControls.RadioButtonRequirement),
                typeof(Core.Requirements.InputControls.CheckboxRequirement),
                typeof(Core.Requirements.InputControls.DateTimePickerRequirement),
                typeof(Core.Requirements.InputControls.PasswordTextBox),
                typeof(Core.Requirements.InputControls.RadioButtonRequirement),
                typeof(Core.Requirements.InputControls.TristateItemReqiurement),
                typeof(Core.Requirements.InputControls.TextBoxRequirement),

                typeof(Core.Requirements.ListControls.CheckedlistBoxRequirement),
                typeof(Core.Requirements.ListControls.ComboBoxRequirement),
                typeof(Core.Requirements.ListControls.EditableCombpBoxRequirement),
                typeof(Core.Requirements.ListControls.ListBoxRequirement),
                typeof(Core.Requirements.ListControls.ListViewRequirement),

                typeof(Core.Requirements.MenuItems.MenuRequirement),
                typeof(Core.Requirements.MenuItems.PopUpMenuRequirement),

                typeof(Core.Requirements.Splitters.HorizontalThumbRequirement),

                typeof(Core.Requirements.Table.TableCellRequirement),
                typeof(Core.Requirements.Table.TableRowsRequirement),
                typeof(Core.Requirements.Table.TableRowRequirement),
                typeof(Core.Requirements.Table.TableRequirement),

                typeof(Core.Requirements.TreeItems.TreeNodeRequirement),
                typeof(Core.Requirements.TreeItems.TreeRequirement),

                typeof(Core.Requirements.WindowStripControls.StatusStripRequirment),

                typeof(Core.Requirements.Standard.ButtonRequirement),
                typeof(Core.Requirements.Standard.CustomUIItemRequirement),
                typeof(Core.Requirements.Standard.DataGridRequirement),
                typeof(Core.Requirements.Standard.GroupBoxRequirement),
                typeof(Core.Requirements.Standard.HotKeyRequirement),
                typeof(Core.Requirements.Standard.HScrollBarRequirement),
                typeof(Core.Requirements.Standard.HyperlinkRequirement),
                typeof(Core.Requirements.Standard.ImageRequirement),
                typeof(Core.Requirements.Standard.LabelRequirement),
                typeof(Core.Requirements.Standard.PanelRequirment),
                typeof(Core.Requirements.Standard.ProgressBarRequirement),
                typeof(Core.Requirements.Standard.PropertyGridRequirement),
                typeof(Core.Requirements.Standard.SliderRequirement),
                typeof(Core.Requirements.Standard.TabRequirement),
                typeof(Core.Requirements.Standard.TooltipRequirement),
                typeof(Core.Requirements.Standard.VScrollBarRequirement),

                typeof(Core.Requirements.Windows.MessageBoxRequirement),
                typeof(Core.Requirements.Windows.ModalWindowRequirement),
                typeof(Core.Requirements.Windows.NativeWindowRequirement),
                typeof(Core.Requirements.Windows.GenericScreenTypeRequirement),

                typeof(Core.Requirements.UIA.AutomationElementXRequirement),

                typeof(Core.Requirements.Interceptors.DisabledControlsRequirement),
                typeof(Core.Requirements.Interceptors.ScollInterceptorsRequirement),

                typeof(Core.Requirements.InputDevices.AttachedKeyboardRequirement),
                typeof(Core.Requirements.InputDevices.DragAndDropRequirement),
                typeof(Core.Requirements.InputDevices.KeyboardRequirement),
                typeof(Core.Requirements.InputDevices.MouseRequirement),

                typeof(Core.Requirements.Factory.InitializeOptionRequirement),

                typeof(Core.Requirements.AutomationElementSearch.RawAutomationElementFinderTest),

                typeof(Modules.WinForm.Requirements.ColorRequirement),

            });
        }

        public override TestConfiguration GetTestConfiguration()
        {
            return new WinformsTestConfiguration();
        }

    }
}
