using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.Filters
{
    public class UserFilter : IFilterAttributes
    {
        public string Name;
        public string LastName;
        public int? minAge;
        public int? maxAge;

        public UserFilter SetName(string name)
        {
            Name = name;
            return this;
        }
        public UserFilter SetLastName (string lastName)
        {
            LastName = lastName;
            return this;
        }
        public UserFilter SetMinAge(int? minAge)
        {
            this.minAge = minAge;
            return this;
        }
        public UserFilter SetMaxAge(int? maxAge)
        {
            this.maxAge = maxAge;
            return this;
        }
        public UserFilter GetObj => this;
    }
}
