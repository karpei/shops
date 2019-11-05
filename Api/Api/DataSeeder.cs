using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class DataSeeder
    {
        public static void SeedShops(Models.ApiDbContext context)
        {
            if (!context.Shops.Any())
            {
                var countries = new List<Models.Shop>
                {
                    new Models.Shop { Name = "АШАН",Adress="Притыцкого 60/2",WHours="8.30:21.00"},
                    new Models.Shop { Name = "АТБ",Adress="Якубова 17",WHours="8.00:23.00"},
                    new Models.Shop { Name = "21 ВЕК",Adress="Победителей 2",WHours="7.30:24.00"},
                    new Models.Shop { Name = "ЕВРООПТ",Adress="Вернадцкого 15",WHours="8.30:21.00"},
                    new Models.Shop { Name = "СОСЕДИ",Adress="Колесникова 5",WHours="8.30:21.00"},
                };
                context.AddRange(countries);
                context.SaveChanges();
            }
        }
        public static void SeedItems(Models.ApiDbContext context)
        {
            if (!context.Items.Any())
            {
                List<Models.Item> items = new List<Models.Item>();
                for(int i = 1; i < 5; i++)
                {
                    items.Add(new Models.Item { Name = "Apple", Description = "macbook air 13 2017", ShopId = i });
                    items.Add(new Models.Item { Name = "Iphone X", Description = "Iphone X", ShopId = i });
                    items.Add(new Models.Item { Name = "Meizu", Description = "meizu m6t", ShopId = i });
                }
                context.AddRange(items);
                context.SaveChanges();
            }
        }
    }
}
