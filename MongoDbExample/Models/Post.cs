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
        public string AuthorId { get; set; }

        [BsonDefaultValue(null)]
        public byte[] Photo { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public string[] Liked { get; set; }

        public bool HasImage()
        {
            return ContentMediaPath != null;
        }
    }
}
