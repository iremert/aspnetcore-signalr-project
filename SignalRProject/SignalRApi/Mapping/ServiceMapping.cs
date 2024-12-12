using AutoMapper;
using Dto.AboutDto;
using Dto.ServiceDto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class ServiceMapping:Profile
	{
        public ServiceMapping()
        {
			CreateMap<Service, CreateServiceDto>().ReverseMap();
			CreateMap<Service, ResultServiceDto>().ReverseMap();
			CreateMap<Service, GetServiceDto>().ReverseMap();
			CreateMap<Service, UpdateServiceDto>().ReverseMap();
		}
    }
}
