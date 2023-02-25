using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace libraryAPI.Models;

[BsonIgnoreExtraElements]

public class Book {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string title { get; set; } = string.Empty;
    public string author { get; set; } = string.Empty;
    public int pages { get; set; }
    public int itemsAvailable { get; set; }
    public string ISBN { get; set; } = string.Empty;

}