using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class OrderHandler : IEntityCrudHandler<Order>
    {
        private readonly IApplicationDbContext db;
        public OrderHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Delete(int userID, int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Order[]> GetAll(int userID)
        {
            throw new NotImplementedException();
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
