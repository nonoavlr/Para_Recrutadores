﻿using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public async Task<Order[]> GetAll(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Post(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Put(Order entity, string userID, int ID)
        {
            throw new NotImplementedException();
        }
    }
}
