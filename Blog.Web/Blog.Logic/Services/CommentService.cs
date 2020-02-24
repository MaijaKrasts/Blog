using Blog.Data.Entities.Services.Interfaces;
using Blog.Data.Repositories.Interfaces;
using Blog.Logic.Const.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Entities.Services
{
    public class CommentService :ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
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

            _commentRepository.Create(comment);
            return comment;
        }

        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public void Update(Comment comment)
        {
            _commentRepository.Update(comment);
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }
        public List<Comment> GetForArticle(int articleId)
        {
            var comments = _commentRepository.GetAll()
                .Where(c => c.ArticleId == articleId)
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
            return comments;
        }

        public List<Comment> GetForUser(int userId)
        {
            var comments = _commentRepository.GetAll()
                .Where(c => c.AuthorId == userId)
                .ToList();
            return comments;
        }

        public List<Comment> GetLatest()
        {
            return _commentRepository.GetAll()
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
        }

        public Comment ReportComment(int Id)
        {
            var comment = _commentRepository.Get(Id);
            comment.Reported = Values.One;
            _commentRepository.Update(comment);

            return comment;
        }

        public Comment KeepReported(int Id)
        {
            var comment = _commentRepository.Get(Id);
            comment.Reported = Values.Zero;
            _commentRepository.Update(comment);

            return comment;
        }
    }
}
