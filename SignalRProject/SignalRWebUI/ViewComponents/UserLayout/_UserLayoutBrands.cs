
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BrandDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.UserLayout
{
	public class _UserLayoutBrands:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutBrands(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Brand/GetActiveBrand");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(responsemessage);
                return View(values);
            }
            return View();
        }
	}
}
