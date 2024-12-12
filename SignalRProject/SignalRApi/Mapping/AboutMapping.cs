using AutoMapper;
using Dto.AboutDto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class AboutMapping:Profile
	{
        public AboutMapping()
        {
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
