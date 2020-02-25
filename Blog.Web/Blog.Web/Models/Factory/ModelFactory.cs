using Blog.Data.Entities;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Logic.Const.Messages;
using Blog.Logic.Const.Parameters;
using Blog.Web.Models.Admin;
using Blog.Web.Models.Article;
using Blog.Web.Models.User;
using System;
using System.Collections.Generic;

namespace Blog.Web.Models.Factory
{
    public class ModelFactory : IModelFactory
    {
        IUserService _userService;
        IArticleService _articleService;
        ICommentService _commentService;

        public ModelFactory(IArticleService articleService, IUserService userService, ICommentService commentService)
        {
            _userService = userService;
            _commentService = commentService;
            _articleService = articleService;
        }

        public MultipleArticleModel MultipleArticleModel()
        {

            MultipleArticleModel model = new MultipleArticleModel()
            {
                LatestArticle = _articleService.GetLatest(),
                FewArticles = _articleService.GetNumOf(Values.Four),
                HighestRated = _articleService.GetHighestRated(Values.Three),
                LastCommented = _articleService.GetLastCommented(Values.Three),
            };

            return model;
        }

        public SingleArticleModel SingleArticleModel(int articleId, int? userId)
        {
            Data.Entities.User user = null;
            Data.Entities.Article article = _articleService.Get(articleId);
            List<Comment> comments = _commentService.GetForArticle(articleId);
           if (userId != null)
            {
                int id = userId.GetValueOrDefault();
                user = _userService.Get(id);
            }

            List<Data.Entities.User> users = _userService.GetAll();

            SingleArticleModel model = new SingleArticleModel();
            model.Article = article;
            model.Comments = comments;
            model.User = user;
            model.Users = users;

            return model;
        }

        public ArticleModel ArticleModel(int Id)
        {
            var article = _articleService.Get(Id);
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
                UserArticles = _articleService.GetUserArticles(Id),
                User = _userService.Get(Id),
            };

            return model;
        }

        public UserModel UserModel(int Id)
        {
            var user = _userService.Get(Id);

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
            var currentUser = _userService.Get(model.Id);
            var fileName = currentUser.Picture;

            if (model.Picture != currentUser.Picture && model.Picture != null)
            {
                fileName = model.Picture;
            }

            currentUser.Name = model.Name;
            currentUser.Email = model.Email;
            currentUser.Picture = fileName;

            _userService.Update(currentUser);

            return model;
        }

        public AdminModel AdminModel()
        {
            AdminModel model = new AdminModel()
            {
                AllUsers = _userService.GetAll(),
                CommentingUsers = _userService.GetAllCommenting(),
                RatingUsers = _userService.GetAllRating(),
                WritingUsers = _userService.GetAllWriting(),
                Admins = _userService.GetAllAdmins(),
            };

            return model;
        }


        public ArticleModel UpdateArticleModel(ArticleModel model)
        {
            var currentArticle = _articleService.Get(model.Id);
            var fileName = currentArticle.Picture;

            if (model.Picture != currentArticle.Picture && model.Picture != null)
            {
                fileName = model.Picture;
            }

            currentArticle.Title = model.Title;
            currentArticle.Intro = model.Intro;
            currentArticle.Text = model.Text;
            currentArticle.Picture = fileName;

            _articleService.Update(currentArticle);

            return model;
        }

        public Data.Entities.User CreateUserFromModel(UserDataModel model)
        {
            var password = _userService.SavePassword(model.Password);

            string uniqueFileName = Links.DefaultUserPic;

            var user = new Data.Entities.User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = password,
                Picture = Links.Uploads + uniqueFileName,
            };

            _userService.Create(user);
            return user;
        }

        public Data.Entities.Article CreateArticleFromModel(ArticleModel model)
        {
            Data.Entities.Article article = new Data.Entities.Article()
            {
                Id = model.Id,
                AuthorId = model.AuthorId,
                Intro = model.Intro,
                Picture = model.Picture,
                Text = model.Text,
                Title = model.Title,
                CreatedOn = DateTime.Now,
                Rating = Values.Zero,
            };

            _articleService.Create(article);

            return article;
        }
    }
}