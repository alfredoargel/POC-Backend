using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace POC_Backend.Application.Entities
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;
        public string AnswerDesc { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
