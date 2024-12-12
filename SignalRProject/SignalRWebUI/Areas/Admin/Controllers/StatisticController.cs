using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class StatisticController : Controller
    {

        //brand count
        //brand aktif count
        //brand pasif count
        //
        //...
        public IActionResult Index()   
        {
            return View();
        }
    }
}
