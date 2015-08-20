using System.Linq;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.WindowStripControls
{
    public class WPFStatusBar : StatusBar
    {
        protected WPFStatusBar() {}
        public WPFStatusBar(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public override UIItemCollection Items
        {
            get
            {
                var uiItemCollection = factory.CreateAll(SearchCriteria.All, actionListener)
                    .Where(i => i.AutomationElement.Current.ClassName == "StatusBarItem");
                return new UIItemCollection(uiItemCollection);
            }
        }
    }
}