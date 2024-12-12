using BusinessLogic.Abstract;
using Dto.AboutDto;
using Dto.BrandDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
		public IActionResult BrandList()
		{
			var liste = _brandService.TGetAll();
			return Ok(liste);
		}

		[HttpPost]
		public IActionResult CreateBrand(CreateBrandDto createBrandDto)
		{
			var brand = new Brand()
			{
				ImageUrl=createBrandDto.ImageUrl,
				Url=createBrandDto.Url,
				BrandName=createBrandDto.BrandName,
			};
			brand.Status = false;
			_brandService.TInsert(brand);
			return Ok("Marka kısmı başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteBrand(int id)
		{
			var value = _brandService.TGetById(id);
			_brandService.TDelete(value);
			return Ok("Marka kısmı silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			var brand = new Brand()
			{
				BrandId=updateBrandDto.BrandId,
				ImageUrl = updateBrandDto.ImageUrl,
				Url = updateBrandDto.Url,
				Status = updateBrandDto.Status,
				BrandName = updateBrandDto.BrandName,
			};
			_brandService.TUpdate(brand);
			return Ok("Marka kısmı güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetBrand(int id)
		{
			var deger = _brandService.TGetById(id);
			return Ok(deger);
		}





		[HttpGet("BrandCount")]
		public IActionResult GetBrandCount()
		{
			return Ok(_brandService.TBrandCount());	
		}

        [HttpGet("ActiveBrandCount")]
        public IActionResult GetActiveBrandCount()
        {
            return Ok(_brandService.TActiveBrandCount());
        }

        [HttpGet("PassiveBrandCount")]
        public IActionResult GetPassiveBrandCount()
        {
            return Ok(_brandService.TPassiveBrandCount());
        }



        [HttpGet("GetActiveBrand")]
        public IActionResult GetActiveBrand()
        {
            var deger = _brandService.TActiveBrandList();
            return Ok(deger);
        }



		[HttpGet("ChangeStatusToTrue/{id:int}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_brandService.TChangeStatusToTrue(id);
			return Ok("Durum True'ya çevrildi.");
		}

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _brandService.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
    }
}
