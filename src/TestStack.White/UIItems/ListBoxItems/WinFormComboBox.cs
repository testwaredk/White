using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.ListBoxItems
{
    //todo document specialized classes and their methods somehow
    [PlatformSpecificItem]
    public class WinFormComboBox : ComboBox
    {
        protected WinFormComboBox() {}

        public WinFormComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

    }
}