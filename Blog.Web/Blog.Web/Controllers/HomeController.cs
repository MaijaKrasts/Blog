using Blog.Web.ModelRepository;
using Blog.Web.Models.ModelRepository;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
            private IModelRepository _modelRepository;

            public HomeController(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public ActionResult Index()
            {
                return View(_modelRepository.CreateMultipleArticleModel());
            }
    }
}