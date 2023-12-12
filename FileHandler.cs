using System;
using System.Collections.Generic;
using System.IO;

namespace HomeTest
{
    public static class FileHandler
    {
        public static bool WriteDataToTextFile(string path, string obj)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    outputFile.Write(obj.ToString());
                }
            }
            catch (Exception e)
            {
                Console.Write($"Failed to write data.\n{e.Message}");
                return false;
            }
            return true;
        }

        public static Dictionary<string, object> ReadDataFromTextFile(string path)
        {
            Dictionary<string, object> obj = new Dictionary<string, object>();
            try
            {
                using (StreamReader inputFile = new StreamReader(path))
                {
                    var input = inputFile.ReadToEnd();
                    var items = input.Trim();
                    foreach (var item in items.Split('\n'))
                    {
                        var data = item.Split(':');
                        obj.Add(data[0].ToLower(), data[1]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"Failed to read data.\n{e.Message}");
                return null;
            }
            return obj;
        }

        public static bool CreateNewDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine($"The directory is created successfully.\n{di.CreationTimeUtc}");
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
            return true;
        }

        public static bool CheckDirectoryExists(string path)
        {
            try
            {
                if (!Directory.Exists(path)) 
                    return false;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return true;
        }

        public static bool CheckFileExists(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return false;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return true;
        }
    }
}
