using AutoMapper;
using Dto.AboutDto;
using Dto.CarDto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class CarMapping:Profile
	{
        public CarMapping()
        {
			CreateMap<Car, CreateCarDto>().ReverseMap();
			CreateMap<Car, ResultCarDto>().ReverseMap();
			CreateMap<Car, GetCarDto>().ReverseMap();
			CreateMap<Car, UpdateCarDto>().ReverseMap();
		}
    }
}
