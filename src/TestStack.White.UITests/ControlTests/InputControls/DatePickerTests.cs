using System;
using System.Linq;
using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        IDateTimePicker dateTimePicker;

        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            dateTimePicker = MainScreen.GetDateTimePicker();
            RunTest(GetDate);
            RunTest(SetDate);
            RunTest(ClearDate);
            RunTest(ChangeDateToLastDayOfMonth);
            RunTest(ChangeDateLeapDate);
            
        }

        private void GetDate()
        {
            
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
            int randomOffset = 18;

            DateTime changedDate = DateTime.Today.AddDays(randomOffset);

            // set the date to a date not used in the tests
            dateTimePicker.Date = changedDate;

            DateTime? expectedDate = MainScreen.GetExpectedDateForDatePicker();
            // reset the date to expected date
            dateTimePicker.Date = expectedDate;

            // clear the date
            dateTimePicker.Date = null;

            // expect that the date is unchanged unless 
            Assert.Equal(expectedDate, dateTimePicker.Date);

        }

        private void ChangeDateToLastDayOfMonth()
        {
            DateTime? dateInMonthWithLessThan31Days = new DateTime(2015, 02, 10);
            DateTime? dateInMonthWith31Days = new DateTime(2015, 01, 31);

            dateTimePicker.Date = dateInMonthWithLessThan31Days;
            Assert.Equal(dateInMonthWithLessThan31Days, dateTimePicker.Date);

            dateTimePicker.Date = dateInMonthWith31Days;
            Assert.Equal(dateInMonthWith31Days, dateTimePicker.Date);

        }

        private void ChangeDateLeapDate()
        {
            DateTime? dateInANonLeapYear = new DateTime(2015, 02, 10);
            DateTime? leapDate = new DateTime(2016, 02, 29);

            dateTimePicker.Date = dateInANonLeapYear;
            Assert.Equal(dateInANonLeapYear, dateTimePicker.Date);

            dateTimePicker.Date = leapDate;
            Assert.Equal(leapDate, dateTimePicker.Date);

        }


        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.InputControls.DateTimePickerRequirement);
        }

    }
}