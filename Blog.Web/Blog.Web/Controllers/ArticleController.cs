using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Logic.Const.Messages;
using Blog.Web.ModelRepository;
using Blog.Web.Models.Article;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        private IModelRepository _modelRepository;
        private ICommentService _commentService;

        public ArticleController(IArticleService articleService, IModelRepository modelRepository, ICommentService commentService)
        {

            _articleService = articleService;
            _modelRepository = modelRepository;
            _commentService = commentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllArticles()
        {
            return View(_articleService.GetAll());
        }

        public ActionResult MyArticles(int Id)
        {
            return View(_modelRepository.CreateUserArticleModel(Id));
        }

        public ActionResult Single(int articleId, int? userId)
        {
            var model = _modelRepository.CreateSingleArticleModel(articleId, userId);
            return View(model);
        }

        public ActionResult Create(int userId)
        {
            return View(_modelRepository.EmpthyArticleModel(userId));
        }

        [HttpPost]
        public ActionResult Create(ArticleModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath(Links.UploadRoute) + file.FileName);
                model.Picture = Links.Uploads + file.FileName;
                
                _modelRepository.CreateArticleFromModel(model);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(ErrorMessages.Error, ErrorMessages.UploadError);
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            return View(_modelRepository.CreateArticleModel(Id));
        }

        [HttpPost]
        public ActionResult Edit(ArticleModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath(Links.UploadRoute) + file.FileName);
                    model.Picture = Links.Uploads + file.FileName;
                }

                _modelRepository.UpdateArticleModel(model);
                return RedirectToAction("AllArticles", "Article");
            }

            ModelState.AddModelError(ErrorMessages.Error, ErrorMessages.UploadError);
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            _articleService.DeleteWithComments(Id);
            return RedirectToAction("AllArticles", "Article");
        }

        [HttpPost]
        public ActionResult WriteComment(int articleId, int userId, string comment)
        {
            _commentService.Create(articleId, userId, comment);
            return Json(ErrorMessages.CommentAdded, comment);
        }

        [HttpPost]
        public JsonResult DeleteComment(int commentId)
        {
            _commentService.Delete(commentId);
            return Json(ErrorMessages.CommentDeleted);
        }

        [HttpPost]
        public JsonResult ReportComment(int commentId)
        {
            _commentService.ReportComment(commentId);
            return Json(ErrorMessages.CommentReported);
        }

        [HttpPost]
        public JsonResult KeepReportedComment(int commentId)
        {
            _commentService.KeepReported(commentId);
            return Json(ErrorMessages.CommentRestored);
        }

        [HttpPost]
        public ActionResult RateArticle(int articleId, int rateValue)
        {
            _articleService.ChangeRating(articleId, rateValue);
            return Json(_articleService.Get(articleId).Rating);
        }
    }
}