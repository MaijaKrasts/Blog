using Blog.Data.Entities;
using Blog.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entities.Services
{
    public class CommentService
    {
        private ICommentRepository _comment;

        public CommentService(ICommentRepository comment)
        {
            _comment = comment;
        }
        public Comment Create(int articleId, int userId, string text)
        {
            Comment comment = new Comment()
            {
                CreatedOn = DateTime.Now,
                ArticleId = articleId,
                AuthorId = userId,
                Text = text,
            };

            _comment.Create(comment);
            return comment;
        }

        public Comment Get(int id)
        {
            return _comment.Get(id);
        }

        public List<Comment> GetAll()
        {
            return _comment.GetAll();
        }

        public void Update(Comment comment)
        {
            _comment.Update(comment);
        }

        public void Delete(int id)
        {
            _comment.Delete(id);
        }
        public List<Comment> GetForArticle(int articleId)
        {
            var comments = _comment.GetAll().Where(c => c.ArticleId == articleId).OrderByDescending(c => c.CreatedOn).ToList();
            return comments;
        }

        public List<Comment> GetForUser(int userId)
        {
            var comments = _comment.GetAll().Where(c => c.AuthorId == userId).ToList();
            return comments;
        }

        public List<Comment> GetLatest()
        {
            return _comment.GetAll()
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
        }

        public Comment ReportComment(int Id)
        {
            var comment = _comment.Get(Id);
            comment.Reported = 1;
            _comment.Update(comment);

            return comment;
        }

        public Comment KeepReported(int Id)
        {
            var comment = _comment.Get(Id);
            comment.Reported = 0;
            _comment.Update(comment);

            return comment;
        }
    }
}
