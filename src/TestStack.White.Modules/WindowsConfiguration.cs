using System.Diagnostics;
using System.IO;
using System.Reflection;
using TestStack.White.Core;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules.Screens;

namespace TestStack.White.Modules
{
    public abstract class WindowsConfiguration : TestConfiguration
    {
        private readonly WindowsFramework framework;

        protected WindowsConfiguration(WindowsFramework framework)
        {
            this.framework = framework;
        }

        public override Application LaunchApplication()
        {
            var fileInfo = new FileInfo(Path.Combine(System.Environment.CurrentDirectory, ApplicationExePath()));
            
            var processStartInfo = new ProcessStartInfo
            {
                FileName = fileInfo.FullName,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = fileInfo.DirectoryName,
            };
            return Application.Launch(processStartInfo);
        }

        public override Window GetMainWindow(Application application)
        {
            return application.GetWindow(Criteria(), InitializeOption.NoCache.AndIdentifiedBy("foo"));
        }

        public override MainScreen GetMainScreen(ScreenRepository repository)
        {
            return repository.Get<MainScreen>(Criteria(), InitializeOption.NoCache);
        }

        SearchCriteria Criteria()
        {
            return SearchCriteria.ByFramework(framework.FrameworkId()).AndByText("MainWindow");
        }

        protected abstract string ApplicationExePath();
    }
}