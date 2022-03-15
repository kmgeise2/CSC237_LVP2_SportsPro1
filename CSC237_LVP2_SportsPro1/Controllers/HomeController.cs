using Microsoft.AspNetCore.Mvc;


namespace CSC237_LVP2_SportsPro1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

    }
}
