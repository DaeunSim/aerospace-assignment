using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTest
{
    public partial class MainUserControl : UserControl
    {
        private int maxPassenger;

        public MainUserControl()
        {
            InitializeComponent();
        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {
            //foreach (var spaceCraft in DataSourceLoader.data.Crafts
            //    .Select((value, index) => (value, index)))
            foreach (var spaceCraft in DataSourceLoader.data.Crafts)
            {
                this.craftCbx.Items.Add(spaceCraft.Name.ToString());
            }
            this.craftCbx.SelectedIndex = -1;
            this.maxPassenger = 0;
        }

        private void craftCbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Set the maximum number of passengers based on the selected spacecraft
            // craftCbx list order and SpaceCraft list order match so the below code can be used
            string selectedItem = this.craftCbx.Text;
            if (selectedItem != null)
            {
                int index = Int32.Parse(this.craftCbx.SelectedIndex.ToString());
                int maxCapacity = DataSourceLoader.data.Crafts[index].Capacity;
                
                this.maxPassenger = maxCapacity;
                this.numTbx.Text = "0";
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            int cntNum = Int32.Parse(this.numTbx.Text);
            if (cntNum == 0) return;

            cntNum--;
            this.numTbx.Text = cntNum.ToString();
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            int cntNum = Int32.Parse(this.numTbx.Text);
            if (cntNum == this.maxPassenger) return;

            cntNum++;
            this.numTbx.Text = cntNum.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm form)
            {
                form.ChangeToInitUserControl();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void destBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
