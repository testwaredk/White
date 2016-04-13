using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class ListViewTest : WhiteTestBase
    {
        protected ListView GetListViewControl() { return MainScreen.GetListViewWindowScreen().GetListViewControl();  }
        protected Button GetDeleteButton() { return MainScreen.GetListViewWindowScreen().GetDeleteButton();  }
        protected int GetExpectedColumnCount() { return MainScreen.GetListViewWindowScreen().GetExpectedColumnCount(); }

        protected override void ExecuteTestRun()
        {
            RunTest(DeleteRows);
            RunTest(SelectRow); // OK
            RunTest(SelectedRow); // OK
            RunTest(Columns); // OK
            RunTest(CellCount); // OK
            RunTest(CellText); // OK
            RunTest(RowCount);
            RunTest(MultiSelect);
            RunTest(SelectBasedOnCell);
            RunTest(SelectScrolledRow);
            RunTest(SelectedRows);
        }

        void SelectRow()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Select(0);
                ListViewRow firstRow = listView.Rows[0];
                Assert.Equal(true, firstRow.IsSelected);
                //Assert.Equal("ListView item selected - " + 0, listView.HelpText);
                listView.Select(1);
                ListViewRow secondRow = listView.Rows[1];
                Assert.Equal(true, secondRow.IsSelected);
            }
        }
        void SelectScrolledRow()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Select("Key", "Action15");
                Assert.Equal("App15", listView.SelectedRows[0].Cells["Value"].Text);
            }
        }
        void SelectedRow()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Select(2);
                ListViewRow listViewRow = listView.SelectedRows[0];
                Assert.Equal("Picture", listViewRow.Cells["Key"].Text);
            }
        }

        void SelectBasedOnCell()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Select("Key", "Mail");
                Assert.Equal("Mail", listView.SelectedRows[0].Cells["Key"].Text);
            }
        }

        void Columns()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                ListViewColumns columns = listView.Header.Columns;
                Assert.Equal(GetExpectedColumnCount(), columns.Count);
                Assert.Equal("Key", columns[0].Name);
                Assert.Equal("Value", columns[1].Name);
            }
        }

        void RowCount()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                Assert.Equal(18, listView.Rows.Count);
            }
        }

        void CellCount()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                ListViewRow row = listView.Rows[0];
                Assert.Equal(GetExpectedColumnCount(), row.Cells.Count);
            }
        }

        void CellText()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                ListViewRow first = listView.Rows[0];
                Assert.Equal("Search", first.Cells[0].Text);
                Assert.Equal("Google", first.Cells[1].Text);
                ListViewRow second = listView.Rows[1];
                Assert.Equal("Mail", second.Cells[0].Text);
                Assert.Equal("GMail", second.Cells[1].Text);
            }
        }

        void SelectedRows()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Rows[2].Select();
                listView.Rows[0].Select();
                ListViewRows rows = listView.SelectedRows;
                Assert.Equal(1, rows.Count);
            }
        }

        void MultiSelect()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                listView.Rows[0].Select();
                listView.Rows[1].MultiSelect();
                Assert.Equal(2, listView.SelectedRows.Count);
            }
        }

        public void SelectWhenHorizontalScrollIsPresent()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListViewWithHorizontalScroll");
                listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre")
                    .Select();
            }
        }

        /// <summary>
        /// The Rows object should update so that none of the deleted rows are represented in the object
        /// </summary>
        public void DeleteRows()
        {
            using (var window = StartScenarioListView())
            {
                var listView = GetListViewControl();
                int countRows = listView.Rows.Count;

                listView.Rows[0].Select();
                GetDeleteButton().Click();
                

                Assert.Equal(countRows-1, listView.Rows.Count);
            }
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.ListControls.ListViewRequirement);
        }

    }
}