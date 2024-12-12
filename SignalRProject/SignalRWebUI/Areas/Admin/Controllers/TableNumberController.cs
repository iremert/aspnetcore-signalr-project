﻿
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Admin.Dtos.TableNumberDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class TableNumberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TableNumberController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> TableNumberList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/TableNumber");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTableNumberDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateTableNumber()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateTableNumber(CreateTableNumberDto createTableNumberDto)
        {
            createTableNumberDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTableNumberDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //sondaki medya türüdür,doğru çevrilmesi için gereklidir.
            var responseMessage = await client.PostAsync("https://localhost:7031/api/TableNumber", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TableNumberList");
            }
            return View();
        }


        public async Task<IActionResult> DeleteTableNumber(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7031/api/TableNumber/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TableNumberList");
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateTableNumber(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/TableNumber/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTableNumberDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTableNumber(UpdateTableNumberDto updateTableNumberDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateTableNumberDto);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7031/api/TableNumber", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TableNumberList");
            }
            return View();
        }



        public async Task<IActionResult> TableNumberListWithSignalR()
        {
            return View();
        }



        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/TableNumber/ChangeStatusToTrue/{id}");
            return RedirectToAction("TableNumberList");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7031/api/TableNumber/ChangeStatusToFalse/{id}");
            return RedirectToAction("TableNumberList");
        }


    }
}
