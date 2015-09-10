using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules.Screens;

namespace TestStack.White.Modules.WinForm.Screens
{
    public class WinFormMainScreen : MainScreen
    {
        public WinFormMainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }
        public override UIItemContainer GetInputControls() { return Window.Get<Panel>("inputControls1"); }
        public override Button GetReverseTabOrderButton() { return Window.Get<Button>("ReverseTabOrderButton"); }
    }
}
