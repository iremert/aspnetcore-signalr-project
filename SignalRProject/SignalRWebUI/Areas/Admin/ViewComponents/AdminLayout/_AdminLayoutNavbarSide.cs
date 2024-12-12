using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbarSide:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
