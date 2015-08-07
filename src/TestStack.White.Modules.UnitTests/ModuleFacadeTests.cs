using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Modules;
using NUnit.Framework;

namespace TestStack.White.Modules.UnitTests
{
    public class TestModuleFacade : ModuleFacade
    {
        public override TestConfiguration GetTestConfiguration()
        {
            throw new NotImplementedException();
        }
    }

    public class ModuleFacadeTests
    {
        [Test]
        public void controls_that_should_be_supported()
        {
            ModuleFacade facade = new TestModuleFacade();
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Thumb)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Button)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.CheckBox)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Hyperlink)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.RadioButton)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.ListView)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.ProgressBar)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Spinner)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.GroupBox)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Panel)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.ListBoxItems.ListBox)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TableItems.Table)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TabItems.Tab)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.WindowStripControls.ToolStrip)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.PropertyGridItems.PropertyGrid)));
        }

        [Test]
        public void secondary_controls_that_should_be_supported()
        {
            ModuleFacade facade = new TestModuleFacade();
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TableItems.TableRowHeader)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TabItems.TabPage)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Scrolling.VScrollBar)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.Scrolling.HScrollBar)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TableItems.TableHeader)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.TableItems.TableRow)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.MenuItems.Menu)));
            Assert.IsTrue(facade.IsControlSupported(typeof(UIItems.ListViewRow)));

        }
    }
}
