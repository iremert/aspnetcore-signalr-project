using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult OurHome()
        {
            return View();
        }
    }
}
