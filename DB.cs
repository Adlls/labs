using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.IO;
using lab.Models;

namespace lab
{
    public class DB
    {

        private static class DBRecords
        {
            private static List<Securities> records;

            public static void findDoc()
            {
                records = new List<Securities>();
                var filter = new BsonDocument();
                var securities =  DB.collections.Find(filter).ToList();              

                foreach (Securities doc in securities) records.Add(doc);                
            }

            public static List<Securities> getRecords() => records;
            
        }

        private static IMongoCollection<Securities> collections;
        private static MongoClient client;
        private fs fs;
        public IMongoCollection<Securities> Collections { get => collections; }

        public DB()
        {
            DB.client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("labs");
            collections = database.GetCollection<Securities>("securities");
            DBRecords.findDoc();
            fs = new fs();
            serialize();           
        }


        public override string ToString() => serialize();

        public static string serialize()
        {
            string json = "";
            List<Securities> records = DBRecords.getRecords();

            foreach (var item in records) json += JsonSerializer.Serialize<Securities>(item) + "\n";

            File.WriteAllText("/Users/admin/Projects/lab/lab/serilize.json", json);
            return json;
        }

        public static List<Securities> deserialize()
        {
            List<Securities> list = new List<Securities>();
            string getJson = (File.ReadAllText("/Users/admin/Projects/lab/lab/serilize.json")).Trim();
            string[] json = getJson.Split("\n");

            foreach (var item in json) list.Add(JsonSerializer.Deserialize<Securities>(item));
            return list;
        }
    }
}
