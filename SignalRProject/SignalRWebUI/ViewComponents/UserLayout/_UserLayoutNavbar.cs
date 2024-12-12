using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutNavbar:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
