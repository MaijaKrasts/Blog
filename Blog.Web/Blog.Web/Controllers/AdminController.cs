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

        public ActionResult AdminIndex()
        {
            var model = _model.CreateAdminModel();
            return View(model);

        }

        [HttpPost]
        public JsonResult GrantWriteAccess(string email)
        {
            _user.UpdateUserCanWriteStatuss(email);
            return Json(new { ErrorMessages.StatussUpdated, email });
        }

        [HttpPost]
        public JsonResult GrantCommentAccess(string email)
        {
            _user.UpdateUserCanCommentStatuss(email);
            return Json(new { ErrorMessages.StatussUpdated, email });
        }

        [HttpPost]
        public JsonResult GrantRateAccess(string email)
        {
            _user.UpdateUserCanRateStatuss(email);
            return Json(new { ErrorMessages.StatussUpdated, email });
        }

        [HttpPost]
        public JsonResult GrantWriteAccessId(int id)
        {
            _user.UpdateUserCanWriteStatussId(id);
            return Json(new { ErrorMessages.StatussUpdated});
        }
    }
}