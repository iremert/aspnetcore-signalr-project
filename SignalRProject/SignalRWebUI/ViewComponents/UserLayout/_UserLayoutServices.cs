using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ServiceDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutServices:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task< IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Service/GetActiveService");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(responsemessage);
                return View(values);
            }
            return View();	
		}
	}
}
