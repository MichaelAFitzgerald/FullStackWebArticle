using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace WebArticle.Models
{
    public class Article
    {
        // This class will define the getters and setters for the Article objects being retrieved
        // from the MongoDB

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        // the native _Id string given to all objects created when inserting 
        // into Mongo

        public string Author { get; set; }

        public string Date { get; set; }
        // The date string as part of the Article object

        public string Title { get; set; }
        // The Title of the article

        public string Subtitle { get; set; }
        // The Subtitle of the article, if one exists

        public string Body { get; set; }
        // The body of the article
        // hopefully the formatting still holds up, if not I'll need to add \n and \t chars

        public List<Comment> ArticleComments { get; set; }
    }
}