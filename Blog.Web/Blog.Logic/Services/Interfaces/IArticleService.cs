using Blog.Data.Entities;
using System.Collections.Generic;

namespace Blog.Logic.Services.Interfaces
{
    public interface IArticleService
    {
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
