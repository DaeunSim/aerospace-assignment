using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTest
{
    public partial class MainUserControl : CustomUserControl
    {
        private int maxPassenger;
        private List<string> selectedDests = new List<string>();

        public MainUserControl()
        {
            InitializeComponent();
        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {
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
            using (RouteForm routeForm = new RouteForm())
            {
                // Set location of RouteForm
                int x = this.ParentForm.Location.X + this.ParentForm.Width - 40;
                int y = this.ParentForm.Location.Y + 40;
                routeForm.Location = new Point(x, y);

                // Send planets list to RouteForm
                routeForm.LoadData(DataSourceLoader.data.Planets.Select(value => value.Name).ToList());
                var result = routeForm.ShowDialog(this);
                if (result == DialogResult.Abort)
                {
                    Console.Write("Failed to set destination data to the listbox in RouteForm");
                    MessageBox.Show(" Failed to load data. Unable to open destination selection page."
                        , "Error"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                else if (result == DialogResult.OK)
                {
                    DisplaySelectedDestinations(routeForm.GetData());
                }
            }
        }

        private void DisplaySelectedDestinations(List<string> selectedDests)
        {
            if (selectedDests == null)
            {
                MessageBox.Show(
                    "Failed to calculate the travel route. " +
                    "Please try to select destination again."
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            this.destLbx.Items.Clear();
            foreach (var dest in selectedDests)
            {
                this.destLbx.Items.Add(dest);
            }
        }

        private void CalculateRoute()
        {
            // Save the selected destinations to the string list.
            //if (this.selectedDests == null) this.selectedDests = new List<string>();
            //this.selectedDests.Clear();
            //this.selectedDests = selectedDests;

            // Check if the spacecraft and number of passengers are selected.
            if (this.craftCbx.SelectedItem != null || this.numTbx.Text != null)
            {
                MessageBox.Show(
                    "Cannot be calculated the travel route. " +
                    "Please check to be chosen the spacecraft and number of passengers."
                    , "Info"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                return;
            }

            // Calculate the best route
        }
    }
}
