using BusinessLogic.Abstract;
using Dto.AboutDto;
using Dto.TableNumberDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableNumberController : ControllerBase
    {
        private readonly ITableNumberService _tableNumberService;

        public TableNumberController(ITableNumberService tableNumberService)
        {
            _tableNumberService = tableNumberService;
        }

        [HttpGet]
        public IActionResult TableNumberList()
        {
            var liste = _tableNumberService.TGetAll();
            return Ok(liste);
        }

        [HttpPost]
        public IActionResult CreateTableNumber(CreateTableNumberDto createTableNumberDto)
        {
            var tableNumber = new TableNumber()
            {
               Table=createTableNumberDto.Table,
            };
            tableNumber.Status = false;
            _tableNumberService.TInsert(tableNumber);
            return Ok("Masa başarıyla eklendi.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTableNumber(int id)
        {
            var value = _tableNumberService.TGetById(id);
            _tableNumberService.TDelete(value);
            return Ok("Masa silme işlemi gerçekleşti.");
        }

        [HttpPut]
        public IActionResult UpdateTableNumber(UpdateTableNumberDto updateTableNumberDto)
        {
            var tableNumber = new TableNumber()
            {
                Table = updateTableNumberDto.Table,
                TableNumberId = updateTableNumberDto.TableNumberId,
         
            };
            _tableNumberService.TUpdate(tableNumber);
            return Ok("Masa güncelleme işlemi tamamlandı.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTableNumber(int id)
        {
            var deger =_tableNumberService.TGetById(id);
            return Ok(deger);
        }



        [HttpGet("ChangeStatusToTrue/{id:int}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _tableNumberService.TChangeStatusToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _tableNumberService.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }

    }
}
