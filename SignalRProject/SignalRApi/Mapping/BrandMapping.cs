using AutoMapper;
using Dto.BrandDto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class BrandMapping:Profile
	{
        public BrandMapping()
        {
			CreateMap<Brand, CreateBrandDto>().ReverseMap();
			CreateMap<Brand, ResultBrandDto>().ReverseMap();
			CreateMap<Brand, GetBrandDto>().ReverseMap();
			CreateMap<Brand, UpdateBrandDto>().ReverseMap();
		}
    }
}
