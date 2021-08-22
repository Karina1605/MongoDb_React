using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.RepositoryInterfaces
{
    public interface ICrudOperationFull<T> :ICrudOperation<T>
    {
        public Task<T> Update(T item);
        public Task<IEnumerable<T>> GetByAttrubutes(object attrubutes);
    }
}
