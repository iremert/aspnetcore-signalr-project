using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.UserLayout
{
    public class _UserLayoutContact:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutContact(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Contact/GetActiveContact");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(responsemessage);
                return View(values);
            }
            return View();
        }
    }
}
