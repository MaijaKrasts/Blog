using Blog.Web.Models.Admin;
using Blog.Web.Models.Article;
using Blog.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Web.Models.Factory
{
    public interface IModelFactory
    {
        MultipleArticleModel MultipleArticleModel();
        SingleArticleModel SingleArticleModel(int articleId, int? userId);
        ArticleModel ArticleModel(int Id);
        ArticleModel EmpthyArticleModel(int userId);
        UserArticleModel UserArticleModel(int Id);
        UserModel UserModel(int Id);
        UserModel UpdateUserModel(UserModel model);
        AdminModel AdminModel();
        ArticleModel UpdateArticleModel(ArticleModel model);
        Data.Entities.User CreateUserFromModel(UserDataModel model);
        Data.Entities.Article CreateArticleFromModel(ArticleModel model);
    }
}
