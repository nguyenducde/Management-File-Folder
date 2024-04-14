using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace managementFile.DTO
{
    public class UserDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
    }
}
