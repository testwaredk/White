using System;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(GetDate);
            RunTest(SetDate);
            RunTest(ClearDate);
        }

        private void GetDate()
        {
            var dateTimePicker = MainScreen.GetDateTimePicker();
            Assert.Equal(MainScreen.GetExpectedDateForDatePicker(), dateTimePicker.Date);
        }

        private void SetDate()
        {
            var dateTimePicker = MainScreen.GetDateTimePicker();
            DateTime changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.Equal(changedDate, dateTimePicker.Date);

            changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.Equal(changedDate, dateTimePicker.Date);
        }

        private void ClearDate()
        {
            var dateTimePicker = MainScreen.GetDateTimePicker();

            DateTime changedDate = DateTime.Today.AddDays(18);

            // set the date to a date not used in the tests
            dateTimePicker.Date = changedDate;

            // reset the date to expected date
            dateTimePicker.Date = MainScreen.GetExpectedDateForDatePicker();

            // clear the date
            dateTimePicker.Date = null;

            // expect that the date is unchanged unless 
            Assert.Equal(MainScreen.GetExpectedDateForDatePicker(), dateTimePicker.Date);

        }


        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.InputControls.DateTimePickerRequirement);
        }

    }
}