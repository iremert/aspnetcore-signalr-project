using SignalRWebUI.Dtos.BasketDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CarDtos;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OurCar()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Car/GetActiveCar");
            if (request.IsSuccessStatusCode)
            {
                var responsemessage = await request.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(responsemessage);
                return View(values);
            }
            return View();
        }



        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto basketDto = new CreateBasketDto();
            basketDto.CarId = id;
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(basketDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7031/api/Basket",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OurCar");
            }
            return Json(basketDto);
        }
    }
}
