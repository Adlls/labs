using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using lab.Models;

namespace lab
{
    public class Manipulationf
    {

        private readonly string json;
        private DB db;

        public Manipulationf()
        {
            db = new DB();
            json = DB.serialize();
        }

        public List<Securities> get() => DB.deserialize();

        public Securities get(string id)
        {
           List<Securities> list = DB.deserialize();
           foreach (var item in list) if (item.id == id) return item;            
           return null;
        }






    }
}
