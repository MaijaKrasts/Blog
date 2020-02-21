using Blog.Data.Entities;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Web.Models.Admin;
using Blog.Web.Models.Article;
using Blog.Web.Models.User;
using System;
using System.Collections.Generic;

namespace Blog.Web.Models.Factory
{
    public class ModelFactory
    {
        IUserService _user;
        IArticleService _article;
        ICommentService _comment;

        public ModelFactory(IArticleService article, IUserService user, ICommentService comment)
        {
            _user = user;
            _comment = comment;
            _article = article;
        }

        public MultipleArticleModel MultipleArticleModel()
        {

            MultipleArticleModel model = new MultipleArticleModel()
            {
                LatestArticle = _article.GetLatest(),
                FewArticles = _article.GetNumOf(4),
                HighestRated = _article.GetHighestRated(3),
                LastCommented = _article.GetLastCommented(3),
            };

            return model;
        }

        public SingleArticleModel SingleArticleModel(int articleId, int userId)
        {
            Data.Entities.Article article = _article.Get(articleId);
            List<Comment> comments = _comment.GetForArticle(articleId);
            Data.Entities.User user = _user.Get(userId);
            List<Data.Entities.User> users = _user.GetAll();
            //if (user == null)
            //{
            //    user = new User()
            //    {
            //        Id = 0,
            //        Name = "default name",
            //        Email = "default email",
            //        CanComment = 0,
            //        CanRate = 0,
            //        CanWrite = 0,
            //    };
            //}

            SingleArticleModel model = new SingleArticleModel();
            model.Article = article;
            model.Comments = comments;
            model.User = user;
            model.Users = users;

            return model;
        }

        public ArticleModel ArticleModel(int Id)
        {
            var article = _article.Get(Id);
            ArticleModel model = new ArticleModel()
            {
                AuthorId = article.AuthorId,
                Intro = article.Intro,
                Picture = article.Picture,
                Text = article.Text,
                Title = article.Title,
                Id = Id,
            };

            return model;
        }

        public ArticleModel EmpthyArticleModel(int userId)
        {
            ArticleModel model = new ArticleModel()
            {
                AuthorId = userId
            };

            return model;
        }

        public UserArticleModel UserArticleModel(int Id)
        {
            UserArticleModel model = new UserArticleModel()
            {
                UserArticles = _article.GetUserArticles(Id),
                User = _user.Get(Id),
            };

            return model;
        }

        public UserModel UserModel(int Id)
        {
            var user = _user.Get(Id);

            UserModel model = new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Picture = user.Picture,
            };

            return model;
        }

        public UserModel UpdateUserModel(UserModel model)
        {
            var currentUser = _user.Get(model.Id);
            var fileName = currentUser.Picture;
            var uniqueFileName = "empty";

            //if (model.UpdatedPicture != null)
            //{
            //    uniqueFileName = _file.GetUniqueFileName(model.UpdatedPicture.FileName);
            //    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            //    var filePath = Path.Combine(uploads, uniqueFileName);
            //    model.UpdatedPicture.CopyTo(new FileStream(filePath, FileMode.Create));
            //    fileName = "/uploads/" + uniqueFileName;
            //}

            currentUser.Name = model.Name;
            currentUser.Email = model.Email;
            currentUser.Picture = fileName;

            _user.Update(currentUser);

            return model;
        }

        public Web.Models.Admin.AdminModel AdminModel()
        {
            AdminModel model = new AdminModel()
            {
                AllUsers = _user.GetAll(),
                CommentingUsers = _user.GetAllCommenting(),
                RatingUsers = _user.GetAllRating(),
                WritingUsers = _user.GetAllWriting(),
                Admins = _user.GetAllAdmins(),
            };

            return model;
        }


        public ArticleModel UpdateArticleModel(ArticleModel model)
        {
            var currentArticle = _article.Get(model.Id);
            var fileName = currentArticle.Picture;
            var uniqueFileName = "empty";

            //if (model.UpdatedPicture != null)
            //{
            //    uniqueFileName = _file.GetUniqueFileName(model.UpdatedPicture.FileName);
            //    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            //    var filePath = Path.Combine(uploads, uniqueFileName);
            //    model.UpdatedPicture.CopyTo(new FileStream(filePath, FileMode.Create));
            //    fileName = "/uploads/" + uniqueFileName;
            //}

            currentArticle.Title = model.Title;
            currentArticle.Intro = model.Intro;
            currentArticle.Text = model.Text;
            currentArticle.Picture = fileName;

            _article.Update(currentArticle);

            return model;
        }

        public Data.Entities.User CreateUserFromModel(UserDataModel model)
        {
            var password = _user.SavePassword(model.Password);

            string uniqueFileName = "/uploads/default-user.png";

            var user = new Data.Entities.User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = password,
                Picture = "/uploads/" + uniqueFileName,
            };

            _user.Create(user);
            return user;
        }

        public Data.Entities.Article CreateArticleFromModel(ArticleModel model)
        {
            string uniqueFileName = "empty";
            //if (model.UpdatedPicture != null)
            //{
            //    uniqueFileName = _file.GetUniqueFileName(model.UpdatedPicture.FileName);
            //    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            //    var filePath = Path.Combine(uploads, uniqueFileName);
            //    model.UpdatedPicture.CopyTo(new FileStream(filePath, FileMode.Create));
            //}

            Data.Entities.Article article = new Data.Entities.Article()
            {
                Id = model.Id,
                AuthorId = model.AuthorId,
                Intro = model.Intro,
                Picture = model.Picture,
                Text = model.Text,
                Title = model.Title,
                CreatedOn = DateTime.Now,
                Rating = 0,
            };

            _article.Create(article);

            return article;
        }
    }
}