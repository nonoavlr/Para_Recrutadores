using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class ProductHandler : IEntityCrudHandler<Product>
    {
        private readonly IApplicationDbContext db;
        public ProductHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Delete(string userID, int ID)
        {
            var toDelete = await db.Product.Where(c => c.Client.UserID == userID).FirstOrDefaultAsync();

            if(toDelete.ToString() != "0")
            {
                toDelete.isActive = false;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }

        public async Task<Product> Get(int ID)
        {
            return await db.Product
                .Where(c => c.ProductID == ID)
                .Include(c => c.Client)
                .Include(c => c.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<Product[]> GetAll(string userID)
        {
            return await db.Product
                .Include(c => c.Client)
                .Include(c => c.Items)
                .ToArrayAsync();
        }

        public async Task<int> Post(Product entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.Product.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Product newEntity, string userID, int ID)
        {
            var toAlter = await db.Product.Where(c => c.ProductID == ID && c.Client.UserID == userID).FirstOrDefaultAsync();

            if(toAlter.Client.isAdmin == true)
            {
                toAlter.Description = newEntity.Description ?? toAlter.Description;
                toAlter.Gender = newEntity.Gender ?? toAlter.Gender;
                toAlter.isActive = newEntity.isActive;
                toAlter.Name = newEntity.Name ?? toAlter.Name;
                toAlter.Price = newEntity.Price;
                toAlter.Stock = newEntity.Stock;
                toAlter.Title = newEntity.Title ?? toAlter.Title;
                toAlter.Type = newEntity.Type ?? toAlter.Type;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
