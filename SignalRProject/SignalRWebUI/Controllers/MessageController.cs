using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        public IActionResult MessagePage()
        {
            return View();
        }
    }
}
