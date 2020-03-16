using WebArticle.Models;
using WebArticle.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace WebArticle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        // Create an instance of our ArticleService

        public ArticleController(ArticleService artServ)
        {
            _articleService = artServ;
        }
        // Constructor for the ArticleController

        [HttpGet]
        public ActionResult<List<Article>> Get() =>
            _articleService.GetAllArticles();
        // Query DB for all articles

        [HttpGet("{id:length(24)}")]
        public ActionResult<Article> Get(string id)
        {
            var foundArticle = _articleService.GetArticle(id);

            if (foundArticle == null)
            {
                return NotFound();
            }

            return foundArticle;
        }
        // Query DB for a single article

        [HttpPost]
        public ActionResult<Article> Create(Article newArticle)
        {
            _articleService.CreateArticle(newArticle);

            return CreatedAtRoute( "CreatedArticle", newArticle);
        }
        // Query DB to create a document of type Article

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(Article updateArticle)
        {
            var article = _articleService.GetArticle(updateArticle.Id);

            if (article == null)
            {
                return NotFound();
            }

            _articleService.UpdateArticle(updateArticle);

            return NoContent();
        }
        // Query the DB to update the parameters of an existing Article document

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var article = _articleService.GetArticle(id);

            if (article == null)
            {
                return NotFound();
            }

            _articleService.RemoveArticle(article.Id);

            return NoContent();
        }
        // Query the DB to remove an unwanted Article document
    }
}