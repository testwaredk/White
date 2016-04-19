using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class Win32ComboBox : ComboBox
    {
        protected Win32ComboBox() {}
        public Win32ComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public override IScrollBars ScrollBars
        {
            get
            {
                AutomationElement scrollParentElement =
                    new AutomationElementFinder(automationElement).Child(AutomationSearchCondition.ByAutomationId("ListBox"));
                if (scrollBars == null) scrollBars = ScrollerFactory.CreateBars(scrollParentElement, actionListener);
                return scrollBars;
            }
        }

        /// <summary>
        /// Win32 and Winform uses ControlType.Edit and ValuePattern
        /// 
        /// Set the text in the TextBox inside the combobox.
        /// </summary>
        public override string Text
        {
            get { return GetTextBox().Text; }
        }

        private TextBox GetTextBox()
        {
            return new TextBox(Finder.Child(AutomationSearchCondition.ByControlType(ControlType.Text)), actionListener);
        }
    }
}