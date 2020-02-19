using Blog.Data.Entities;
using System.Collections.Generic;

namespace Blog.Data.Entities.Services.Interfaces
{
    public interface ICommentService
    {
        Comment Create(int articleId, int userId, string text);

        void Update(Comment comment);
        Comment Get(int id);
        List<Comment> GetAll();
        void Delete(int id);
        List<Comment> GetForArticle(int articleId);
        List<Comment> GetForUser(int userId);
        List<Comment> GetLatest();
        Comment ReportComment(int Id);
        Comment KeepReported(int Id);
    }
}
