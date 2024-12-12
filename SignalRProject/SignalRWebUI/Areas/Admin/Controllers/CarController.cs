
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Admin.Dtos.BrandDtos;
using SignalRWebUI.Areas.Admin.Dtos.CarDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CarList()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Car");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultCarDto>>(jsondata);  
                return View(value); 
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Brand");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsondata);
            List<SelectListItem> value2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text=x.BrandName,
                                               Value=x.BrandId.ToString()
                                           }).ToList();
            ViewBag.markalar=value2;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            createCarDto.Status = false;
            createCarDto.Status2= false;
            var client=_httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7031/api/Car", content);
            if(ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7031/api/Brand");
            var jsondata = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsondata);
            List<SelectListItem> value2 = (from x in values2
                                           select new SelectListItem
                                           {
                                               Text = x.BrandName,
                                               Value = x.BrandId.ToString()
                                           }).ToList();
            ViewBag.markalar = value2;


            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Car/{id}");
            
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent=new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7031/api/Car",stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();  
        }




        public async Task<IActionResult> DeleteCar(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7031/api/Car/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();  
        }







       
        public async Task<IActionResult> CarDetail(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Car/WithBrand/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Car/ChangeStatusToTrue/{id}");
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Car/ChangeStatusToFalse/{id}");
            return RedirectToAction("CarList");
        }
        public async Task<IActionResult> ChangeStatus2ToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Car/ChangeStatus2ToTrue/{id}");
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> ChangeStatus2ToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Car/ChangeStatus2ToFalse/{id}");
            return RedirectToAction("CarList");
        }
    }
}
