using AutoMapper;
using BusinessLogic.Abstract;
using DataAccess.Concrete;
using Dto.BrandDto;
using Dto.CarDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet]
		public IActionResult CarList()
		{
			var context = new SignalRContext();
			var values = context.Cars.Include(y => y.Brands).Select(
				x => new ResultCarDto
				{
					CarID = x.CarID,
					ImageUrl = x.ImageUrl,
					BrandName = x.Brands.BrandName,
					Bargain = x.Bargain,
					Model = x.Model,
					Color = x.Color,
					DamageStatus = x.DamageStatus,
					Description = x.Description,
					Documents = x.Documents,
					EnginType = x.EnginType,
					Gearbox = x.Gearbox,
					ImageUrl2 = x.ImageUrl2,
					ImageUrl3 = x.ImageUrl3,
					ImageUrl4 = x.ImageUrl4,
					Insurance = x.Insurance,
					InVehicleStatus = x.InVehicleStatus,
					MaintenanceHistory = x.MaintenanceHistory,
					MileageStatus = x.MileageStatus,
					ModelDate = x.ModelDate,
					MotorPower = x.MotorPower,
					Price = x.Price,
					TireCondition = x.TireCondition,
					VehicleEquipment = x.VehicleEquipment,
					Status = x.Status,
					Status2 = x.Status2,
				});
			return Ok(values.ToList());
		}



		[HttpPost]
		public IActionResult CreateCar(CreateCarDto createCarDto)
		{
			var car = new Car()
			{
				ImageUrl = createCarDto.ImageUrl,
				Bargain = createCarDto.Bargain,
				BrandID = createCarDto.BrandId,
				Model = createCarDto.Model,
				Color = createCarDto.Color,
				DamageStatus = createCarDto.DamageStatus,
				Description = createCarDto.Description,
				Documents = createCarDto.Documents,
				EnginType = createCarDto.EnginType,
				Gearbox = createCarDto.Gearbox,
				ImageUrl2 = createCarDto.ImageUrl2,
				ImageUrl3 = createCarDto.ImageUrl3,
				ImageUrl4 = createCarDto.ImageUrl4,
				Insurance = createCarDto.Insurance,
				InVehicleStatus = createCarDto.InVehicleStatus,
				MaintenanceHistory = createCarDto.MaintenanceHistory,
				MileageStatus = createCarDto.MileageStatus,
				ModelDate = createCarDto.ModelDate,
				MotorPower = createCarDto.MotorPower,
				Price = createCarDto.Price,
				TireCondition = createCarDto.TireCondition,
				VehicleEquipment = createCarDto.VehicleEquipment,
				

			};
			car.Status = false;
			car.Status2 = false;
			_carService.TInsert(car);
			return Ok("Araba başarıyla eklendi.");
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteCar(int id)
		{
			var value = _carService.TGetById(id);
			_carService.TDelete(value);
			return Ok("Araba  silme işlemi gerçekleşti.");
		}

		[HttpPut]
		public IActionResult UpdateCar(UpdateCarDto updateCarDto)
		{
			var car = new Car()
			{
				CarID = updateCarDto.CarID,
				ImageUrl = updateCarDto.ImageUrl,
				Bargain = updateCarDto.Bargain,
				BrandID = updateCarDto.BrandId,
				Model=updateCarDto.Model,	
				Color = updateCarDto.Color,
				DamageStatus = updateCarDto.DamageStatus,
				Description = updateCarDto.Description,
				Documents = updateCarDto.Documents,
				EnginType = updateCarDto.EnginType,
				Gearbox = updateCarDto.Gearbox,
				ImageUrl2 = updateCarDto.ImageUrl2,
				ImageUrl3 = updateCarDto.ImageUrl3,
				ImageUrl4 = updateCarDto.ImageUrl4,
				Insurance = updateCarDto.Insurance,
				InVehicleStatus = updateCarDto.InVehicleStatus,
				MaintenanceHistory = updateCarDto.MaintenanceHistory,
				MileageStatus = updateCarDto.MileageStatus,
				ModelDate = updateCarDto.ModelDate,
				MotorPower = updateCarDto.MotorPower,
				Price = updateCarDto.Price,
				TireCondition = updateCarDto.TireCondition,
				VehicleEquipment = updateCarDto.VehicleEquipment,
				
			};
			_carService.TUpdate(car);
			return Ok("Araba güncelleme işlemi tamamlandı.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetCar(int id)
		{
			var deger = _carService.TGetById(id);
			return Ok(deger);
		}




        [HttpGet("WithBrand/{id:int}")]
        public IActionResult GetCarWithBrand(int id)
        {
            var context = new SignalRContext();
			var x = context.Cars.Include(y => y.Brands).Where(z => z.CarID == id).SingleOrDefault();
			var deger = new ResultCarDto
			{
				CarID = x.CarID,
				ImageUrl = x.ImageUrl,
				BrandName = x.Brands.BrandName,
				Bargain = x.Bargain,
				Model = x.Model,
				Color = x.Color,
				DamageStatus = x.DamageStatus,
				Description = x.Description,
				Documents = x.Documents,
				EnginType = x.EnginType,
				Gearbox = x.Gearbox,
				ImageUrl2 = x.ImageUrl2,
				ImageUrl3 = x.ImageUrl3,
				ImageUrl4 = x.ImageUrl4,
				Insurance = x.Insurance,
				InVehicleStatus = x.InVehicleStatus,
				MaintenanceHistory = x.MaintenanceHistory,
				MileageStatus = x.MileageStatus,
				ModelDate = x.ModelDate,
				MotorPower = x.MotorPower,
				Price = x.Price,
				TireCondition = x.TireCondition,
				VehicleEquipment = x.VehicleEquipment,
				Status = x.Status,
				Status2 = x.Status2,
			};
           
            return Ok(deger);
        }



		[HttpGet("CarCount")]
		public IActionResult GetCarCount()
		{
			return Ok(_carService.TCarCount());
		}
        [HttpGet("CarCountByBrandNameHyundai")]
        public IActionResult CarCountByBrandNameHyundai()
        {
            return Ok(_carService.TCarCountByBrandNameHyundai());
        }
        [HttpGet("CarCountByBrandNameRenault")]
        public IActionResult CarCountByBrandNameRenault()
        {
            return Ok(_carService.TCarCountByBrandNameRenault());
        }
        [HttpGet("CarPriceAvg")]
        public IActionResult CarPriceAvg()
        {
            return Ok(_carService.TCarPriceAvg());
        }
        [HttpGet("CarPriceAvgByHyundai")]
        public IActionResult CarPriceAvgByHyundai()
        {
            return Ok(_carService.TCarPriceAvgByHyundai());
        }
        [HttpGet("MaxCarPrice")]
        public IActionResult MaxCarPrice()
        {
            return Ok(_carService.TMaxCarPrice());
        }
        [HttpGet("MinCarPrice")]
        public IActionResult MinCarPrice()
        {
            return Ok(_carService.TMinCarPrice());
        }



        [HttpGet("GetActiveCar")]
        public IActionResult GetActiveCar()
        {
            var context = new SignalRContext();
            var values = context.Cars.Include(y => y.Brands).Where(z=>z.Status==true).Select(
                x => new ResultCarDto
                {
                    CarID = x.CarID,
                    ImageUrl = x.ImageUrl,
                    BrandName = x.Brands.BrandName,
                    Bargain = x.Bargain,
                    Model = x.Model,
                    Color = x.Color,
                    DamageStatus = x.DamageStatus,
                    Description = x.Description,
                    Documents = x.Documents,
                    EnginType = x.EnginType,
                    Gearbox = x.Gearbox,
                    ImageUrl2 = x.ImageUrl2,
                    ImageUrl3 = x.ImageUrl3,
                    ImageUrl4 = x.ImageUrl4,
                    Insurance = x.Insurance,
                    InVehicleStatus = x.InVehicleStatus,
                    MaintenanceHistory = x.MaintenanceHistory,
                    MileageStatus = x.MileageStatus,
                    ModelDate = x.ModelDate,
                    MotorPower = x.MotorPower,
                    Price = x.Price,
                    TireCondition = x.TireCondition,
                    VehicleEquipment = x.VehicleEquipment,
                    Status = x.Status,
                    Status2 = x.Status2,
                });
            return Ok(values.ToList());
        }



		[HttpGet("GetActiveFeaturedCars")]
		public IActionResult GetActiveFeaturedCars()
		{
            var context = new SignalRContext();
            var values = context.Cars.Include(y => y.Brands).Where(z => z.Status == true).Where(d=>d.Status2==true).Select(
                x => new ResultCarDto
                {
                    CarID = x.CarID,
                    ImageUrl = x.ImageUrl,
                    BrandName = x.Brands.BrandName,
                    Bargain = x.Bargain,
                    Model = x.Model,
                    Color = x.Color,
                    DamageStatus = x.DamageStatus,
                    Description = x.Description,
                    Documents = x.Documents,
                    EnginType = x.EnginType,
                    Gearbox = x.Gearbox,
                    ImageUrl2 = x.ImageUrl2,
                    ImageUrl3 = x.ImageUrl3,
                    ImageUrl4 = x.ImageUrl4,
                    Insurance = x.Insurance,
                    InVehicleStatus = x.InVehicleStatus,
                    MaintenanceHistory = x.MaintenanceHistory,
                    MileageStatus = x.MileageStatus,
                    ModelDate = x.ModelDate,
                    MotorPower = x.MotorPower,
                    Price = x.Price,
                    TireCondition = x.TireCondition,
                    VehicleEquipment = x.VehicleEquipment,
                    Status = x.Status,
                    Status2 = x.Status2,
                });
            return Ok(values.ToList());
        }


		[HttpGet("GetNewestCar")]
		public IActionResult GetNewestCar()
		{
            var context = new SignalRContext();
            var values = context.Cars.Include(y => y.Brands).Where(z => z.Status == true).ToList().TakeLast(3).Select(
                x => new ResultCarDto
                {
                    CarID = x.CarID,
                    ImageUrl = x.ImageUrl,
                    BrandName = x.Brands.BrandName,
                    Bargain = x.Bargain,
                    Model = x.Model,
                    Color = x.Color,
                    DamageStatus = x.DamageStatus,
                    Description = x.Description,
                    Documents = x.Documents,
                    EnginType = x.EnginType,
                    Gearbox = x.Gearbox,
                    ImageUrl2 = x.ImageUrl2,
                    ImageUrl3 = x.ImageUrl3,
                    ImageUrl4 = x.ImageUrl4,
                    Insurance = x.Insurance,
                    InVehicleStatus = x.InVehicleStatus,
                    MaintenanceHistory = x.MaintenanceHistory,
                    MileageStatus = x.MileageStatus,
                    ModelDate = x.ModelDate,
                    MotorPower = x.MotorPower,
                    Price = x.Price,
                    TireCondition = x.TireCondition,
                    VehicleEquipment = x.VehicleEquipment,
                    Status = x.Status,
                    Status2 = x.Status2,
                });
            return Ok(values.ToList());
        }



        [HttpGet("ChangeStatusToTrue/{id:int}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _carService.TChangeStatusToTrue(id);
            return Ok("Durum True'ya çevrildi.");
        }

        [HttpGet("ChangeStatusToFalse/{id:int}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _carService.TChangeStatusToFalse(id);
            return Ok("Durum False'a çevrildi.");
        }
        [HttpGet("ChangeStatus2ToTrue/{id:int}")]
        public IActionResult ChangeStatus2ToTrue(int id)
        {
            _carService.TChangeStatus2ToTrue(id);
            return Ok("Durum2 True'ya çevrildi.");
        }

        [HttpGet("ChangeStatus2ToFalse/{id:int}")]
        public IActionResult ChangeStatus2ToFalse(int id)
        {
            _carService.TChangeStatus2ToFalse(id);
            return Ok("Durum2 False'a çevrildi.");
        }
    }
}
