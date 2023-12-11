using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeTest
{
    public partial class MainUserControl : CustomUserControl
    {
        private int maxPassenger;
        private List<string> selectedDests = new List<string>();
        private List<string> route = new List<string>();

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
            this.maxPassenger = 1;
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
                this.numTbx.Text = "1";
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            int cntNum = Int32.Parse(this.numTbx.Text);
            if (cntNum == 1) return;

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

        private void destBtn_Click(object sender, EventArgs e)
        {
            using (RouteForm routeForm = new RouteForm())
            {
                // Set location of RouteForm
                int x = this.ParentForm.Location.X + this.ParentForm.Width - 40;
                int y = this.ParentForm.Location.Y + 40;
                routeForm.Location = new Point(x, y);

                // Send planets list to RouteForm
                var planets = DataSourceLoader.data.Planets.Select(value => value.Name).ToList();
                var dests = this.destLbx.Items.OfType<string>().ToList();
                routeForm.LoadData(planets, dests);

                var result = routeForm.ShowDialog(this);
                if (result == DialogResult.Abort)
                {
                    MessageBox.Show(
                        "Failed to load data. Unable to open destination selection page."
                        , "Error"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                else if (result == DialogResult.OK)
                {
                    DisplaySelectedDestinations(routeForm.GetData());
                    ClearCalculatedRoute();
                }
            }
        }

        private void DisplaySelectedDestinations(List<string> selectedDests)
        {
            if (selectedDests == null || selectedDests.Count == 0)
            {
                MessageBox.Show(
                    "Failed to get data. " +
                    "Please try selecting destination again."
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            this.destLbx.Items.Clear();
            this.selectedDests.Clear();
            foreach (var dest in selectedDests)
            {
                this.destLbx.Items.Add(dest);
                this.selectedDests.Add(dest);
            }
        }

        private void ClearCalculatedRoute()
        {
            if (route != null) route.Clear();
            this.routeLbx.Items.Clear();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            CalculateRoute();
            DisplayCalculatedRoute();
        }

        private void CalculateRoute()
        {
            // Check if the spacecraft, number of passengers, and destinations are selected.
            if (this.craftCbx.SelectedItem == null || this.numTbx.Text == null || this.destLbx.Items.Count == 0)
            {
                MessageBox.Show(
                    "Cannot calculate the travel route. " +
                    "Please ensure all options are selected."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            // Calculate the best route
            route.Clear();
            var spacecraft = DataSourceLoader.data.Crafts.FirstOrDefault(x => x.Name == this.craftCbx.SelectedItem.ToString());
            int passengers = Int32.Parse(this.numTbx.Text);

            // Available travel distance of the selected spacecraft
            int travelDistance = spacecraft.Distance * spacecraft.Tank;
            if (passengers == spacecraft.Capacity)
                travelDistance = (int)(travelDistance * 0.7);

            // Calculate distance between planets
            int earthPosition = DataSourceLoader.data.Planets.FirstOrDefault(x => x.Name == "Earth").Position;

            // 1. Get distance from Earth to first planet
            var firstPoint = DataSourceLoader.data.Planets.FirstOrDefault(x => x.Name == this.selectedDests[0]);
            int sumDistance = firstPoint.Distance;
            if (!canTravelToNextPlanet(sumDistance+firstPoint.Distance, travelDistance, firstPoint.Name)) return;

            for (int i = 1; i < this.selectedDests.Count; i++)
            {
                // 2. Get distance between first planet and second planet
                var secondPoint = DataSourceLoader.data.Planets.FirstOrDefault(x => x.Name == this.selectedDests[i]);
                if ((earthPosition > firstPoint.Position && earthPosition > secondPoint.Position)
                    || (earthPosition < firstPoint.Position && earthPosition < secondPoint.Position))
                    sumDistance += Math.Abs(firstPoint.Distance - secondPoint.Distance);
                else if ((earthPosition < firstPoint.Position && earthPosition > secondPoint.Position)
                    || (earthPosition > firstPoint.Position && earthPosition < secondPoint.Position))
                    sumDistance += (firstPoint.Distance + secondPoint.Distance);
                else if (earthPosition == firstPoint.Position)
                    sumDistance += secondPoint.Distance;
                else if (earthPosition == secondPoint.Position)
                    sumDistance += firstPoint.Distance;

                // 3. Check the spacecraft can travel to the next planet
                if (!canTravelToNextPlanet(sumDistance+secondPoint.Distance, travelDistance, secondPoint.Name)) break;
                firstPoint = secondPoint;
            }
        }

        private bool canTravelToNextPlanet(int sum, int max, string planet)
        {
            if (sum < max)
            {
                route.Add(planet);
                return true;
            }
            else if (sum == max)
            {
                route.Add(planet);
                return false;
            }
            else
            {
                return false;
            }
        }

        private void DisplayCalculatedRoute()
        {
            if (this.route == null || this.route.Count == 0) return;

            this.routeLbx.Items.Clear();
            foreach (var route in this.route)
            {
                this.routeLbx.Items.Add(route);
            }
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save text Files";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.DefaultExt = "json";
            dialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                
            }
    }
}
