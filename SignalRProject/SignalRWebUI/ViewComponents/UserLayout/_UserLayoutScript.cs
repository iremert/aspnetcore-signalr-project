using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutScript:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
