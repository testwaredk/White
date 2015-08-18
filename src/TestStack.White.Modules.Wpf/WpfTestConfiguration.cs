using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Modules;
using TestStack.White.Modules.Screens;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using TestStack.White;
using TestStack.White.Modules.Wpf.Screens;
using TestStack.White.Factory;

namespace TestStack.White.Modules.Wpf
{
    public class WpfTestConfiguration : WindowsConfiguration
    {
        public WpfTestConfiguration()
            : base(WindowsFramework.Wpf)
        {
        }

        protected override string ApplicationExePath()
        {
            return @"..\..\..\TestStack.White.Modules.Wpf.TestApp\bin\debug\WpfTestApplication.exe";
        }


        public override Window GetMainWindow(Application application)
        {
            return application.GetWindow(Criteria(), InitializeOption.NoCache);
        }

        public override MainScreen GetMainScreen(ScreenRepository repository)
        {
            return repository.Get<WpfMainScreen>(Criteria(), InitializeOption.NoCache);
        }

        SearchCriteria Criteria()
        {
            return SearchCriteria.ByFramework(WindowsFramework.Wpf.FrameworkId()).AndByText("MainWindow");
        }
    }
}