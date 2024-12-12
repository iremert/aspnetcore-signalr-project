using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

    
        public async Task<IActionResult> BasketList()
        {
            var client=_httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Basket/BasketListByTableWithCarName?id=1");
            if(request.IsSuccessStatusCode)
            {
                var responseMessage=await request.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultBasketDto>>(responseMessage);
                return View(values);
            }
            return View();
        }



        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7031/api/Basket/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BasketList");
            }
            return NoContent();
        }
    }
}
