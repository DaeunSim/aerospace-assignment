﻿using System;
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
                    foreach (JsonNode obj in (JsonArray)jsonObj["planet"])
                    {
                        data.Planets.Add(
                            new Planet((string)obj["name"], Int32.Parse(obj["position"].ToString()), Int32.Parse(obj["distance"].ToString())));
                    }
                    foreach (JsonNode obj in (JsonArray)jsonObj["spacecraft"])
                    {
                        data.Crafts.Add(
                            new SpaceCraft((string)obj["name"], Int32.Parse(obj["capacity"].ToString()), Int32.Parse(obj["travel"].ToString()), Int32.Parse(obj["tank"].ToString())));
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write(e.ToString());
                MessageBox.Show(" Failed to load the data. Unable to run the program"
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
