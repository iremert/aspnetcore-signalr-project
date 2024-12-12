using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.Areas.Admin.ViewComponents.AdminLayout
{
	public class _AdminLayoutNavbarTop:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLayoutNavbarTop(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
