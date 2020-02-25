using Blog.Web.Models.Admin;
using Blog.Web.Models.Article;
using Blog.Web.Models.User;

namespace Blog.Web.ModelRepository
{
    public interface IModelRepository
    {
        MultipleArticleModel CreateMultipleArticleModel();
        SingleArticleModel CreateSingleArticleModel(int articleId, int? userId);
        ArticleModel CreateArticleModel(int id);
        ArticleModel EmpthyArticleModel(int userId);
        UserArticleModel CreateUserArticleModel(int id);
        UserModel CreateUserModel(int id);
        UserModel UpdateUserModel(UserModel model);
        AdminModel CreateAdminModel();
        ArticleModel UpdateArticleModel(ArticleModel model);
        Data.Entities.User CreateUserFromModel(UserDataModel model);
        Data.Entities.Article CreateArticleFromModel(ArticleModel model);
    }
}
