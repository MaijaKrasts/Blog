using Blog.Web.Models.Service;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
            private ModelService _model;

            public HomeController(ModelService model)
            {
                _model = model;
            }

            public ActionResult Index()
            {
                return View(_model.CreateMultipleArticleModel());
            }
    }
}