using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Web.Models.Article;
using Blog.Web.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _article;
        private ModelService _model;
        private ICommentService _comment;

        public ArticleController(IArticleService article, ModelService model, ICommentService comment)
        {

            _article = article;
            _model = model;
            _comment = comment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllArticles()
        {
            return View(_article.GetAll());
        }

        public ActionResult MyArticles(int Id)
        {
            return View(_model.CreateUserArticleModel(Id));
        }

        public ActionResult Single(int articleId, int userId)
        {
            var model = _model.CreateSingleArticleModel(articleId, userId);
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new ArticleModel());
        }

        [HttpPost]
        public ActionResult Create(ArticleModel model)
        {
            //var validFile = _fileValidator.ValidateImage(model.UpdatedPicture);
            //if (ModelState.IsValid && validFile)
            //{
            //    _articleFactory.CreateFromModel(model);
            //    return RedirectToAction("Index", "Home");
            //}

            ModelState.AddModelError("error", ErrorMessages.UploadError);
            return View(model);
        }

        public ActionResult EditArticle(int Id)
        {
            return View(_model.CreateArticleModel(Id));
        }

        [HttpPost]
        public ActionResult EditArticle(ArticleModel model)
        {
            //var validFile = _fileValidator.ValidateImage(model.UpdatedPicture);
            //if (ModelState.IsValid && validFile)
            //{
            //    _model.UpdateArticleModel(model);
            //    return RedirectToAction("AllArticles", "Article");
            //}

            ModelState.AddModelError("error", ErrorMessages.UploadError);
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            _article.DeleteWithComments(Id);
            return RedirectToAction("AllArticles", "Article");
        }

        [Route("article/writecomment/{articleId}/{userId}/{comment}")]
        public ActionResult WriteComment(int articleId, int userId, string comment)
        {
            _comment.Create(articleId, userId, comment);
            return Json(new { ErrorMessages.CommentAdded });
        }

        [Route("article/deletecomment/{commentId}")]
        public ActionResult DeleteComment(int commentId)
        {
            _comment.Delete(commentId);
            return Json(new{ ErrorMessages.CommentDeleted});
        }

        [Route("article/reportcomment/{commentId}")]
        public ActionResult ReportComment(int commentId)
        {
            _comment.ReportComment(commentId);
            return Json(new { ErrorMessages.CommentReported});
        }

        [Route("article/keepcomment/{commentId}")]
        public ActionResult KeepReportedComment(int commentId)
        {
            _comment.KeepReported(commentId);
            return Json(new { ErrorMessages.CommentRestored });
        }

        [Route("article/ratearticle/{articleId}/{rateValue}")]
        public ActionResult RateArticle(int articleId, int rateValue)
        {
            _article.ChangeRating(articleId, rateValue);
            return Json(new { _article.Get(articleId).Rating });
        }
    }
}