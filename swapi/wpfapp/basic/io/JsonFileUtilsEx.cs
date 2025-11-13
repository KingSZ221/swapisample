using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.basic.io
{
    public class JsonFileUtilsEx
    {
        public static T ReadFromJsonFile<T>(string filePath)
        {
            if(!File.Exists(filePath))
            {
                return default(T);
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite)
        {
            string json = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
