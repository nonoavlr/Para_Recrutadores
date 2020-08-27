using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class AddressHandler : IEntityCrudHandler<Address>
    {
        private readonly IApplicationDbContext db;
        public AddressHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Delete(string userID, int ID)
        {
            var toDelete = await  db.Address.Where(c => c.AddressID == ID).FirstOrDefaultAsync();
            
            if(toDelete.ToString() != "0" && toDelete.Client.UserID == userID)
            {
                toDelete.isActive = false;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }

        public async Task<Address> Get(int ID)
        {
            return await db.Address.Where(c => c.AddressID == ID && c.Client.isActive == true)
                .FirstOrDefaultAsync();
        }

        public async Task<Address[]> GetAll(int ID)
        {
            var isAdmin = await db.Client.Where(c => c.ClientID == ID && c.isAdmin == true).FirstOrDefaultAsync();

            if (isAdmin.ToString() != "0")
            {
                return await db.Address
                    .Where(c => c.Client.isActive == true)
                    .ToArrayAsync();
            }

            return null;
        }

        public async Task<int> Post(Address entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.Address.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Address newEntity, string userID, int ID)
        {
            var toAlter = await db.Address.Where(c => c.AddressID == ID && c.Client.UserID == userID).FirstOrDefaultAsync();

            if(toAlter.ToString() != "0")
            {
                toAlter.AddressName = newEntity.AddressName ?? toAlter.AddressName;
                toAlter.AddressType = newEntity.AddressType ?? toAlter.AddressType;
                toAlter.City = newEntity.City ?? toAlter.City;
                toAlter.Complemention = newEntity.Complemention ?? toAlter.Complemention;
                toAlter.Country = newEntity.Country ?? toAlter.Country;
                toAlter.District = newEntity.District ?? toAlter.District;
                toAlter.Number = newEntity.Number ?? toAlter.Number;
                toAlter.State = newEntity.Number ?? toAlter.Number;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
