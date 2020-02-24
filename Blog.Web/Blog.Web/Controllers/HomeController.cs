using Blog.Web.Models.ModelRepository;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
            private ModelRepository _modelRepository;

            public HomeController(ModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public ActionResult Index()
            {
                return View(_modelRepository.CreateMultipleArticleModel());
            }
    }
}