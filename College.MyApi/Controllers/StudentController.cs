using Microsoft.AspNetCore.Mvc;

namespace College.MyApi.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
