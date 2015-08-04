using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Wpf
{
    [WhitePlugin("Wpf")]
    public class Facade : IPluginFacade
    {
        public ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            // Primary controls
            items.AddWPFPrimary(typeof(UIItems.TextBox), ControlType.Edit);
            items.AddWPFPrimary(typeof(UIItems.WPFSlider), ControlType.Slider);

            items.AddWPFPrimary(typeof(UIItems.Thumb), ControlType.Thumb);
            items.AddWPFPrimary(typeof(UIItems.Button), ControlType.Button);
            items.AddWPFPrimary(typeof(UIItems.CheckBox), ControlType.CheckBox);
            items.AddWPFPrimary(typeof(UIItems.ListBoxItems.ListBox), ControlType.List);
            items.AddWPFPrimary(typeof(UIItems.Hyperlink), ControlType.Hyperlink);
            items.AddWPFPrimary(typeof(UIItems.TreeItems.Tree), ControlType.Tree);
            items.AddWPFPrimary(typeof(UIItems.RadioButton), ControlType.RadioButton);
            items.AddWPFPrimary(typeof(UIItems.TableItems.Table), ControlType.Table);
            items.AddWPFPrimary(typeof(UIItems.TabItems.Tab), ControlType.Tab, true);
            items.AddWPFPrimary(typeof(UIItems.ListView), ControlType.DataGrid);
            items.AddWPFPrimary(typeof(UIItems.WindowStripControls.ToolStrip), ControlType.ToolBar);
            

            items.AddWPFPrimary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.Menu);

            items.AddWPFPrimary(typeof(UIItems.ProgressBar), ControlType.ProgressBar);
            items.AddWPFPrimary(typeof(UIItems.Spinner), ControlType.Spinner);

            items.AddWPFPrimary(typeof(UIItems.WPFLabel), ControlType.Text);
            items.AddWPFPrimary(typeof(UIItems.ListBoxItems.WPFComboBox), ControlType.ComboBox);
            items.AddWPFPrimary(typeof(UIItems.WindowStripControls.WPFStatusBar), ControlType.StatusBar);

            items.AddWPFPrimary(typeof(UIItems.Custom.CustomUIItem), ControlType.Custom);
            items.AddWPFPrimary(typeof(UIItems.Image), ControlType.Image);
            
            // Secondary controls
            items.AddWPFSecondary(typeof(UIItems.TableItems.TableRowHeader), ControlType.Header);
            items.AddWPFSecondary(typeof(UIItems.TabItems.TabPage), ControlType.TabItem, true);
            items.AddWPFSecondary(typeof(UIItems.Scrolling.VScrollBar), ControlType.ScrollBar);
            items.AddWPFSecondary(typeof(UIItems.Scrolling.HScrollBar), ControlType.ScrollBar);
            items.AddWPFSecondary(typeof(UIItems.TableItems.TableHeader), ControlType.Custom);
            items.AddWPFSecondary(typeof(UIItems.TableItems.TableRow), ControlType.Custom);
            items.AddWPFSecondary(typeof(UIItems.MenuItems.Menu), ControlType.MenuItem);
            items.AddWPFSecondary(typeof(UIItems.ListViewRow), ControlType.DataItem);

            items.AddWPFSecondary(typeof(UIItems.ListBoxItems.WPFListItem), ControlType.ListItem);

            items.AddWPFSecondary(typeof(UIItems.TreeItems.WPFTreeNode), ControlType.TreeItem);
            
            items.Add(new ControlDictionaryItem(typeof(UIItems.WpfDatePicker), ControlType.Custom, "DatePicker", true, true, false, WindowsFramework.Wpf.FrameworkId(), false));
            
            // Generic controls not identified by framework
            items.Add(new ControlDictionaryItem(typeof(UIItems.GroupBox), ControlType.Group, string.Empty, false, true, false, null, true));
            items.Add(new ControlDictionaryItem(typeof(UIItems.Panel), ControlType.Pane, "", false, true, false, null, true));

            ControlDictionaryItem dictionaryItem = ControlDictionaryItem.Primary(typeof(UIItems.PropertyGridItems.PropertyGrid), ControlType.Pane);
            dictionaryItem.IsIdentifiedByName = true;
            items.Add(dictionaryItem);

            return items;
        }
    }
}
