using ShoesStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoesStore.DAL
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var stores = new List<Store>
            {
                new Store {
                    Id = 1,
                    Name = "First Store",
                    Address = "Funny Street"
                },
                new Store {
                    Id = 2,
                    Name = "Second Store",
                    Address = "Another Street"
                }
            };
            stores.ForEach(s => context.Stores.Add(s));

            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Name = "Puma",
                    Description = "Puma",
                    Price = 90,
                    total_in_shelf = 40,
                    total_in_vault = 50,
                    StoreId = 1,
                    Store = stores[0]
                },
                new Article
                {
                    Id = 2,
                    Name = "Adidas",
                    Description = "Adidas",
                    Price = 75.3,
                    total_in_shelf = 10,
                    total_in_vault = 20,
                    StoreId = 1,
                    Store = stores[0]

                },
                new Article
                {
                    Id = 3,
                    Name = "Nike",
                    Description = "Nike",
                    Price = 85.1,
                    total_in_shelf = 10,
                    total_in_vault = 20,
                    StoreId = 2,
                    Store = stores[1]
                }
            };

            articles.ForEach(a => context.Articles.Add(a));

            context.SaveChanges();
        }
    }
}