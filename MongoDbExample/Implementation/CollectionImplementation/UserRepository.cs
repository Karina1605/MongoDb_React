using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbExample.Models;
using MongoDbExample.RepositoryInterfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDbExample.Filters;

namespace MongoDbExample.Implementation.CollectionImplementation
{
    public class UserRepository : ICrudOperationFull<User>
    {
        private IMongoCollection<User> _users;
        public UserRepository(IMongoCollection<User> users)
        {
            _users = users;
        }

        public async Task<bool> Create(User item)
        {
            try
            {
                await _users.InsertOneAsync(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(User item)
        {
            try
            {
                await _users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(item.Id)));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetByAttrubutes(IFilterAttributes attrubutes)
        {
            var obj = attrubutes as UserFilter;
            if (obj == null)
                throw new Exception("Wrong filter");
            var buildier = new FilterDefinitionBuilder<User>();
            var filter = buildier.Empty;
            if (!String.IsNullOrEmpty(obj.Lastname))
                filter = filter & buildier.Regex("LastName", new BsonRegularExpression(obj.Lastname));
            if (!String.IsNullOrEmpty(obj.Name))
                filter = filter & buildier.Regex("FirstName", new BsonRegularExpression(obj.Name));
            DateTime today = DateTime.Now;
            if (obj.minAge!=null && obj.maxAge==null)
            {
                DateTime min = new DateTime(today.Year - (int)obj.minAge, today.Month, today.Day);
                filter = filter & buildier.Gte("Born", min);
            }
            if (obj.maxAge != null && obj.minAge==null)
            {
                DateTime max = new DateTime(today.Year - (int)obj.maxAge, today.Month, today.Day);
                filter = filter & buildier.Lte("Born", max);
            }
            else if (obj.maxAge != null && obj.minAge != null)
            {
                DateTime max = new DateTime(today.Year - (int)obj.minAge, today.Month, today.Day);
                DateTime min = new DateTime(today.Year - (int)obj.maxAge, today.Month, today.Day);
                filter = filter & buildier.Gte("Born", min) & buildier.Lte("Born", max);
            }
            return await _users.Find(filter).ToListAsync();
            
        }

        public async Task<User> GetById(string id)
        {
            return await _users.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(User item)
        {
            try
            {
                await _users.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(item.Id)), item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
