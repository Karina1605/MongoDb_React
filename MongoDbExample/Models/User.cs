using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace MongoDbExample.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("LogIn")]
        public string LogIn { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("Born")]
        public DateTime? Born { get; set; }

        [BsonDefaultValue(null)]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("ProfilePthotoPath")]
        public string ProfilePthotoPath { get; set; }

        [BsonDefaultValue(null)]
        public byte[] ProfilePhoto { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("SelfDescription")]
        public string SelfDescription { get; set; }

        public bool HasImage()
        {
            return ProfilePthotoPath != null;
        }
    }
}
