using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lab.Models
{
    public class Securities
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }

    }
}
