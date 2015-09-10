using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules.Screens;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

namespace TestStack.White.Modules.Wpf.Screens
{
    public class WpfMainScreen : MainScreen
    {
        public WpfMainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }
        public override UIItemContainer GetInputControls() { return (UIItemContainer)Window.Get(SearchCriteria.ByControlType(ControlType.TabItem).AndByClassName("TabItem").AndOfFramework(Core.WindowsFramework.Wpf).AndByText("Input Controls")); }
        public override Button GetButtonUpdateStatusBarText() { return Window.Get<Button>("UpdateStatusBarText"); }
        public override int GetExpectedTabCount() { return 4; }
        public override System.DateTime? GetExpectedDateForDatePicker() { return null; }
        public virtual ListBox GetListBoxWpf() { return Window.Get<ListBox>("ListBoxWpf"); }
        public virtual Button GetChangeListItems() { return Window.Get<Button>("ChangeListItems"); }
        public override StatusBar GetStatusBar() { return Window.Get<WPFStatusBar>("StatusBar"); }
        public override string GetExpectedStatusBarText() { return "Status Item 1"; }
    }
}