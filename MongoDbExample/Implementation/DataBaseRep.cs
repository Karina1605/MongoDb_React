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
        public ICrudOperation<User> Users { get; private set; }
        public ICrudOperation<Tweet> Posts { get; private set; }

        public DataBaseRep(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            var databases = client.ListDatabaseNames();
            var names = databases.ToList();
            var name = database.ListCollectionNames();
            var users = database.GetCollection<User>("Users");
            var posts = database.GetCollection<Tweet>("Tweets");
            Users = new UserRepository(users);
            Posts = new PostRepository(posts);
        }
    }
}
