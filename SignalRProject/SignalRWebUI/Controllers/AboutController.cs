
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutUs()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/About/GetActiveAbout");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(responsemessage);
                return View(values);
            }
            return View();
        }
    }
}
