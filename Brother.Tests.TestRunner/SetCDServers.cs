using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRunner
{
    public partial class SetCDServers : Form
    {
        
        public SetCDServers()
        {
            InitializeComponent();
        }

        private void SetCDServers_Load(object sender, EventArgs e)
        {

        }

        private void CancelServerSelection_Click(object sender, EventArgs e)
        {
            SelectCDServers.ClearSelected();
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void SetServers_Click(object sender, EventArgs e)
        {
            TestHelpers.ClearSelectedItems();
            var checkedItems = SelectCDServers.CheckedItems;
            if (checkedItems.Count > 0)
            {
                TestHelpers.SetSelectedItems(checkedItems);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void SelectCDServers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
