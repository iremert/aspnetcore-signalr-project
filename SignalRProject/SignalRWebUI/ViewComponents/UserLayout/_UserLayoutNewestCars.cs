using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CarDtos;

namespace SignalRWebUI.ViewComponents.UserLayout
{

	public class _UserLayoutNewestCars:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutNewestCars(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Car/GetNewestCar");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(responsemessage);
                return View(values);
            }
            return View();
        }
    }
}
