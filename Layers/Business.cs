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


        public int getSecByTime(DateTime timeS, DateTime timeE, bool isBought)
        {          
            int sum = 0;
            var status = isBought ? "bought" : "sold";

            foreach (var item in records)
            {
                if (item.date.CompareTo(timeS) > 0 &&
                    item.date.CompareTo(timeE) < 0 &&
                    item.status == status) { sum += item.price; }                               
            }

            return sum;
        }

    }
}
