using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebArticle.Models
{
    public class Comment
    {
        [BsonElement("Author")]
        public string CommentAuthor { get; set; }

        [BsonElement("Date")]
        public string CommentDate { get; set; }

        [BsonElement("Body")]
        public string CommentBody { get; set; }
        
    }
}