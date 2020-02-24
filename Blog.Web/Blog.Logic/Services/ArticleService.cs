using Blog.Data.Repositories.Interfaces;
using Blog.Data.Entities.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Blog.Logic.Const.Parameters;

namespace Blog.Data.Entities.Services
{
    public class ArticleService :IArticleService
    {
        private IArticleRepository _articleRepository;
        private ICommentService _commentService;

        public ArticleService(IArticleRepository articleRepository, ICommentService commentService)
        {
            _articleRepository = articleRepository;
            _commentService = commentService;
        }
        public Article Create(Article article)
        {
           return _articleRepository.Create(article);
        }

        public List<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }

        public void Update(Article article)
        {
           _articleRepository.Update(article);
        }
        public List<Article> GetAllByDate()
        {
            return _articleRepository.GetAll()
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
        }

        public List<Article> GetNumOf(int num)
        {
            var latestArticle = GetLatest();
            return _articleRepository.GetAll()
                    .Where(a => a.Id != latestArticle.Id)
                    .Take(num)
                    .ToList();
        }

        public List<Article> GetHighestRated(int num)
        {
            return _articleRepository.GetAll()
                    .OrderByDescending(i => i.Rating)
                    .Take(num)
                    .ToList();
        }

        public Article GetLatest()
        {
            return GetAllByDate()[Values.Zero];
        }

        public List<Article> GetUserArticles(int id)
        {
            return _articleRepository
                .GetAll()
                .Where(a => a.AuthorId == id)
                    .ToList();
        }

        public Article ChangeRating(int id, int rateValue)
        {
            var article = _articleRepository.Get(id);
            if (rateValue == Values.One)
            {
                article.Rating++;
            }
            else if (rateValue == Values.Zero)
            {
                article.Rating--;
            }
            _articleRepository.Update(article);

            return article;
        }

        public List<Article> GetLastCommented(int num)
        {
            var allCommentsDesc = _commentService.GetLatest();
            List<Article> allLatestCommentArticles = new List<Article>();

            foreach (var comment in allCommentsDesc)
            {
                var article = _articleRepository.Get(comment.ArticleId);

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
            var comments = _commentService
                .GetAll()
                .Where(c => c.ArticleId == Id)
                .ToList();

            foreach (var comment in comments)
            {
                _commentService.Delete(comment.Id);
            }

            _articleRepository.Delete(Id);
        }
    }
}
