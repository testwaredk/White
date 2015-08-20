using System;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.TreeItems;

namespace TestStack.White.Modules.Screens
{
    public class MainScreen : AppScreen
    {
        public MainScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }
        public virtual StatusBar GetStatusBar() { return null; }
        public virtual MenuBar GetMenuBar() { return Window.MenuBar; }
        public virtual TextBox GetTextBox() { return Window.Get<TextBox>("TextBox"); }
        public virtual ComboBox GetComboBox() { return Window.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox")); }
        public virtual ComboBox GetEditableComboBox() { return Window.Get<ComboBox>(SearchCriteria.ByAutomationId("EditableComboBox")); }
        public virtual ListBox GetListBoxWithVScrollBar() { return Window.Get<ListBox>("ListBoxWithVScrollBar"); }
        public virtual Tab GetControlsTab() { return Window.Get<Tab>("ControlsTab"); }
        public virtual Button GetReverseTabOrderButton() { throw new System.NotImplementedException(); }
        public virtual RadioButton GetRadioButton1() { return Window.Get<RadioButton>("RadioButton1"); }
        public virtual RadioButton GetRadioButton2() { return Window.Get<RadioButton>("RadioButton2"); }
        public virtual TextBox GetMultilineTextBox() { return Window.Get<TextBox>("MultiLineTextBox"); }
        public virtual CheckBox GetCheckBox() { return Window.Get<CheckBox>("CheckBox"); }
        public virtual Button GetButtonWithTooltip(IUIItemContainer container) { return container.Get<Button>("ButtonWithTooltip"); }
        public virtual GroupBox GetScenariosPane() { return Window.Get<GroupBox>("ScenariosPane"); }
        public virtual Button GetFoo() { return Window.Get<Button>(SearchCriteria.ByAutomationId("foo")); }
        public virtual Button GetButtonDisableControls() { return Window.Get<Button>("DisableControls"); }
        public virtual IDateTimePicker GetDateTimePicker() { return Window.Get<DateTimePicker>("DatePicker"); }
        public virtual Button GetButtonOpenListView() { return Window.Get<Button>("OpenListView"); }
        public virtual Tree GetTreeView() { return Window.Get<Tree>("TreeView"); }
        public virtual string GetHelpText() { return Window.HelpText; }
        public virtual Button GetButtonAddNode() { return Window.Get<Button>("AddNode"); }

        public virtual ListViewWindowScreen GetListViewWindowScreen()
        {
            var window = Window.ModalWindow("ListViewWindow");
            ListViewWindowScreen screen = new ListViewWindowScreen(window, this.ScreenRepository);
            return screen;
        }
        
        #region Expected values
        public virtual int GetExpectedTabCount() { return 5; }
        public virtual string GetExpectedTextOnRaiseClickEventOnButton() { return "Clicked"; }
        public virtual DateTime? GetExpectedDateForDatePicker() { return DateTime.Today; }
        public virtual string GetExpectedStatusBarText() { return ""; }
        #endregion

    }
}

