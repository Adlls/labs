using System;
using System.Collections.Generic;
using lab.Models;

namespace lab.Layers
{
    public class User
    {
        static void Main(string[] args)
        {
                     
            Layers.DB db = new Layers.DB();
            // db.create(new Securities { title = "title", status = "bought", price = 1300, date = default });
            List<Securities> records = db.Datas;
            Console.WriteLine(records[0].date.CompareTo(records[2].date));
            

        }
    }
}
