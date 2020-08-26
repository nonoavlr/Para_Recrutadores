using Loja.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class DatabaseHandler : IEntityCrudHandler<Database>
    {
        private readonly IApplicationDbContext db;
        public DatabaseHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Delete(string userID, int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Database> Get(int ID)
        {
            return await db.Databases.Where(c => c.DatabaseID == ID).FirstOrDefaultAsync();
        }

        public Task<Database[]> GetAll(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Post(Database entity)
        {
            entity.CreatedOn = DateTime.Now;
            db.Databases.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Put(Database newEntity, string userID, int ID)
        {
            var isAdmin = await db.Client.Where(c => c.UserID == userID).FirstOrDefaultAsync();
            var toAlter = await db.Databases.Where(c => c.DatabaseID == ID).FirstOrDefaultAsync();

            if(isAdmin.isAdmin == true)
            {
                toAlter.Link = newEntity.Link ?? toAlter.Link;
                toAlter.Type = newEntity.Type ?? toAlter.Type;
                toAlter.LastModified = DateTime.Now;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(1);
        }
    }
}
