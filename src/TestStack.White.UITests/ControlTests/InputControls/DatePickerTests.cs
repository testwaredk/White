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
            RunTest(ForwardBackwards);
            
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

        /// <summary>
        /// This test serves the purpose to fix a defect found while trying to set the date to 31-08-2015
        /// The problem was how the datetimepicker is navigated
        /// </summary>
        private void ForwardBackwards()
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 365; i++)
            {
                
                DateTime? baseDate = new DateTime(2015, 1, 1).AddDays(i);

                if (baseDate.Value.Day == 31 || baseDate.Value.Day == 10 || baseDate.Value.Day == 9)
                {
                    DateTime date = baseDate.Value;

                    try
                    {
                        backwards(dateTimePicker, baseDate);
                    }
                    catch
                    {
                        dates.Add(date);
                    }

                    try
                    {
                        forward(dateTimePicker, baseDate);
                    }
                    catch
                    {
                        dates.Add(date);
                    }
                }
            }
            List<String> dateStrings = dates.ConvertAll<string>((d) => d.ToShortDateString());

            Assert.True(dates.Count == 0, string.Join("\n", dateStrings.ToArray()));
            
        }


        private void forward(IDateTimePicker dateTimePicker, DateTime? baseDate)
        {
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(10));
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(0));
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(-10));
        }

        private void backwards(IDateTimePicker dateTimePicker, DateTime? baseDate)
        {
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(-10));
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(0));
            SetAndAssertDate(dateTimePicker, baseDate.Value.AddDays(10));
        }

        private void SetAndAssertDate(IDateTimePicker dateTimePicker, DateTime? newDate)
        {
            dateTimePicker.Date = newDate;
            Assert.Equal(newDate, dateTimePicker.Date);
        }


        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.InputControls.DateTimePickerRequirement);
        }

    }
}