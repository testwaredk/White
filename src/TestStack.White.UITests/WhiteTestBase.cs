﻿using System;
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

        protected ModulesManager ModuleManager { get; private set; }

        [Fact]
        public void Automate()
        {
            this.ModuleManager = ModulesManager.Instance;

            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Debug);
            if (this.ModuleManager.LoadedModules.Count == 0) throw new TestFailedException("No modules loaded");

            if (this.ModuleManager.LoadedModules.Any(m => CoveredRequirements().All(t => m.IsRequirementSupported(t))))
            {
                foreach (ModuleFacade module in this.ModuleManager.LoadedModules)
                {
                    // ensure that all controls is supported by the plugins before running the test
                    if (CoveredRequirements().All(t => module.IsRequirementSupported(t)))
                    {
                        using (SetMainWindow(module))
                        {
                            try
                            {
                                ExecuteTestRun();
                            }
                            catch (TestFailedException ex)
                            {
                                throw new TestFailedException(string.Format("Assertion failed in module {0}", module.ToString()), ex);
                            }
                            catch (Exception ex)
                            {
                                throw new TestFailedException(string.Format("Failed to run test for {0}", module.ToString()), ex);
                            }
                        }
                    }
                }
            }
            else
            {
                throw new TestFailedException(string.Format("No modules is supporting the requirements {0}", string.Join(", ", CoveredRequirements().ToList().ConvertAll(r => r.FullName).ToArray())));
            }
        }

        protected void RunTest(Action testAction, params WindowsFramework[] runFor)
        {
            if (!runFor.Any() || runFor.Any(r => r == currentFramework))
            {
                try
                {
                    logger.Debug("Executing " + testAction.Method.Name);
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

        protected Window StartScenarioListView()
        {
            MainScreen.GetButtonOpenListView().Click();
            var screen = MainScreen.GetListViewWindowScreen();
            var window = screen.GetWindow();
            windowsToClose.Add(window);
            return window;
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