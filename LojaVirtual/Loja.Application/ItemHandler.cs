using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class ItemHandler : IEntityCrudHandler<Item>
    {
        private readonly IApplicationDbContext db;
        public ItemHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Delete(string userID, int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Item[]> GetAll(string userID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Post(Item entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Put(Item entity, string userID, int ID)
        {
            throw new NotImplementedException();
        }
    }
}
