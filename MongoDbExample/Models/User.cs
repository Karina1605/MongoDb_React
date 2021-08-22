using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace MongoDbExample.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string LogIn { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Firstname { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Born { get; set; }
        [BsonDefaultValue(null)]
        [BsonRepresentation(BsonType.String)]
        public string ProfilePthotoPath { get; set; }

        [BsonDefaultValue(null)]
        public byte[] ProfilePhoto { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string SelfDescription { get; set; }

        public bool HasImage()
        {
            return ProfilePthotoPath != null;
        }
    }
}
