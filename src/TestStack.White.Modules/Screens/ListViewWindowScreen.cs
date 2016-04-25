using System;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TestStack.White.Modules.Screens
{
    public class ListViewWindowScreen : AppScreen
    {
        public ListViewWindowScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }
        public virtual ListView GetListViewControl() { return Window.Get<ListView>("ListView"); }
        public Window GetWindow() { return Window; }

        public virtual Button GetDeleteButton() { return Window.Get<Button>("cmdDeleteRow"); }

        public virtual int GetExpectedColumnCount() { return 2; }

        public virtual Button GetAddButton() { return Window.Get<Button>("cmdAddRow"); }
    }
}
