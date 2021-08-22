using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.Filters
{
    public class UserFilter : IFilterAttributes
    {
        public string Name;
        public string Lastname;
        public int? minAge;
        public int? maxAge;
    }
}
