using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.RepositoryInterfaces
{
    public interface ICrudOperation<T> 
    {
        public Task<T> GetById(string id);
        public Task<bool> Delete(T item);
        public Task<bool> Create(T item);
        public Task<IEnumerable<T>> GetByAttrubutes(object attrubutes);
    }
}
