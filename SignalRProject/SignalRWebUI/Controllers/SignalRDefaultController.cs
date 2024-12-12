using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class SignalRDefaultController : Controller //DENEME
    {
        public IActionResult Index() //sayfa yenilenince değişir 
        {
            return View();
        }


        public IActionResult Index2() //sayfa yenilenince değişir 
        {
            return View();
        }
    }
}
