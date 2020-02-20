using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Web.Models.Service;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private ModelService _model;
        private IUserService _user;

        public AdminController(ModelService model, IUserService user)
        {
            _user = user;
            _model = model;
        }

        public ActionResult Index()
        {
            var model = _model.CreateAdminModel();
            return View(model);

        }

        [Route("write/{email}")]
        public ActionResult GrantWriteAccess(string email)
        {
            _user.UpdateUserCanWriteStatuss(email);
            return Json( new { ErrorMessages.StatussUpdated, email });
        }

        [Route("comment/{email}")]
        public ActionResult GrantCommentAccess(string email)
        {
            _user.UpdateUserCanCommentStatuss(email);
            return Json(new { ErrorMessages.StatussUpdated, email });
        }

        [Route("rate/{email}")]
        public ActionResult GrantRateAccess(string email)
        {
            _user.UpdateUserCanRateStatuss(email);
            return Json(new { ErrorMessages.StatussUpdated, email });
        }

        [Route("writeid/{id}")]
        public ActionResult GrantWriteAccessId(int id)
        {
            _user.UpdateUserCanWriteStatussId(id);
            return Json(new { ErrorMessages.StatussUpdated});
        }
    }
}