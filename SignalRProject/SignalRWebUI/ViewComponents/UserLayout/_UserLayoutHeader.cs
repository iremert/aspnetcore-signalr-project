using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutHeader:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
