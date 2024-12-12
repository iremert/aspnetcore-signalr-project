using AutoMapper;
using Dto.AboutDto;
using Dto.Contact2Dto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class Contact2Mapping:Profile
	{
        public Contact2Mapping()
        {
			CreateMap<Contact2, CreateContact2Dto>().ReverseMap();
			CreateMap<Contact2, ResultContact2Dto>().ReverseMap();
			CreateMap<Contact2, GetContact2Dto>().ReverseMap();
			CreateMap<Contact2, UpdateContact2Dto>().ReverseMap();
		}
    }
}
