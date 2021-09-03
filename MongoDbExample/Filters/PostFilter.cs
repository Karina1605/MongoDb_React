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

        public PostFilter SetAuthors(string[] Authors)
        {
            AuthorId = Authors;
            return this;
        }
        public PostFilter SetEarliest(DateTime? date)
        {
            EarliestDate = date;
            return this;
        }
        public PostFilter GetObj => this;
    }
}
