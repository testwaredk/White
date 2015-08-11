using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.WebBrowser.Silverlight;
using TestStack.White.UITests;
using Xunit;

namespace TestStack.White.Modules.Silverlight.UITests
{
    public class SilverlightDocumentTest : WhiteTestBase
    {
        private Label label;

        
        public void Get()
        {
            var button = MainWindow.Get<Button>("button");
            Assert.NotEqual(null, button);
        }

        /// <summary>
        /// Ignoring broken tests in silverlight for the moment
        /// </summary>
        public void Event()
        {
            Assert.NotEqual(null, label);
            var button = MainWindow.Get<Button>("button");
            button.Click();
            Assert.Equal("0", label.Text);
        }

        
        public void TestComboBox()
        {
            var comboBox = MainWindow.Get<ComboBox>("combo");
            Assert.Equal(2, comboBox.Items.Count);
            Assert.Equal("foo", comboBox.Items[0].Text);
        }

        /// <summary>
        /// Ignoring broken tests in silverlight for the moment
        /// </summary>
        public void Tooltip()
        {
            var button = MainWindow.Get<Button>("button");
            ToolTip toolTip = MainWindow.GetToolTipOn(button);
            Assert.Equal(null, toolTip);

            var comboBox = MainWindow.Get<ComboBox>("combo");
            toolTip = MainWindow.GetToolTipOn(comboBox);
            Assert.NotEqual(null, toolTip);
            Debug.LogPatterns(toolTip);
            Debug.LogProperties(toolTip);
        }

        /// <summary>
        /// Ignoring broken tests in silverlight for the moment
        /// </summary>
        public void SelectItemInComboBoxWhichIsAlreadySelected()
        {
            string previousText = label.Text;
            var button = MainWindow.Get<Button>("button");
            var comboBox = MainWindow.Get<ComboBox>("combo");
            comboBox.Select("foo");
            comboBox.Select("foo");
            Mouse.Instance.Click(button.Bounds.Center(), MainWindow);
            Assert.NotEqual(label.Text, previousText);
        }

        protected override void ExecuteTestRun()
        {
            label = MainWindow.Get<Label>("status");
            RunTest(TestComboBox);
            RunTest(Get);
        }

        protected override System.Collections.Generic.IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.WebBrowserWindowRequirement);
        }
    }
}