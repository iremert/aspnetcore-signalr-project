using BusinessLogic.Abstract;
using Dto.BrandDto;
using Dto.Contact2Dto;
using Dto.ContactDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Contact2Controller : ControllerBase
	{
		private readonly IContact2Service _contact2Service;

		public Contact2Controller(IContact2Service contact2Service)
		{
			_contact2Service = contact2Service;
		}


		[HttpGet]
		public IActionResult Contact2List()
		{
			var liste = _contact2Service.TGetAll();
			return Ok(liste);
		}

		[HttpPost]
		public IActionResult CreateContact2(CreateContact2Dto createContact2Dto)
		{
			var contact2 = new Contact2()
			{
				Address = createContact2Dto.Address,		
				Email = createContact2Dto.Email,
				Map = createContact2Dto.Map,
				Phone = createContact2Dto.Phone,
			};
			contact2.Status = false;
			_contact2Service.TInsert(contact2);
			return Ok("İletişim 2 kısmı başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteContact2(int id)
		{
			var value = _contact2Service.TGetById(id);
			_contact2Service.TDelete(value);
			return Ok("İletişim 2 kısmı silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateContact2(UpdateContact2Dto updateContact2Dto)
		{
			var contact2 = new Contact2()
			{
				Address = updateContact2Dto.Address,
				Email = updateContact2Dto.Email,
				Map = updateContact2Dto.Map,
				Phone = updateContact2Dto.Phone,
				Status = updateContact2Dto.Status,
				Contact2ID= updateContact2Dto.Contact2ID
			};
			_contact2Service.TUpdate(contact2);
			return Ok("İletişim 2 kısmı güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetContact2(int id)
		{
			var deger = _contact2Service.TGetById(id);
			return Ok(deger);
		}


        [HttpGet("GetActiveContact2")]
        public IActionResult GetActiveContact2()
        {
            var deger = _contact2Service.GetActiveContact2();
            return Ok(deger);
        }




        [HttpGet("ChangeStatusToTrue/{id:int}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _contact2Service.TChangeStatusToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _contact2Service.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
    }
}
