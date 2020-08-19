using Loja.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class ItemHandler : IEntityCrudHandler<Item>
    {
        private readonly IApplicationDbContext db;
        public ItemHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Delete(string userID, int ID)
        {
            var toDelete = await db.Item.Where(c => c.ItemID == ID).FirstOrDefaultAsync();
            db.Item.Remove(toDelete);
            return await db.SaveChangesAsync();
        }

        public async Task<Item> Get(int ID)
        {
            return await db.Item.Where(c => c.ItemID == ID)
                .Include(c => c.Order)
                .Include(c => c.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<Item[]> GetAll(string userID)
        {
            return await db.Item.Where(c => c.Order.Client.UserID == userID)
                .Include(c => c.Order)
                .Include(c => c.Product)
                .ToArrayAsync();
        }

        public async Task<int> Post(Item entity)
        {
            db.Item.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Item entity, string userID, int ID)
        {
            var toAlter = await db.Item.Where(c => c.ItemID == ID).FirstOrDefaultAsync();

            if(toAlter.ToString() != "0")
            {
                toAlter.Quantity = entity.Quantity;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
