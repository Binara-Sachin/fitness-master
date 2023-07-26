using Microsoft.AspNetCore.Mvc;

namespace FitnessMaster.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
