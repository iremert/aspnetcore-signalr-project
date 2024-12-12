using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Contact2Dtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.UserLayout
{
    public class _UserLayoutContact2:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutContact2(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Contact2/GetActiveContact2");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContact2Dto>>(responsemessage);
                return View(values);
            }
            return View();
        }
    }
}
