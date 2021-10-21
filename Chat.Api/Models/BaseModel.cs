using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Api.Models
{
    public class BaseModel : IBaseModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}