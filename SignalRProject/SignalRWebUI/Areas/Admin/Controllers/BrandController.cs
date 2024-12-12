using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Admin.Dtos.BrandDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public BrandController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> BrandList()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Brand");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            createBrandDto.Status = false;
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json"); //sondaki medya türüdür,doğru çevrilmesi için gereklidir.
            var responseMessage = await client.PostAsync("https://localhost:7031/api/Brand", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();  
        }


        public async Task<IActionResult> DeleteBrand(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7031/api/Brand/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Brand/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata =await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7031/api/Brand",stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();  
        }


        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client=_httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Brand/ChangeStatusToTrue/{id}");
            return RedirectToAction("BrandList");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Brand/ChangeStatusToFalse/{id}");
            return RedirectToAction("BrandList");
        }

    }
}
