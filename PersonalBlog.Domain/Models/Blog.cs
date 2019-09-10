using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalBlog.Domain.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}