using System;
using System.Collections.Generic;
using lab.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace lab.Layers
{
    public class DB
    {

        private IMongoCollection<Securities> collections;
        protected List<Securities> datas;
        private readonly lab.DB db;
        public List<Securities> Datas { get => datas; }       

        public DB()
        {
            db = new lab.DB();                         
            collections = db.Collections;
            lab.DB.serialize();
            datas = lab.DB.deserialize();            
        }

        public Securities create(Securities securities)
        {
            collections.InsertOne(securities);
            lab.DB.serialize();
            datas = lab.DB.deserialize();
            return securities;
        }

        public void update(string id, Securities securities)
        {
            
            collections.ReplaceOne(Securities => Securities.id == id, securities);
            lab.DB.serialize();
            datas = lab.DB.deserialize();
        }

        public void delete(Securities securities)
        {
            collections.DeleteOne(Securities => Securities.id == securities.id);
            lab.DB.serialize();
            datas = lab.DB.deserialize();
        }
        public void delete(string id)
        {
            collections.DeleteOne(Securities => Securities.id == id);
            lab.DB.serialize();
            datas = lab.DB.deserialize();
        }

        public List<Securities> get() => collections.Find(Securities => true).ToList();

        public Securities get(string id) => collections.Find(Securities => Securities.id == id).FirstOrDefault();

        

    }
}
