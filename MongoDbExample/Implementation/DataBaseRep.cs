using MongoDbExample.Models;
using MongoDbExample.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbExample.Implementation.CollectionImplementation;
namespace MongoDbExample.Implementation
{
    public class DataBaseRep : ISocialNetworkDataBase
    {
        public ICrudOperationFull<User> Users { get; private set; }
        public ICrudOperation<Post> Posts { get; private set; }

        public DataBaseRep(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("SocialNetworkExample");

            Users = new UserRepository(database.GetCollection<User>("Users"));
            Posts = new PostRepository(database.GetCollection<Post>("Posts"));
        }
    }
}
