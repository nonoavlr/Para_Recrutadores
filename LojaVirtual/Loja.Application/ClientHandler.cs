using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class ClientHandler : IEntityCrudHandler<Client>
    {
        private readonly IApplicationDbContext db;
        public ClientHandler(IApplicationDbContext db) => this.db = db;
        public async Task<int> Delete(string userID, int ID)
        {
            var clientDesative = db.Client.Where(c => c.ClientID == ID).FirstOrDefault();
            var clientAdmin = db.Client.Where(c => c.UserID == userID).FirstOrDefault();

            if(clientDesative.ToString() != "0" && clientAdmin.isAdmin == true)
            {
                clientDesative.isActive = false;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }

        public async Task<Client> Get(int ID)
        {               
            return await db.Client
                        .SingleOrDefaultAsync(c => c.ClientID == ID);
        }

        public async Task<Client[]> GetAll(int ID)
        {
            var isAdmin = db.Client.Where(c => c.ClientID == ID).FirstOrDefault();

            if(isAdmin.isAdmin == true)
            {
                return await db.Client
                        .Where(c => c.isActive == true)
                        .ToArrayAsync();
            }

            return null;
        }

        public async Task<int> Post(Client entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.Client.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Client newEntity, string userID, int ID)
        {
            var toAlter = await db.Client.Where(c => c.UserID == userID).FirstOrDefaultAsync();

            if(toAlter.ToString() != "0")
            {
                toAlter.BirthDate = newEntity.BirthDate;
                toAlter.Name = newEntity.Name ?? toAlter.Name;
                toAlter.LastName = newEntity.LastName ?? toAlter.LastName;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
