using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Logic.Const.Messages;
using Blog.Logic.Const.Parameters;
using Blog.Web.ModelRepository;
using Blog.Web.Models.User;
using System;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
        private IModelRepository _modelRepository;
        private IUserService _userService;

        public UserController(IModelRepository modelRepository, IUserService userService)
        {
            _modelRepository = modelRepository;
            _userService = userService;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserDataModel signInmodel)
        {
            ModelState.Remove("PasswordRepeat");

            if (ModelState.IsValid)
            {
                bool isPassAndEmailValid = _userService.CheckPasswordByEmail(signInmodel.Email, signInmodel.Password);

                if (isPassAndEmailValid == false)
                {
                    ModelState.AddModelError(ErrorMessages.Error, ErrorMessages.EmailWrong);
                }
                else
                {
                    var user = _userService.GetByEmail(signInmodel.Email);

                    Session.Add(SessionVariables.UserId, user.Id);
                    Session.Add(SessionVariables.UserName, user.Name);
                    if(user.Role == SessionVariables.True)
                    {
                        Session.Add(SessionVariables.UserRole, user.Role);
                    }
                    else
                    {
                        Session.Add(SessionVariables.UserRole, null);
                    }
                    TempData["message"] = ErrorMessages.AccountCreated;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDataModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError(ErrorMessages.Error, ErrorMessages.EmailExists);
                }
                else
                {
                    _modelRepository.CreateUserFromModel(model);
                    TempData["message"] = ErrorMessages.AccountCreated;
                    return RedirectToAction("SignIn");
                }
            }

            return View();
        }

        public ActionResult Profile(int Id)
        {
            if (Convert.ToInt32(Session[SessionVariables.UserId]) == Id)
            {
                return View(_userService.Get(Id));
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditProfile(int Id)
        {
            return View(_modelRepository.CreateUserModel(Id));
        }

        [HttpPost]
        public ActionResult EditProfile(UserModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath(Links.UploadRoute) + file.FileName);
                    model.Picture = Links.Uploads + file.FileName;
                }
                _modelRepository.UpdateUserModel(model);
                return RedirectToAction(nameof(Profile), new { Id = model.Id });
            }

            ModelState.AddModelError(ErrorMessages.Error, ErrorMessages.UploadError);
            return View(model);
        }        

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}