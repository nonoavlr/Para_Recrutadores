using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class AddressHandler : IEntityCrudHandler<Address>
    {
        private readonly IApplicationDbContext db;
        public AddressHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Delete(int userID, int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Address[]> GetAll(int userID)
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
