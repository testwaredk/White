using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class HotKeyTest : WhiteTestBase
    {
        public void AccessKey()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            //if (framework != WindowsFramework.Wpf) Assert.Equal("Alt+B", button.AccessKey);
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.Enter("B");
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Retry.For(() => Assert.Equal("Clicked", button.Text), TimeSpan.FromSeconds(2));
        }

        protected override void ExecuteTestRun()
        {
            RunTest(AccessKey);
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Standard.HotKeyRequirement);
        }
    }
}