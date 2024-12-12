using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class CommentController : Controller
	{
		public IActionResult OurComments()
		{
			return View();
		}
	}
}
