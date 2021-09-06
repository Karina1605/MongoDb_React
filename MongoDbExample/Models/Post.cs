using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDbExample.Models
{
    public class Post
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TweetDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ContentText { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ContentMediaPath { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
<<<<<<< Updated upstream
        public string Author { get; set; }

        [BsonRepresentation(BsonType.Array)]
=======
        public string AuthorId { get; set; }

>>>>>>> Stashed changes
        public string[] Liked { get; set; }

        public bool HasImage()
        {
            return ContentMediaPath != null;
        }
    }
}
