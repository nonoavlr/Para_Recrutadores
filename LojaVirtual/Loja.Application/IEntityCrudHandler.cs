using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public interface IEntityCrudHandler<T>
    {
        public Task<T> Get (int ID);
        public Task<T[]> GetAll (int ID);
        public Task<int> Post (T entity);
        public Task<int> Put (T entity, string userID, int ID);
        public Task<int> Delete(string userID, int ID);
    }
}
