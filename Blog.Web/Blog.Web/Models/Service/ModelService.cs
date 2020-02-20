﻿using Blog.Web.Models.Admin;
using Blog.Web.Models.Article;
using Blog.Web.Models.Factory;
using Blog.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Service
{
    public class ModelService
    {
        private ModelFactory _factory;
        public ModelService(ModelFactory factory)
        {
            _factory = factory;
        }
        public MultipleArticleModel CreateMultipleArticleModel()
        {
            return _factory.MultipleArticleModel();
        }

        public SingleArticleModel CreateSingleArticleModel(int articleId, int userId)
        {
            return _factory.SingleArticleModel(articleId, userId);
        }

        public ArticleModel CreateArticleModel(int id)
        {
            return _factory.ArticleModel(id);
        }

        public UserArticleModel CreateUserArticleModel(int id)
        {
            return _factory.UserArticleModel(id);
        }

        public UserModel CreateUserModel(int id)
        {
            return _factory.UserModel(id);
        }

        public UserModel UpdateUserModel(UserModel model)
        {
            return _factory.UpdateUserModel(model);
        }

        public AdminModel CreateAdminModel()
        {
            return _factory.AdminModel();
        }

        public ArticleModel UpdateArticleModel(ArticleModel model)
        {
            return _factory.UpdateArticleModel(model);
        }

        public Data.Entities.User CreateUserFromModel(UserDataModel model)
        {
            return _factory.CreateUserFromModel(model);
        }
    }
}