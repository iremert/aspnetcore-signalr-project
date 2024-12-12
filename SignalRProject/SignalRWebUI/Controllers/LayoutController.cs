using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult UserLayout()
        {
            return View();
        }


        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
