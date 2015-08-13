using System;

namespace TestStack.White.UIItems
{
    public interface IDateTimePicker : IUIItem
    {
        DateTime? Date { get; set; }

        void SetDate(DateTime? dateTime, DateFormat dateFormat);
    }
}