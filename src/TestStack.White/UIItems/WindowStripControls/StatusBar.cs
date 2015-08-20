using System.Linq;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.WindowStripControls
{
    public class StatusBar : UIItem
    {
        protected StatusBar() {}
        public StatusBar(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) { }

        public virtual UIItemCollection Items
        {
            get
            {
                return null;
            }
        }

    }
}
