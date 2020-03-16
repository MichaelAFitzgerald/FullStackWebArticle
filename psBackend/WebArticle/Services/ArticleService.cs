using WebArticle.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebArticle.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<Article> _articles;
        // The collection of the articles in the DB

        public ArticleService(IArticleDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articles = database.GetCollection<Article>(settings.ArticleCollectionName);
        }
        // Constructor for this service

        public List<Article> GetAllArticles() =>
            _articles.Find(art => true).ToList();
        // Return all articles in the DB

        public Article GetArticle(string id) =>
            _articles.Find<Article>(art => art.Id == id).FirstOrDefault();
        // Return a specific article

        public Article CreateArticle(Article newArticle) {
            _articles.InsertOne(newArticle);
            return newArticle;
        }
        // Create a new Article
        // Not needed at the moment

        public void UpdateArticle(Article changeArticle) =>
            _articles.ReplaceOne(art => art.Id == changeArticle.Id, changeArticle);
        // Update an existing article

        public void RemoveArticle(Article badArticle) =>
            _articles.DeleteOne(art => art.Id == badArticle.Id);
        // Remove an article by passing the article itself

        public void RemoveArticle(string id) =>
            _articles.DeleteOne(art => art.Id == id);
        // Remove an article by the id
        
    }
}