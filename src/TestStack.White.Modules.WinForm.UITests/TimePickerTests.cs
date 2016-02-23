using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using Xunit;
using TestStack.White.UITests;
using Tests = TestStack.White.UITests.ControlTests.InputControls;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class TimePickerTests : Tests.DatePickerTests
    {
        
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(SetTime);
        }

        void SetTime()
        {
            var timePicker = MainScreen.GetTimePicker();
            var changedTime = DateTime.Now.AddHours(2);
            timePicker.Date = changedTime;
            // only the time part should be equal
            Assert.Equal(timePicker.Date.Value.ToShortTimeString(), changedTime.ToShortTimeString());
        }

        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.InputControls.DateTimePickerRequirement);
        }
    }
}