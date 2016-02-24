using System;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UIItems
{
    public class DateTimePicker : UIItem, IDateTimePicker
    {
        protected DateTimePicker() {}
        public DateTimePicker(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual DateTime? Date
        {
            get
            {
                var property = (string) Property(ValuePattern.ValueProperty);
                if (string.IsNullOrEmpty(property))
                    return null;
                return DateTime.Parse(property);
            }
            set
            {
                SetDate(value, CoreAppXmlConfiguration.Instance.DefaultDateFormat);
            }
        }

        public virtual void SetDate(DateTime? dateTime, DateFormat dateFormat)
        {
            if (dateTime == null)
            {
                Logger.Warn("DateTime cannot be null, value will not be set");
                return;
            }

            if (IsTimePicker)
                SendTime(dateTime.Value, dateFormat);
            else
                SendDate(dateTime.Value, dateFormat);
        }

        private void SendDate(DateTime dateTime, DateFormat dateFormat)
        {
            // first set the year, then month, then day, otherwise we end up trying to set a day that doesnt exist in a month 
            // like going from 10-02-2015 to 31-01-2015
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime, 2).ToString(), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, actionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime, 1).ToString().PadLeft(2, '0'), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, actionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime, 0).ToString().PadLeft(2, '0'), actionListener);

        }

        private void SendTime(DateTime? dateTime, DateFormat dateFormat)
        {
            keyboard.Send(dateTime.Value.Hour.ToString().PadLeft(2, '0'), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.Send(dateTime.Value.Minute.ToString().PadLeft(2, '0'), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.Send(dateTime.Value.Second.ToString().PadLeft(2, '0'), actionListener);
        }



        public bool IsTimePicker
        {
            get
            {
                AutomationElementCollection elementCollection = this.AutomationElement.FindAll(TreeScope.Children, Condition.TrueCondition);
                return elementCollection.Count > 0;
            }
        }

    }
}