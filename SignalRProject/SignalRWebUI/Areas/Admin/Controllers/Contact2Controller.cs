using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Admin.Dtos.Contact2Dtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class Contact2Controller : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Contact2Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Contact2List()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Contact2");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContact2Dto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateContact2()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateContact2(CreateContact2Dto createContact2Dto)
        {
            createContact2Dto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContact2Dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //sondaki medya türüdür,doğru çevrilmesi için gereklidir.
            var responseMessage = await client.PostAsync("https://localhost:7031/api/Contact2", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact2List");
            }
            return View();
        }


        public async Task<IActionResult> DeleteContact2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7031/api/Contact2/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact2List");
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateContact2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Contact2/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContact2Dto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact2(UpdateContact2Dto updateContact2Dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateContact2Dto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7031/api/Contact2", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact2List");
            }
            return View();
        }



        public async Task<IActionResult> Contact2Detail(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Contact2/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContact2Dto>(jsonData);
                return View(values);
            }
            return View();
        }







        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Contact2/ChangeStatusToTrue/{id}");
            return RedirectToAction("Contact2List");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Contact2/ChangeStatusToFalse/{id}");
            return RedirectToAction("Contact2List");
        }
    }
}
