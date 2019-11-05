using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    interface IRepository<T> where T : class
    {
        Task<ActionResult<IEnumerable<T>>>  GetAll();
        ActionResult<T> Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
    public class ItemRepository:IRepository<Item>
    {
        private ApiDbContext db;
        public ItemRepository(ApiDbContext context)
        {
            this.db = context;
        }

        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            return await db.Items.ToListAsync();
        }
        public ActionResult<Item> Get(int id)
        {
            return db.Items.Find(id);
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }
    }
    public class ShopRepository : IRepository<Shop>
    {
        private ApiDbContext db;

        public ShopRepository(ApiDbContext context)
        {
            this.db = context;
        }

        public async Task<ActionResult<IEnumerable<Shop>>> GetAll()
        {
            return await db.Shops.ToListAsync();
        }

        public ActionResult<Shop> Get(int id)
        {
            return db.Shops.Include(i => i.Items).FirstOrDefaultAsync(i => i.Id == id).Result;
        }

        public void Create(Shop shop)
        {
            db.Shops.Add(shop);
        }

        public void Update(Shop shop)
        {
            db.Entry(shop).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop != null)
                db.Shops.Remove(shop);
        }
    }

    public class UnitOfWork : IDisposable
    {
        private ApiDbContext db = new ApiDbContext(); 
        private ItemRepository itemRepository;
        private ShopRepository shopRepository;

        public ItemRepository Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }

        public ShopRepository Shops
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(db);
                return shopRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
