using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Win32
{
    [WhitePlugin("Win32")]
    public class Facade : IPluginFacade
    {
        public ControlDictionaryItems GetControlDictionaryItems()
        {
            ControlDictionaryItems items = new ControlDictionaryItems();

            items.AddWin32Primary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.MenuBar);
            items.AddWin32Primary(typeof(UIItems.ListBoxItems.Win32ComboBox), ControlType.ComboBox);
            items.AddWin32Primary(typeof(UIItems.TextBox), ControlType.Document);
            items.AddWin32Primary(typeof(UIItems.Image), ControlType.Image);

            items.Add(ControlDictionaryItem.Win32Secondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.Win32Secondary(typeof(UIItems.TreeItems.Win32TreeNode), ControlType.TreeItem));

            return items;
        }

        public List<Type> GetEditableControls()
        {
            List<Type> editableControls = new List<Type>();
            return editableControls;
        }

    }
}
