using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Generic
{
    [WhitePlugin("Generic for non specific frameworkId")]
    public class GenericFacade : PluginFacade
    {
        public override ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            items.AddPrimary(typeof(UIItems.Thumb), ControlType.Thumb);
            items.AddPrimary(typeof(UIItems.Button), ControlType.Button);
            items.AddPrimary(typeof(UIItems.CheckBox), ControlType.CheckBox);
            items.AddPrimary(typeof(UIItems.ListBoxItems.ListBox), ControlType.List);
            items.AddPrimary(typeof(UIItems.Hyperlink), ControlType.Hyperlink);
            items.AddPrimary(typeof(UIItems.TreeItems.Tree), ControlType.Tree);
            items.AddPrimary(typeof(UIItems.RadioButton), ControlType.RadioButton);
            items.AddPrimary(typeof(UIItems.TableItems.Table), ControlType.Table);
            items.AddPrimary(typeof(UIItems.TabItems.Tab), ControlType.Tab, true);
            items.AddPrimary(typeof(UIItems.ListView), ControlType.DataGrid);
            items.AddPrimary(typeof(UIItems.WindowStripControls.ToolStrip), ControlType.ToolBar);

            items.AddPrimary(typeof(UIItems.ProgressBar), ControlType.ProgressBar);
            items.AddPrimary(typeof(UIItems.Spinner), ControlType.Spinner);


            items.Add(new ControlDictionaryItem(typeof(UIItems.GroupBox), ControlType.Group, string.Empty, false, true, false, null, true));
            items.Add(new ControlDictionaryItem(typeof(UIItems.Panel), ControlType.Pane, "", false, true, false, null, true));
            items.Add(new ControlDictionaryItem(null, ControlType.TitleBar, string.Empty, false, false, true, null, false));

            ControlDictionaryItem dictionaryItem = ControlDictionaryItem.Primary(typeof(UIItems.PropertyGridItems.PropertyGrid), ControlType.Pane);
            dictionaryItem.IsIdentifiedByName = true;
            items.Add(dictionaryItem);

            items.AddSecondary(typeof(UIItems.TableItems.TableRowHeader), ControlType.Header);
            items.AddSecondary(typeof(UIItems.TabItems.TabPage), ControlType.TabItem, true);
            items.AddSecondary(typeof(UIItems.Scrolling.VScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof(UIItems.Scrolling.HScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof(UIItems.TableItems.TableHeader), ControlType.Custom);
            items.AddSecondary(typeof(UIItems.TableItems.TableRow), ControlType.Custom);
            items.AddSecondary(typeof(UIItems.MenuItems.Menu), ControlType.MenuItem);
            items.AddSecondary(typeof(UIItems.ListViewRow), ControlType.DataItem);

            return items;
        }


        public override List<Type> GetEditableControls()
        {
            List<Type> editableControls = new List<Type>();

            editableControls.Add(typeof(UIItems.TextBox));
            editableControls.Add(typeof(UIItems.CheckBox));
            editableControls.Add(typeof(UIItems.RadioButton));
            editableControls.Add(typeof(UIItems.ListBoxItems.ListControl));

            return editableControls;
        }



        public override Type[] GetSupportedGenericControls()
        {
            throw new NotImplementedException();
        }
    }
}
