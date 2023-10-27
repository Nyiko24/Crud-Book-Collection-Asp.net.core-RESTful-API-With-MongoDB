using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CollectionOfBooks.Models
{
    public class BookCollection
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }

        [Required]
        [BsonRepresentation(BsonType.String)]
        public string Author { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Genre { get; set; } = null;

        [BsonRepresentation(BsonType.Int32)]
        public int? PublicationYear { get; set; } = null;

        [BsonRepresentation(BsonType.String)]
        public string ISBN { get; set; }

    }
}
