using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.Filters
{
    public class PostFilter : IFilterAttributes
    {
        public string[] AuthorId;
        public DateTime? EarliestDate;
    }
}
