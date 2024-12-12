using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutScript:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
