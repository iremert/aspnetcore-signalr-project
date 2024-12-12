using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Admin.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> NotificationList()
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync("https://localhost:7031/api/Notification");
            if(request.IsSuccessStatusCode)
            {
                var responsemessage=await request.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(responsemessage);
                return View(result);
            }
            return View();
        }




        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client= _httpClientFactory.CreateClient();
            var json=JsonConvert.SerializeObject(createNotificationDto); 
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
            var request = await client.PostAsync("https://localhost:7031/api/Notification", content);
            if(request.IsSuccessStatusCode)
            {
                return RedirectToAction("NotificationList");
            }
            return View();
        }




        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.DeleteAsync($"https://localhost:7031/api/Notification/{id}");
            if(request.IsSuccessStatusCode)
            {
                return RedirectToAction("NotificationList");
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7031/api/Notification", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("NotificationList");
            }
            return View();
        }



        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            var client= _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Notification/NotificationStatusChangeToFalse/{id}");
            return RedirectToAction("NotificationList");
        }


        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/Notification/NotificationStatusChangeToTrue/{id}");
            return RedirectToAction("NotificationList");
        }

    }
}
