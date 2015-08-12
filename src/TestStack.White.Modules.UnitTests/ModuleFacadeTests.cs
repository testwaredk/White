using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Modules;
using Xunit;
using TestStack.White.Core.Requirements.InputControls;

namespace TestStack.White.Modules.UnitTests
{

    public class ModuleFacadeTests
    {
        ModuleFacade facade;

        public ModuleFacadeTests()
        {
            facade = new TestModuleFacade();
        }


        [Fact]
        public void requirements_that_should_be_supported()
        {
            Assert.True(facade.IsRequirementSupported(typeof(TextBoxRequirement)));
        }

        [Fact]
        public void requirements_that_shouldnt_be_supported()
        {
            Assert.False(facade.IsRequirementSupported(typeof(DateTimePickerRequirement)));
        }

        [Fact]
        public void controls_that_should_be_supported_by_default()
        {
            List<Type> defaultItems = new List<Type>() {
                typeof(UIItems.Thumb),
                typeof(UIItems.Button),
                typeof(UIItems.CheckBox),
                typeof(UIItems.RadioButton),
                typeof(UIItems.Hyperlink),
                typeof(UIItems.ListView),
                typeof(UIItems.ProgressBar),
                typeof(UIItems.Spinner),
                typeof(UIItems.GroupBox),
                typeof(UIItems.Panel),
                typeof(UIItems.ListViewRow),
                typeof(UIItems.TreeItems.Tree),
                typeof(UIItems.ListBoxItems.ListBox),
                typeof(UIItems.WindowStripControls.ToolStrip),
                typeof(UIItems.PropertyGridItems.PropertyGrid),
                typeof(UIItems.Scrolling.VScrollBar),
                typeof(UIItems.Scrolling.HScrollBar),
                typeof(UIItems.TabItems.Tab),
                typeof(UIItems.TabItems.TabPage),
                typeof(UIItems.TableItems.Table),
                typeof(UIItems.TableItems.TableRowHeader),
                typeof(UIItems.TableItems.TableHeader),
                typeof(UIItems.TableItems.TableRow),
                typeof(UIItems.MenuItems.Menu),
            };
            
            defaultItems.ForEach((item) => {
                Assert.True(facade.ControlItems.Any(control => control.TestControlType.Equals(item)), string.Format("default item should be contained in controlitems {0}", item.FullName));
            });
                
        }
    }
}
