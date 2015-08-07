using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules.Screens;

namespace TestStack.White.Modules
{
    public abstract class TestConfiguration
    {
        public abstract Application LaunchApplication();
        public abstract Window GetMainWindow(Application application);
        public abstract MainScreen GetMainScreen(ScreenRepository repository);
    }
}