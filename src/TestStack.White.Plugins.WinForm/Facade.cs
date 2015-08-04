using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.WinForm
{
    [WhitePlugin("WinForm")]
    public class Facade : IPluginFacade
    {
        public ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            items.AddWinFormPrimary(typeof(UIItems.TextBox), ControlType.Document);
            items.AddWinFormPrimary(typeof(UIItems.Thumb), ControlType.Thumb);
            items.AddWinFormPrimary(typeof(UIItems.Button), ControlType.Button);
            items.AddWinFormPrimary(typeof(UIItems.CheckBox), ControlType.CheckBox);
            items.AddWinFormPrimary(typeof(UIItems.Hyperlink), ControlType.Hyperlink);
            items.AddWinFormPrimary(typeof(UIItems.RadioButton), ControlType.RadioButton);
            items.AddWinFormPrimary(typeof(UIItems.ListView), ControlType.DataGrid);
            items.AddWinFormPrimary(typeof(UIItems.WinFormTextBox), ControlType.Edit);
            items.AddWinFormPrimary(typeof(UIItems.WinFormSlider), ControlType.Slider);
            items.AddWinFormPrimary(typeof(UIItems.Label), ControlType.Text);
            items.AddWinFormPrimary(typeof(UIItems.TreeItems.Tree), ControlType.Tree);
            items.AddWinFormPrimary(typeof(UIItems.TableItems.Table), ControlType.Table);
            items.AddWinFormPrimary(typeof(UIItems.TabItems.Tab), ControlType.Tab, true);
            items.AddWinFormPrimary(typeof(UIItems.WindowStripControls.ToolStrip), ControlType.ToolBar);
            items.AddWinFormPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.MenuBar);
            items.AddWinFormPrimary(typeof(UIItems.WindowStripControls.StatusStrip), ControlType.StatusBar);
            items.AddWinFormPrimary(typeof(UIItems.ListBoxItems.WinFormComboBox), ControlType.ComboBox);
            items.AddWinFormPrimary(typeof(UIItems.ListBoxItems.ListBox), ControlType.List);

            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.ListViewRow), ControlType.DataItem));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TreeItems.Win32TreeNode), ControlType.TreeItem));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TableItems.TableRowHeader), ControlType.Header));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TableItems.TableHeader), ControlType.Custom));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TableItems.TableRow), ControlType.Custom));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.TabItems.TabPage), ControlType.TabItem, true));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.Scrolling.VScrollBar), ControlType.ScrollBar));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.Scrolling.HScrollBar), ControlType.ScrollBar));
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(UIItems.MenuItems.Menu), ControlType.MenuItem));

            items.Add(new ControlDictionaryItem(typeof(UIItems.DateTimePicker), ControlType.Pane, "SysDateTimePick32", true, true, false, WindowsFramework.WinForms.FrameworkId(), false));

            return items;
        }
    }
}
