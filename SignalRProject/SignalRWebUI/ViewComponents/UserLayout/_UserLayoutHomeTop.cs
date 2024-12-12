using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UserLayout
{
    public class _UserLayoutHomeTop:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
