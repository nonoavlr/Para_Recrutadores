using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class OrderHandler : IEntityCrudHandler<Order>
    {
        private readonly IApplicationDbContext db;
        public OrderHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Delete(string userID, int ID)
        {

            throw new NotImplementedException();
        }

        public async Task<Order> Get(int ID)
        {
            return await db.Order.Where(c => c.OrderID == ID)
                .Include(c => c.Items)
                .Include(c => c.Client)
                .Include(c => c.AddressShip)
                .FirstOrDefaultAsync();
        }

        public async Task<Order[]> GetAll(int ID)
        {
            var isAdmin = await db.Client.Where(c => c.ClientID == ID).FirstOrDefaultAsync();

            if(isAdmin.isAdmin == true)
            {
                return await db.Order
                    .Include(c => c.Items)
                    .Include(c => c.Client)
                    .Include(c => c.AddressShip)
                    .ToArrayAsync();
            }

            return await db.Order.Where(c => c.Client.ClientID == ID)
                    .Include(c => c.Items)
                    .Include(c => c.Client)
                    .Include(c => c.AddressShip)
                    .ToArrayAsync();
        }

        public async Task<int> Post(Order entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.Order.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Order entity, string userID, int ID)
        {
            var toAlter = await db.Order.Where(c => c.OrderID == ID).FirstOrDefaultAsync();

            if(toAlter.ToString() != "0")
            {
                toAlter.Items = entity.Items;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
