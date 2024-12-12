using BusinessLogic.Abstract;
using Dto.AboutDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var liste = _aboutService.TGetAll();
			return Ok(liste);
		}

		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto createAboutDto)
		{
			var about = new About()
			{
				Description1 = createAboutDto.Description1,
				Description2 = createAboutDto.Description2,
				Description3 = createAboutDto.Description3,	
				ImageUrl=createAboutDto.ImageUrl,
				ImageUrl2 = createAboutDto.ImageUrl2,
				Title = createAboutDto.Title,
				Title2 = createAboutDto.Title2,
				Description_1 = createAboutDto.Description_1,
				Description_2 = createAboutDto.Description_2,
				Description_3 = createAboutDto.Description_3,
				
				
			};
			about.Status = false;
			_aboutService.TInsert(about);
			return Ok("Hakkımızda kısmı başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteAbout(int id)
		{
			var value=_aboutService.TGetById(id);
			_aboutService.TDelete(value);
			return Ok("Hakkımızda kısmı silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var about = new About()
			{
				AboutID=updateAboutDto.AboutID,
				Description1 = updateAboutDto.Description1,
				Description2 = updateAboutDto.Description2,
				Description3 = updateAboutDto.Description3,
				ImageUrl = updateAboutDto.ImageUrl,
				ImageUrl2 = updateAboutDto.ImageUrl2,
				Title = updateAboutDto.Title,
				Title2 = updateAboutDto.Title2,
				Description_1 = updateAboutDto.Description_1,
				Description_2 = updateAboutDto.Description_2,
				Description_3 = updateAboutDto.Description_3,
				Status = updateAboutDto.Status
				
			};
			_aboutService.TUpdate(about);
			return Ok("Hakkımızda kısmı güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetAbout(int id)
		{
			var deger=_aboutService.TGetById(id);
			return Ok(deger);
		}





		[HttpGet("GetActiveAbout")]
		public IActionResult GetActiveAbout()
		{
			var deger = _aboutService.TGetActiveAbout();
			return Ok(deger);
		}





        [HttpGet("ChangeStatusToTrue/{id:int}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _aboutService.TChangeStatusToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _aboutService.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
    }
}
