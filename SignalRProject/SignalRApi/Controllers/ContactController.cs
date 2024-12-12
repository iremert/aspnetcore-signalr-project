using BusinessLogic.Abstract;
using Dto.Contact2Dto;
using Dto.ContactDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}



		[HttpGet]
		public IActionResult ContactList()
		{
			var liste = _contactService.TGetAll();
			return Ok(liste);
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			var contact = new Contact()
			{
				Email = createContactDto.Email,
				Message=createContactDto.Message,
				NameSurname=createContactDto.NameSurname,
				Subject=createContactDto.Subject,
				
			};
			contact.Status = false;
			contact.Status2 = false;
			_contactService.TInsert(contact);
			return Ok("İletişim  kısmı başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteContact(int id)
		{
			var value = _contactService.TGetById(id);
			_contactService.TDelete(value);
			return Ok("İletişim kısmı silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			var contact = new Contact()
			{
				ContactID = updateContactDto.ContactID,	
				Email = updateContactDto.Email,
				Message = updateContactDto.Message,
				NameSurname = updateContactDto.NameSurname,
				Subject = updateContactDto.Subject,
				Status = updateContactDto.Status,
				Status2 = updateContactDto.Status2

			};
			_contactService.TUpdate(contact);
			return Ok("İletişim kısmı güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetContact(int id)
		{
			var deger = _contactService.TGetById(id);
			return Ok(deger);
		}




        [HttpGet("GetActiveContact")]
        public IActionResult GetActiveContact()
        {
            var deger = _contactService.GetActiveContact();
            return Ok(deger);
        }



        [HttpGet("ChangeStatus2ToTrue/{id:int}")]
        public IActionResult ChangeStatus2ToTrue(int id)
        {
            _contactService.TChangeStatus2ToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatus2ToFalse/{id:int}")]
        public IActionResult ChangeStatus2ToFalse(int id)
        {
            _contactService.TChangeStatus2ToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
    }
}
