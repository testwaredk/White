using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Modules;
using TestStack.White.Modules.Screens;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using TestStack.White;
using TestStack.White.Modules.WinForm.Screens;
using TestStack.White.Factory;

namespace TestStack.White.Modules.WinForm
{
    public class WinformsTestConfiguration : WindowsConfiguration
    {
        public WinformsTestConfiguration()
            : base(WindowsFramework.WinForms)
        {
        }

        protected override string ApplicationExePath()
        {
            return @"..\..\..\TestStack.White.Modules.Winform.TestApp\bin\debug\WindowsFormsTestApplication.exe";
        }

        public override Window GetMainWindow(Application application)
        {
            return application.GetWindow(Criteria(), InitializeOption.NoCache);
        }

        public override MainScreen GetMainScreen(ScreenRepository repository)
        {
            return repository.Get<WinFormMainScreen>(Criteria(), InitializeOption.NoCache);
        }

        SearchCriteria Criteria()
        {
            return SearchCriteria.ByFramework(WindowsFramework.WinForms.FrameworkId()).AndByText("MainWindow");
        }
    }
}