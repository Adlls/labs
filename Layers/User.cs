using System;
using System.Collections.Generic;
using lab.Models;
using lab.enums;

namespace lab.Layers
{
    public class User
    {
        static void Main(string[] args)
        {
            User user = new User();
            Business business = new Business();
            DB DB = new DB();
            //business.edit("5e1965dfecc25f4ffe7441f5", new Securities { title = "t", status = "sold", price = 555, date = DateTime.Now });
            //DB.update("5e1965dfecc25f4ffe7441f5", new Securities { id = "5e1965dfecc25f4ffe7441f5", title = "t", status = "sold", price = 555, date = DateTime.Now });

            while (true)
            {
                user.displayMenu();
                Console.WriteLine();
                Console.Write("Enter options > ");
                int options = Convert.ToInt32(Console.ReadLine());

                string title;
                string status;
                string id;
                int price;
                List<Securities> list;
                switch (options)
                {

                    case 1:
                        Console.Write("Enter title > ");
                        title = Console.ReadLine().Trim();
                        Console.Write("Enter status > ");
                        status = Console.ReadLine().Trim();
                        Console.Write("Enter price > ");
                        price = Convert.ToInt32(Console.ReadLine());
                        business.add(title, status, price, DateTime.Now);
                        break;

                    case 2:
                        Console.Write("Enter id > ");
                        id = Console.ReadLine().Trim();
                        business.remove(id);
                        break;

                    case 3:
                        try
                        {
                            Console.Write("Enter id > ");
                            id = Console.ReadLine().Trim();
                            Console.Write("Enter title > ");
                            title = Console.ReadLine().Trim();
                            Console.Write("Enter status > ");
                            status = Console.ReadLine().Trim();
                            Console.Write("Enter price > ");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter date y m d > ");
                            string[] date = Console.ReadLine().Split(" ");
                            DateTime dateIn = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]) + 1);                            
                            business.edit(id, new Securities {id = id, title = title, status = status, price = price, date = dateIn });
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Error: " + e);
                        }
                        break;
                    
                    case 4:
                        Console.Write("Enter id > ");
                        id = Console.ReadLine().Trim();
                        try
                        {
                            Securities securities = business.show(id);
                            Console.WriteLine();
                            Console.WriteLine(securities.id + " " + securities.title + " " + securities.status + " " + securities.price + " " + securities.date);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Not found 404");
                        }
                        Console.WriteLine();
                        break;

                    case 5:
                        list = business.showAll();
                        Console.WriteLine();
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.id + " " + item.title + " " + item.status + " " + item.price + " " + item.date);
                            Console.WriteLine();
                        }
                        break;

                    case 6:
                        Console.Write("Enter start date y m d > ");
                        string[] dateS = Console.ReadLine().Split(" ");
                        Console.WriteLine();
                        Console.Write("Enter end date y m d > ");
                        string[] dateE = Console.ReadLine().Split(" ");
                        DateTime datS = new DateTime(Convert.ToInt32(dateS[0]), Convert.ToInt32(dateS[1]), Convert.ToInt32(dateS[2]));
                        DateTime datE = new DateTime(Convert.ToInt32(dateE[0]), Convert.ToInt32(dateE[1]), Convert.ToInt32(dateE[2]));
                        Console.Write("Enter status ([y (is bought)]/[n (is sold)]) > ");
                        status = Console.ReadLine().Trim();
                        Console.Write("Enter title > ");
                        title = Console.ReadLine().Trim();
                        while (true)
                        {
                            if (status != "y" && status != "n")
                            {
                                Console.WriteLine("Incorrect status");
                                Console.Write("Enter status ([y (is bought)]/[n (is sold)]) > ");
                                status = Console.ReadLine().Trim();
                            }
                            else
                            {
                                break;
                            }
                        }
                        bool isBoutht = status == "y";
                        Console.WriteLine(business.getSecByTime(datS, datE, isBoutht, title));
                        break;
                    default:
                        Console.WriteLine("Incorrect option");
                        break;
                }
            }

        }

        public void displayMenu()
        {
            foreach (int i in Enum.GetValues(typeof(Menu))) Console.WriteLine(i + ". - " + ((Menu)Enum.GetValues(typeof(Menu)).GetValue(i - 1)));
        }
    }
}
