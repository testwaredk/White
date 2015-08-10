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
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Thumb)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Button)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.CheckBox)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Hyperlink)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.RadioButton)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.ListView)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.ProgressBar)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Spinner)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.GroupBox)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Panel)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.ListBoxItems.ListBox)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TableItems.Table)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TabItems.Tab)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.WindowStripControls.ToolStrip)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.PropertyGridItems.PropertyGrid)));
        }

        [Test]
        public void secondary_controls_that_should_be_supported()
        {
            ModuleFacade facade = new TestModuleFacade();
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TableItems.TableRowHeader)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TabItems.TabPage)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Scrolling.VScrollBar)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.Scrolling.HScrollBar)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TableItems.TableHeader)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.TableItems.TableRow)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.MenuItems.Menu)));
            Assert.IsTrue(facade.IsRequirementSupported(typeof(UIItems.ListViewRow)));

        }
    }
}
