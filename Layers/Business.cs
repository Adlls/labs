using System;
using System.Collections.Generic;
using lab.Models;

namespace lab.Layers
{
    public class Business
    {
        private List<Securities> records;
        private readonly DB db;

        public Business()
        {
            db = new DB();
            records = db.Datas;
        }



        public void add(string title, string status, int price, DateTime date)
        {
            db.create(new Securities { title = title, status = status, price = price, date = date });            
        }

        public void remove(Securities securities)
        {
            db.delete(securities);
        }

        public void remove(string id)
        {
            db.delete(id);
        }

        public void edit(string id, Securities securities)
        {
            db.update(id, securities);
        }

        public Securities show(string id) => db.get(id);
        

        public List<Securities> showAll() => db.get();
        

        public int getSecByTime(DateTime timeS, DateTime timeE, bool isBought)
        {          
            int sum = 0;
            var status = isBought ? "bought" : "sold";

            foreach (var item in records)
            {
                if (item.date.CompareTo(timeS) > 0 &&
                    item.date.CompareTo(timeE) < 0 &&
                    item.status.Trim() == status) { sum += item.price; }                               
            }

            return sum;
        }

    }
}
