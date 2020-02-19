using Blog.Data.Entities;
using System.Collections.Generic;

namespace Blog.Data.Entities.Services.Interfaces
{
    public interface IArticleService
    {
        Article Get(int id);
        List<Article> GetAll();

        void Update(Article article);
        List<Article> GetAllByDate();
        List<Article> GetNumOf(int num);
        List<Article> GetHighestRated(int num);
        Article GetLatest();
        List<Article> GetUserArticles(int id);
        Article ChangeRating(int id, int rateValue);
        List<Article> GetLastCommented(int num);
        void DeleteWithComments(int Id);
    }
}
