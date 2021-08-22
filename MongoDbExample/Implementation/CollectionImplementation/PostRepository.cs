using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbExample.Filters;
using MongoDbExample.Models;
using MongoDbExample.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.Implementation.CollectionImplementation
{
    public class PostRepository : ICrudOperation<Post>
    {
        private IMongoCollection<Post> _posts;
        public PostRepository(IMongoCollection<Post> posts)
        {
            _posts = posts;
        }

        public async Task<bool> Create(Post item)
        {
            try
            {
                await _posts.InsertOneAsync(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Post item)
        {
            try
            {
                await _posts.DeleteOneAsync(new BsonDocument("_id", new ObjectId(item.Id)));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Post>> GetByAttrubutes(IFilterAttributes attrubutes)
        {
            var obj = attrubutes as PostFilter;
            if (obj == null)
                throw new Exception("Wrong filter");
            var buildier = new FilterDefinitionBuilder<Post>();
            var filter = buildier.Empty;
            DateTime today = DateTime.Now;
            if (obj.EarliestDate != null)
            {
                filter = filter & buildier.Gte("Date", obj.EarliestDate);
            }
            if (obj.AuthorId!=null && obj.AuthorId.Length > 0)
            {
                foreach(var s in obj.AuthorId)
                {
                    filter = filter & buildier.Eq("AuthorId", s);
                }
            }
            return await _posts.Find(filter).ToListAsync();

        }

        public async Task<Post> GetById(string id)
        {
            return await _posts.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Post item)
        {
            try
            {
                await _posts.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(item.Id)), item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
