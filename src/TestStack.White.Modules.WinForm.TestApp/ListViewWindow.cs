using System;
using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class ListViewWindow : Form
    {
        public ListViewWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView.SelectedIndices.Count == 0) return;
            ListView.AccessibleDescription = "ListView item selected - " + ListView.SelectedIndices[0];
        }

        private void cmdDeleteRow_Click(object sender, EventArgs e)
        {
            ListView.Items.RemoveAt(0);
        }

        private void cmdAddRow_Click_1(object sender, EventArgs e)
        {
            var newItem = new ListViewItem() 
            {
                Text = "NewItem",
            };

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "NewSubItem" });


            ListView.Items.Add(newItem);
        }

    }
}
