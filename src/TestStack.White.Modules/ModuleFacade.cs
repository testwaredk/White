using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.Core.Requirements.InputControls;
using TestStack.White.Core.Mappings;
using System.Windows.Automation;

namespace TestStack.White.Modules
{
    public abstract class ModuleFacade
    {
        public ControlDictionaryItems ControlItems { get; protected set; }
        public List<Type> EditableControls { get; protected set; }
        
        /// <summary>
        /// List here the requirements that the module should support.
        /// </summary>
        public List<Type> SupportedRequirements { get; protected set; }

        public ModuleFacade()
        {
            ControlItems = new ControlDictionaryItems();

            ControlItems.AddPrimary(typeof(UIItems.Thumb), ControlType.Thumb);
            ControlItems.AddPrimary(typeof(UIItems.Button), ControlType.Button);
            ControlItems.AddPrimary(typeof(UIItems.CheckBox), ControlType.CheckBox);
            ControlItems.AddPrimary(typeof(UIItems.ListBoxItems.ListBox), ControlType.List);
            ControlItems.AddPrimary(typeof(UIItems.Hyperlink), ControlType.Hyperlink);
            ControlItems.AddPrimary(typeof(UIItems.TreeItems.Tree), ControlType.Tree);
            ControlItems.AddPrimary(typeof(UIItems.RadioButton), ControlType.RadioButton);
            ControlItems.AddPrimary(typeof(UIItems.TableItems.Table), ControlType.Table);
            ControlItems.AddPrimary(typeof(UIItems.TabItems.Tab), ControlType.Tab, true);
            ControlItems.AddPrimary(typeof(UIItems.ListView), ControlType.DataGrid);
            ControlItems.AddPrimary(typeof(UIItems.WindowStripControls.ToolStrip), ControlType.ToolBar);

            ControlItems.AddPrimary(typeof(UIItems.ProgressBar), ControlType.ProgressBar);
            ControlItems.AddPrimary(typeof(UIItems.Spinner), ControlType.Spinner);


            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.GroupBox), ControlType.Group, string.Empty, false, true, false, null, true));
            ControlItems.Add(new ControlDictionaryItem(typeof(UIItems.Panel), ControlType.Pane, "", false, true, false, null, true));
            //ControlItems.Add(new ControlDictionaryItem(null, ControlType.TitleBar, string.Empty, false, false, true, null, false));

            ControlDictionaryItem dictionaryItem = ControlDictionaryItem.Primary(typeof(UIItems.PropertyGridItems.PropertyGrid), ControlType.Pane);
            dictionaryItem.IsIdentifiedByName = true;
            ControlItems.Add(dictionaryItem);

            ControlItems.AddSecondary(typeof(UIItems.TableItems.TableRowHeader), ControlType.Header);
            ControlItems.AddSecondary(typeof(UIItems.TabItems.TabPage), ControlType.TabItem, true);
            ControlItems.AddSecondary(typeof(UIItems.Scrolling.VScrollBar), ControlType.ScrollBar);
            ControlItems.AddSecondary(typeof(UIItems.Scrolling.HScrollBar), ControlType.ScrollBar);
            ControlItems.AddSecondary(typeof(UIItems.TableItems.TableHeader), ControlType.Custom);
            ControlItems.AddSecondary(typeof(UIItems.TableItems.TableRow), ControlType.Custom);
            ControlItems.AddSecondary(typeof(UIItems.MenuItems.Menu), ControlType.MenuItem);
            ControlItems.AddSecondary(typeof(UIItems.ListViewRow), ControlType.DataItem);
            //ControlItems.AddSecondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem);

            EditableControls = new List<Type>();
            EditableControls.Add(typeof(UIItems.TextBox));
            EditableControls.Add(typeof(UIItems.CheckBox));
            EditableControls.Add(typeof(UIItems.RadioButton));
            EditableControls.Add(typeof(UIItems.ListBoxItems.ListControl));

            SupportedRequirements = new List<Type>();

        }

        public bool IsRequirementSupported(Type t)
        {
            return SupportedRequirements.Exists(m => m.Equals(t));
        }

        public abstract TestConfiguration GetTestConfiguration();

    }
}
