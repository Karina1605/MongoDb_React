using MongoDbExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.RepositoryInterfaces
{
    public interface ICrudOperation<T> 
    {
        public Task<T> GetById(string id);
        public Task<bool> Delete(string Id);
        public Task<bool> Create(T item);
        public Task<IEnumerable<T>> GetByAttrubutes(IFilterAttributes attrubutes);
        public Task<bool> Update(T item);
    }
}
