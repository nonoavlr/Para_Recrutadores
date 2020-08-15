using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public interface IEntityCrudHandler<T>
    {
        public Task<T> Get (int ID);
        public Task<T[]> GetAll (int userID);
        public Task<int> Post (int userID);
        public Task<int> Put (int userID, int ID);
        public Task<int> Delete(int userID, int ID);
    }
}
