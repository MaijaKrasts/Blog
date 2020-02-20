using Blog.Data.Entities.Const.Messages;
using Blog.Data.Entities.Services.Interfaces;
using Blog.Web.Models.Service;
using Blog.Web.Models.User;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
        private ModelService _model;
        private IUserService _user;

        public UserController(ModelService model, IUserService user)
        {
            _model = model;
            _user = user;
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
                bool isPassAndEmailValid = _user.CheckPasswordByEmail(signInmodel.Email, signInmodel.Password);

                if (isPassAndEmailValid == false)
                {
                    ModelState.AddModelError("error", ErrorMessages.EmailWrong);
                }
                else
                {
                    var user = _user.GetByEmail(signInmodel.Email);

                    Session.Add("userId", user.Id);
                    Session.Add("userName", user.Name);
                    Session.Add("userRole", user.Role);
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
                if (_user.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError("error", ErrorMessages.EmailExists);
                }
                else
                {
                    _model.CreateUserFromModel(model);
                    TempData["message"] = ErrorMessages.AccountCreated;
                    return RedirectToAction("SignIn");
                }
            }

            return View();
        }

        public ActionResult Profile(int Id)
        {
            return View(_user.Get(Id));
        }

        public ActionResult EditProfile(int Id)
        {
            var model = _model.CreateUserModel(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(UserModel model)
        {
            //var validFile = _fileValidator.ValidateImage(model.UpdatedPicture);
            //if (ModelState.IsValid && validFile)
            //{
            //    model = _model.UpdateUserModel(model);
            //    return RedirectToAction(nameof(Profile), new { Id = model.Id });
            //}

            ModelState.AddModelError("error", ErrorMessages.UploadError);
            return View(model);
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}