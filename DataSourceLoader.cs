using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTest
{
    public static class DataSourceLoader
    {
        public static DataSource data = new DataSource();

        public static bool LoadDataSource()
        {
            try
            {
                // data.json file is located in the same path as the .exe file
                using (StreamReader reader = new StreamReader("data.json"))
                {
                    string jsonStr = reader.ReadToEnd();
                    JsonNode jsonObj = JsonNode.Parse(jsonStr);
                    foreach (JsonNode obj in (JsonArray)jsonObj["planets"])
                    {
                        // If any of the data is null, the data source is considered unreadable
                        data.Planets.Add(
                            new Planet(
                                (string)obj["name"],
                                int.Parse(obj["positionIndex"].ToString()),
                                double.Parse(obj["distanceFromEarth"].ToString()),
                                bool.Parse(obj["habitable"].ToString()),
                                int.Parse(obj["diameter"].ToString()),
                                int.Parse(obj["averageTemperature"].ToString()),
                                bool.Parse(obj["isDwarf"]!=null?obj["isDwarf"].ToString():"false"))); // for testing
                    }
                    foreach (JsonNode obj in (JsonArray)jsonObj["spacecrafts"])
                    {
                        data.Crafts.Add(
                            new SpaceCraft(
                                (string)obj["name"],
                                (string)obj["type"],
                                int.Parse(obj["capacity"].ToString()),
                                int.Parse(obj["maxTravelDistance"].ToString()),
                                bool.Parse(obj["gravityGenerator"].ToString()),
                                bool.Parse(obj["asteroidDeflector"].ToString())));
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                MessageBox.Show("Failed to load the data.\nUnable to run the program."
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
