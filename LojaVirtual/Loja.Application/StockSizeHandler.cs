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

        public Task<int> Delete(string userID, int ID)
        {
            throw new NotImplementedException();
        }

        public Task<StockSize> Get(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<StockSize[]> GetAll(int ID)
        {
            return await db.StockSize
                .ToArrayAsync();
        }

        public Task<int> Post(StockSize entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Put(StockSize entity, string userID, int ID)
        {
            throw new NotImplementedException();
        }
    }
}
