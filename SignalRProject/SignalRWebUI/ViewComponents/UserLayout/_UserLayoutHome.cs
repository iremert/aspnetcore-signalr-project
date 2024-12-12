using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutHome:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
