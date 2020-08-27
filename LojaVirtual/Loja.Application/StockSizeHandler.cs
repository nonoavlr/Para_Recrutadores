using Loja.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class StockSizeHandler : IEntityCrudHandler<StockSize>
    {
        private readonly IApplicationDbContext db;
        public StockSizeHandler(IApplicationDbContext db) => this.db = db;

        public async Task<int> Delete(string userID, int ID)
        {
            var isAdmin = await db.Client.Where(c => c.UserID == userID).FirstOrDefaultAsync();
            if(isAdmin.isAdmin == true)
            {
                var toDelete = await db.StockSize.Where(c => c.StockSizeID == ID).FirstOrDefaultAsync();
                db.StockSize.Remove(toDelete);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }

        public async Task<StockSize> Get(int ID)
        {
            return await db.StockSize.Where(c => c.StockSizeID == ID).FirstOrDefaultAsync();
        }

        public async Task<StockSize[]> GetAll(int ID)
        {
            return await db.StockSize
                .ToArrayAsync();
        }

        public async Task<int> Post(StockSize entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.StockSize.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(StockSize entity, string userID, int ID)
        {
            var toAlter = await db.StockSize.Where(c => c.StockSizeID == ID).SingleOrDefaultAsync();
            var isAdmin = await db.Client.Where(c => c.UserID == userID).SingleOrDefaultAsync();

            if(isAdmin.isAdmin == true)
            {
                toAlter.Size = entity.Size ?? toAlter.Size;
                toAlter.Stock = entity.Stock;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
