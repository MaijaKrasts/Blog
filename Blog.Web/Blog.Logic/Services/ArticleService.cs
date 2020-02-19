using Blog.Data.Entities;
using Blog.Data.Repositories.Interfaces;
using Blog.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Logic.Services
{
    public class ArticleService
    {
        private IArticleRepository _article;
        private ICommentService _commentService;

        public ArticleService(IArticleRepository article, ICommentService commentService)
        {
            _article = article;
            _commentService = commentService;
        }

        public List<Article> GetAll()
        {
            return _article.GetAll();
        }

        public Article Get(int id)
        {
            return _article.Get(id);
        }
        public List<Article> GetAllByDate()
        {
            return _article.GetAll()
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
        }

        public List<Article> GetNumOf(int num)
        {
            var latestArticle = GetLatest();
            return _article.GetAll()
                    .Where(a => a.Id != latestArticle.Id)
                    .Take(num)
                    .ToList();
        }

        public List<Article> GetHighestRated(int num)
        {
            return _article.GetAll()
                    .OrderByDescending(i => i.Rating)
                    .Take(num)
                    .ToList();
        }

        public Article GetLatest()
        {
            return GetAllByDate()[0];
        }

        public List<Article> GetUserArticles(int id)
        {
            return _article.GetAll().Where(a => a.AuthorId == id)
                    .ToList();
        }

        public Article ChangeRating(int id, int rateValue)
        {
            var article = _article.Get(id);
            if (rateValue == 1)
            {
                article.Rating++;
            }
            else if (rateValue == 0)
            {
                article.Rating--;
            }
            _article.Update(article);

            return article;
        }

        public List<Article> GetLastCommented(int num)
        {
            var allCommentsDesc = _commentService.GetLatest();
            List<Article> allLatestCommentArticles = new List<Article>();

            foreach (var comment in allCommentsDesc)
            {
                var article = _article.Get(comment.ArticleId);

                if (!allLatestCommentArticles.Contains(article))
                {
                    allLatestCommentArticles.Add(article);
                }
            }

            allLatestCommentArticles.Reverse();

            return allLatestCommentArticles
                   .Take(num)
                   .ToList();
        }

        public void DeleteWithComments(int Id)
        {
            var comments = _commentService.GetAll().Where(c => c.ArticleId == Id).ToList();

            foreach (var comment in comments)
            {
                _commentService.Delete(comment.Id);
            }

            _article.Delete(Id);
        }
    }
}
