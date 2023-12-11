using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HomeTest
{
    public partial class RouteForm : CustomForm
    {
        public RouteForm()
        {
            InitializeComponent();
        }

        private void RouteForm_Load(object sender, EventArgs e)
        {
            if (destLbx.Items.Count == 0)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

            this.toolTip.SetToolTip(
                this.addBtn, 
                "Add the planets you want to travel to in sequence.\n" +
                "The planets you add will be displayed\nin the left component in the same order.");
        }

        public void LoadData(List<string> planets, List<string> destinations)
        {
            if (planets == null || planets.Count == 0) return;
            foreach (string planet in planets)
            {
                if (planet != null) destLbx.Items.Add(planet);
            }

            if (destinations == null) return;
            foreach (string dest in destinations)
            {
                if (dest != null) selectedLbx.Items.Add(dest);
            }
        }

        public List<string> GetData()
        {
            if (this.selectedLbx.Items.Count == 0) return null;
            return this.selectedLbx.Items.OfType<string>().ToList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string newItem = this.destLbx.SelectedItem.ToString();

            if (newItem == null)
            {
                MessageBox.Show(
                    "Please select a planet."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            if (this.selectedLbx.Items.Count == 0 && newItem == "Earth")
            {
                MessageBox.Show(
                    "Please select a different planet.\n" +
                    "This travel will start from Earth."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            // The last selected planet cannot be the same with the newly selected planet
            string selectedItem = this.selectedLbx.Items.Count == 0 ? null : this.selectedLbx.Items[this.selectedLbx.Items.Count - 1].ToString();
            if (newItem == selectedItem)
            {
                MessageBox.Show(
                    "Please select a different planet.\n" +
                    "The destination planet is the same as the department planet."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            this.selectedLbx.Items.Add(newItem);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedLbx.Items.Count == 0 || this.selectedLbx.SelectedItem == null) return;
            
            // It cannot be located on the same planet consecutively
            int selectedIndex = this.selectedLbx.SelectedIndex;
            if ((selectedIndex-1>=0 && selectedIndex+1<this.selectedLbx.Items.Count) &&
                (this.selectedLbx.Items[selectedIndex-1] == this.selectedLbx.Items[selectedIndex+1]))
            {
                MessageBox.Show(
                    "Cannot delete selected planet. " +
                    "Removing it makes department and destination the same."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }
            
            this.selectedLbx.Items.RemoveAt(selectedIndex);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okayBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedLbx.Items.Count == 0)
            {
                MessageBox.Show(
                    "Please select planets."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
