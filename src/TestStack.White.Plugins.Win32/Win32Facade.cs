﻿using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Core;
using TestStack.White.Core.Mappings;
using TestStack.White.Plugins;

namespace TestStack.White.Plugins.Win32
{
    [WhitePlugin("Win32")]
    public class Win32Facade : PluginFacade
    {
        public Win32Facade()
        {
            ControlItems.AddWin32Primary(typeof(UIItems.WindowStripControls.MenuBar), ControlType.MenuBar);
            ControlItems.AddWin32Primary(typeof(UIItems.ListBoxItems.Win32ComboBox), ControlType.ComboBox);
            ControlItems.AddWin32Primary(typeof(UIItems.TextBox), ControlType.Document);
            ControlItems.AddWin32Primary(typeof(UIItems.Image), ControlType.Image);

            ControlItems.Add(ControlDictionaryItem.Win32Secondary(typeof(UIItems.ListBoxItems.Win32ListItem), ControlType.ListItem));
            ControlItems.Add(ControlDictionaryItem.Win32Secondary(typeof(UIItems.TreeItems.Win32TreeNode), ControlType.TreeItem));
        }

    }
}
