using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
                        "Failed to load data.\n" +
                        "Unable to open destination selection page."
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
                    "Failed to get data.\n" +
                    "Please try selecting destinations again."
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            ClearSelectedDestination();
            foreach (var dest in selectedDests)
            {
                this.destLbx.Items.Add(dest);
                this.selectedDests.Add(dest);
            }
        }

        private void ClearCalculatedRoute()
        {
            if (this.route != null) this.route.Clear();
            this.routeLbx.Items.Clear();
        }

        private void ClearSelectedDestination()
        {
            if (this.selectedDests != null) this.selectedDests.Clear();
            this.destLbx.Items.Clear();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            CalculateRoute();
            DisplayCalculatedRoute();
        }

        private void CalculateRoute()
        {
            // Check spacecraft, number of passengers, and destinations are selected.
            if (this.craftCbx.SelectedItem == null || this.numTbx.Text == null || this.destLbx.Items.Count == 0)
            {
                MessageBox.Show(
                    "Cannot calculate the travel route.\n" +
                    "Please ensure all options are selected."
                    , "Warning"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            // Calculate the travel route
            route.Clear();
            var spacecraft = DataSourceLoader.data.Crafts.FirstOrDefault(x => x.Name == this.craftCbx.SelectedItem.ToString());
            int passengers = Int32.Parse(this.numTbx.Text);

            // Calculate available travel distance of the selected spacecraft
            int travelDistance = spacecraft.Distance * spacecraft.Tank;
            if (passengers == spacecraft.Capacity)
                travelDistance = (int)(travelDistance * 0.7);

            // Get distance from Earth to first planet
            int earthPosition = DataSourceLoader.data.Planets.FirstOrDefault(x => x.Name == "Earth").Position;
            var firstPoint = DataSourceLoader.data.Planets.FirstOrDefault(x => x.Name == this.selectedDests[0]);
            int sumDistance = firstPoint.Distance;
            
            // Check the spacecraft can travel to the next planet
            if (!canTravelToNextPlanet(sumDistance+firstPoint.Distance, travelDistance, firstPoint.Name)) return;

            for (int i = 1; i < this.selectedDests.Count; i++)
            {
                // Get distance between first planet and second planet
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

                // Check the spacecraft can travel to the next planet
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

        /*
         * Route file format
         * 
         * SPACECRAFT: 
         * PASSENGERS:
         * DESTINATIONS: 
         * ROUTE:
         */
        private string GetDataFromControls()
        {
            if (this.craftCbx.SelectedItem == null || this.destLbx.Items == null || this.routeLbx.Items == null) return null;

            var str = $"SPACECRAFT:{this.craftCbx.SelectedItem}\n";
            str += $"PASSENGERS:{this.numTbx.Text}\n";
            str += $"DESTINATIONS:{string.Join(",", this.destLbx.Items.OfType<string>().ToArray())}\n";
            str += $"ROUTE:{string.Join(",", this.routeLbx.Items.OfType<string>().ToArray())}";
            return str;
        }

        public void SetDataToControls(Dictionary<string, object> data)
        {
            if (data == null || data == null || data.Count == 0) return;

            string name = (string)data["spacecraft"];
            if (name != null && DataSourceLoader.data.Crafts.Any(c => c.Name == name)) 
                this.craftCbx.SelectedItem = name;

            int passengers = Int32.Parse((string)data["passengers"]);
            var craft = DataSourceLoader.data.Crafts.FirstOrDefault<SpaceCraft>(c => c.Name == name);
            if (passengers == 0 || craft == null) return;

            maxPassenger = craft.Capacity;
            if (passengers <= maxPassenger)
                this.numTbx.Text = passengers.ToString();

            string dests = (string)data["destinations"];
            if (dests == null) return;

            ClearSelectedDestination();
            foreach (var dest in dests.Split(','))
            {
                if (DataSourceLoader.data.Planets.Any(p => p.Name == dest))
                {
                    this.selectedDests.Add(dest);
                    this.destLbx.Items.Add(dest);
                }
            }

            string route = (string)data["route"];
            if (route == null) return;

            ClearCalculatedRoute();
            foreach (var planet in route.Split(','))
            {
                if (DataSourceLoader.data.Planets.Any(p => p.Name == planet))
                {
                    this.route.Add(planet);
                    this.routeLbx.Items.Add(planet);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Check if all forms are filled and get data from controls
                string content = GetDataFromControls();
                if (content == null)
                    throw new Exception("Not all forms are filled.");

                // 2. Create Route directory in the folder where this app is located
                var app = Application.StartupPath;
                var dir = Path.Combine(app, "Route");
                if (!FileHandler.CreateNewDirectory(dir))
                    throw new Exception("Failed to create Route directory.");

                // 3. Save the travel route into a text file
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.InitialDirectory = dir;
                    dialog.Title = "Save the travel route";
                    dialog.DefaultExt = "text";
                    dialog.Filter = "txt files (*.txt)|*.txt";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string file = Path.Combine(dir, dialog.FileName);
                        if (!FileHandler.WriteDataToTextFile(file, content))
                            throw new Exception("Failed to save data into the text file.");

                        MessageBox.Show(
                            "The travel route is saved successfully."
                            , "Info"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cannot save the travel route.\n" +
                    ex.Message
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }
    }
}
