using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using lab.Models;

namespace lab
{
    public  class fs
    {
       public static string serialize(List<Securities> records)
       {
            string json = "";
            foreach (var item in records) json += JsonSerializer.Serialize<Securities>(item) + "\n";
            File.WriteAllText("/Users/admin/Projects/lab/lab/serilize.json", json);
            Console.WriteLine(json);
            return json;
       }

       public static List<Securities> deserialize()
       {
            List<Securities> list = new List<Securities>();
            string getJson = File.ReadAllText("/Users/admin/Projects/lab/lab/serilize.json").Trim();
            string[] json = getJson.Split("\n");

            foreach (var item in json) list.Add(JsonSerializer.Deserialize<Securities>(item));
            return list;
        }

    }
}
