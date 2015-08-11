using System.IO;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules;
using TestStack.White.Modules.WinForm;


using Xunit;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class WorkSessionTest
    {
        public WorkSessionTest()
        {
            ModulesManager manager = ModulesManager.Instance;
        }

        [Fact]
        public void ShouldNotSaveAnyWindowInformationToFileWhenNoWindowsAreLaunched()
        {
            int numberOfFilesBeforeSessionStart = NumberOfFiles();
            using (WorkSession()){}
            Assert.Equal(numberOfFilesBeforeSessionStart, NumberOfFiles());
        }

        [Fact]
        public void ShouldSaveWindowInformationInFile()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
            Assert.True(File.Exists("foo.xml"));
        }

        [Fact]
        public void ShouldFindControlBasedLocation()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
        }

        private static WorkSession WorkSession()
        {
            return new WorkSession(new WorkConfiguration(), new NullWorkEnvironment());
        }

        private static int NumberOfFiles()
        {
            return Directory.GetFiles(".").Length;
        }
    }
}