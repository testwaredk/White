using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Castle.Core.Logging;
using TestStack.White.Modules;
using TestStack.White.Core;
using TestStack.White.Configuration;
using TestStack.White.InputDevices;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Modules.Screens;
using Xunit;

namespace TestStack.White.UITests
{
    public abstract class WhiteTestBase
    {
        readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WhiteTestBase));
        readonly List<Window> windowsToClose = new List<Window>();
        readonly string screenshotDir;
        WindowsFramework? currentFramework = null;
        ModuleFacade currentModule;

        internal Keyboard Keyboard;

        protected WhiteTestBase()
        {
            screenshotDir = "c:\\FailedTestsScreenshots";
            if (!Directory.Exists(screenshotDir))
                Directory.CreateDirectory(screenshotDir);
        }

        protected Window MainWindow { get; private set; }
        protected MainScreen MainScreen { get; private set; }
        protected Application Application { get; private set; }
        protected ScreenRepository Repository { get; private set; }

        [Fact]
        public void Automate()
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Debug);
            if (ModulesManager.Instance.LoadedModules.Count == 0) throw new TestFailedException("No modules loaded");

            foreach (ModuleFacade module in ModulesManager.Instance.LoadedModules)
            {
                currentModule = module;
                // ensure that all controls is supported by the plugins before running the test
                if (CoveredRequirements().All(t => module.IsRequirementSupported(t)))
                {
                    using (SetMainWindow(module))
                    {
                        try
                        {
                            ExecuteTestRun();
                        }
                        catch (TestFailedException)
                        {
                            throw;
                        }
                        catch (Exception ex)
                        {
                            throw new TestFailedException(string.Format("Failed to run test for {0}", module), ex);
                        }
                    }
                }
                else
                {
                    logger.Warn("No modules with support for the CoveredControls");
                }
            }
        }

        protected void RunTest(Action testAction, params WindowsFramework[] runFor)
        {
            if (!runFor.Any() || runFor.Any(r => r == currentFramework))
            {
                try
                {
                    testAction();
                }
                catch (Exception ex)
                {
                    string path2 = string.Empty;
                    try
                    {
                        path2 = testAction.Method.Name + ".png";
                        var filename = Path.Combine(screenshotDir, path2);
                        new ScreenCapture().CaptureScreenShot().Save(filename, ImageFormat.Png);
                        Trace.WriteLine(string.Format("Screenshot taken: {0}", filename));
                    }
                    catch (Exception)
                    {
                        Trace.TraceError(string.Format("Failed to save screenshot to directory: {0}, filename: {1}", screenshotDir, path2));
                    }
                    throw new TestFailedException(string.Format("Failed to run {0} for {1}. Details:\r\n\r\n{2}", 
                        testAction.Method.Name, currentFramework, ex), ex);
                }
            }
        }

        protected abstract void ExecuteTestRun();

        private IDisposable SetMainWindow(ModuleFacade module)
        {
            try
            {
                Keyboard = Keyboard.Instance;
                var configuration = module.GetTestConfiguration();
                Application = configuration.LaunchApplication();
                Repository = new ScreenRepository(Application);
                MainWindow = configuration.GetMainWindow(Application);
                MainScreen = configuration.GetMainScreen(Repository);

                return new ShutdownApplicationDisposable(this);

            }
            catch (Exception e)
            {
                logger.Error("Failed to launch application and get main window", e);
                if (Application != null)
                    Application.Close();
                throw;

            }
        }

        /// <summary>
        /// CoveredControls are the controls (UIItem types) that the test case
        /// is testing. It is only the test case itself that knows which UIItems that should be tested here.
        /// When Automate is executed, the runner ensures that the plugins loaded supports the controls that should be tested by the test case.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<Type> CoveredRequirements();

        private class ShutdownApplicationDisposable : IDisposable
        {
            private readonly WhiteTestBase testBase;

            public ShutdownApplicationDisposable(WhiteTestBase testBase)
            {
                this.testBase = testBase;
            }

            public void Dispose()
            {
                foreach (var window in testBase.windowsToClose)
                {
                    if (!window.IsClosed)
                        window.Close();
                }
                testBase.windowsToClose.Clear();
                testBase.MainWindow.Close();
                testBase.Application.Dispose();
                testBase.Application = null;
                testBase.MainWindow = null;
            }
        }

        protected Window StartScenario(string scenarioButtonId, string windowTitle)
        {
            MainWindow.Get<Button>(scenarioButtonId).Click();
            var window = MainWindow.ModalWindow(windowTitle);
            windowsToClose.Add(window);
            return window;
        }

        protected void SelectOtherControls()
        {
            MainWindow.Tabs[0].SelectTabPage(2);
        }

        protected void SelectInputControls()
        {
            MainWindow.Tabs[0].SelectTabPage(1);
        }

        protected void SelectListControls()
        {
            MainWindow.Tabs[0].SelectTabPage(0);
        }

        protected void SelectDataGridTab()
        {
            MainWindow.Tabs[0].SelectTabPage(3);
        }

        protected void SelectPropertyGridTab()
        {
            MainWindow.Tabs[0].SelectTabPage(4);
        }
    }
}