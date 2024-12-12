using AutoMapper;
using Dto.AboutDto;
using Dto.ContactDto;
using Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class ContactMapping:Profile
	{
        public ContactMapping()
        {
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, GetContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
		}
    }
}
