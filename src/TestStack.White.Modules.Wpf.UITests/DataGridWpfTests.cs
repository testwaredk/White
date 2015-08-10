using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.Wpf.UITests
{
    public class DataGridWpfTests : WhiteTestBase
    {
        protected ListView DataGridWpfUnderTest { get; set; }

        protected override void ExecuteTestRun()
        {
            SelectDataGridTab();
            DataGridWpfUnderTest = MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));
            RunTest(CanGetAllItemsWpf);
            RunTest(CanGetCellWpf);
        }

        void CanGetAllItemsWpf()
        {
            var rows = DataGridWpfUnderTest.Rows;
            Assert.Equal(3, rows.Count);
            var row1 = rows.Get(0);
            Assert.Equal(4, row1.Cells.Count);
            Assert.Equal("1", row1.Cells[0].Text);
            Assert.Equal("Item1", row1.Cells[1].Text);
            Assert.Contains("Simple", row1.Cells[2].Text);
        }

        void CanGetCellWpf()
        {
            Assert.Equal("Item1", DataGridWpfUnderTest.Cell("Contents", 0).Text);
            Assert.Equal("Item2", DataGridWpfUnderTest.Cell("Contents", 1).Text);
            Assert.Equal("Item3", DataGridWpfUnderTest.Cell("Contents", 2).Text);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Modules.Wpf.Requirements.DataGridRequirement);
        }

    }
}
