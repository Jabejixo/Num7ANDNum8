﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JsonLib
{
    public class FileManager
    {
        public static void Serialize<T>(ObservableCollection<T> list, string fileName)
        {
            if (!File.Exists($"{fileName}.json"))
            {
                File.Create($"{fileName}.json");
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText($"{fileName}.json", $"\r\n{json}");
            }
            else
            {
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText($"{fileName}.json", $"\r\n{json}");
            }
        }


        public static ObservableCollection<T> Deserialization<T>(string fileName)
        {
            ObservableCollection<T> collection;
            if (!File.Exists($"{fileName}.json"))
            {
                File.Create($"{fileName}.json");
                return collection = new ObservableCollection<T>();
            }
            else
            {
                string info = File.ReadAllText($"{fileName}.json");
                collection = JsonConvert.DeserializeObject<ObservableCollection<T>>(info);
                return collection;
            }

        }
    }
}