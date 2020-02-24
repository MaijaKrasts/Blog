using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Web.Models.ModelRepository;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class AdminController : Controller
    {
        private ModelRepository _modelRepository;
        private IUserService _userService;

        public AdminController(ModelRepository modelRepository, IUserService userService)
        {
            _userService = userService;
            _modelRepository = modelRepository;
        }

        public ActionResult AdminIndex()
        {
            var model = _modelRepository.CreateAdminModel();
            return View(model);

        }

        [HttpPost]
        public JsonResult GrantWriteAccess(string email)
        {
            _userService.UpdateUserCanWriteStatuss(email);
            return Json(ErrorMessages.StatussUpdated, email);
        }

        [HttpPost]
        public JsonResult GrantCommentAccess(string email)
        {
            _userService.UpdateUserCanCommentStatuss(email);
            return Json(ErrorMessages.StatussUpdated, email);
        }

        [HttpPost]
        public JsonResult GrantRateAccess(string email)
        {
            _userService.UpdateUserCanRateStatuss(email);
            return Json(ErrorMessages.StatussUpdated, email);
        }

        [HttpPost]
        public JsonResult GrantWriteAccessId(int id)
        {
            _userService.UpdateUserCanWriteStatussId(id);
            return Json(ErrorMessages.StatussUpdated);
        }
    }
}