using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using Xunit;
using TestStack.White.UITests;

namespace TestStack.White.Modules.WinForm.UITests
{
    public class DataGridWinFormsTests : WhiteTestBase
    {
        protected Table DataGridWinFormsUnderTest { get; set; }

        protected override void ExecuteTestRun()
        {
            SelectDataGridTab();
            DataGridWinFormsUnderTest = MainWindow.Get<Table>(SearchCriteria.ByAutomationId("DataGridControl"));
            RunTest(CanGetAllItemsWinforms);
        }

        void CanGetAllItemsWinforms()
        {
            var rows = DataGridWinFormsUnderTest.Rows;
            Assert.Equal(3, rows.Count);
            var row1 = rows[0];
            Assert.Equal(3, row1.Cells.Count);
            Assert.Equal("1", row1.Cells[0].Value);
            Assert.Equal("Item1", row1.Cells[1].Value);
            Assert.Contains("Simple", (string)row1.Cells[2].Value);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Modules.WinForm.Requirements.DataGridRequirement);
        }

    }
}
