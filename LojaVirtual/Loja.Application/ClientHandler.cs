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
        public async Task<int> Delete(int userID, int ID)
        {
            var clientDesative = db.Client.Where(c => c.ClientID == ID).FirstOrDefault();
            var clientAdmin = db.Client.Where(c => c.ClientID == userID).FirstOrDefault();

            if(clientDesative.ToString() != "0" && clientAdmin.isAdmin == true)
            {
                clientDesative.isActive = false;
                return await Task.FromResult(0);
            }

            return await Task.FromResult(1);
        }

        public async Task<Client> Get(int ID)
        {               
            return await db.Client
                        .Include(p => p.Addresses)
                        .Include(p => p.Orders)
                        .SingleOrDefaultAsync(c => c.ClientID == ID);
        }

        public async Task<Client[]> GetAll(int userID)
        {
            return await db.Client
                        .Include(p => p.Addresses)
                        .Include(p => p.Orders)
                        .ToArrayAsync();
        }

        public Task<int> Post(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Put(int userID, int ID)
        {
            throw new NotImplementedException();
        }
    }
}
