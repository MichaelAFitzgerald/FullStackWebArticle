namespace WebArticle.Models
{
    public class WebArticleDatabaseSettings : IArticleDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ArticleCollectionName { get; set; }
        
    }

    public interface IArticleDatabaseSettings {
        string ArticleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}