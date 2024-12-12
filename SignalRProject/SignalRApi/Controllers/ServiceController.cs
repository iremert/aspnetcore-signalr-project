using AutoMapper;
using BusinessLogic.Abstract;
using Dto.BrandDto;
using Dto.ServiceDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		private readonly IServiceService _serviceService;
		private readonly IMapper _mapper;

		public ServiceController(IServiceService serviceService, IMapper mapper)
		{
			_serviceService = serviceService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ServiceList()
		{
			var liste = _mapper.Map<List<ResultServiceDto>>(_serviceService.TGetAll());
			return Ok(liste);
		}

		[HttpPost]
		public IActionResult CreateService(CreateServiceDto createServiceDto)
		{


			_serviceService.TInsert(new Service()
			{
				Description = createServiceDto.Description,
				Icon = createServiceDto.Icon,
				Title = createServiceDto.Title,
				Status = false,
			});

			return Ok("Servis kısmı başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteService(int id)
		{
			var value = _serviceService.TGetById(id);
			_serviceService.TDelete(value);
			return Ok("Servis kısmı silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
		{
			var service = new Service()
			{
				Description = updateServiceDto.Description,
				Icon = updateServiceDto.Icon,
				Title = updateServiceDto.Title,
				ServiceID = updateServiceDto.ServiceID,
				Status = updateServiceDto.Status,
			};
			_serviceService.TUpdate(service);
			return Ok("Servis kısmı güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetService(int id)
		{
			var deger = _serviceService.TGetById(id);
			return Ok(deger);
		}


        [HttpGet("GetActiveService")]
        public IActionResult GetActiveService()
        {
            var deger = _serviceService.GetActiveService();
            return Ok(deger);
        }




        [HttpGet("ChangeStatusToTrue/{id:int}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _serviceService.TChangeStatusToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _serviceService.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
    }
}
