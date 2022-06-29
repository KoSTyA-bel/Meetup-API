using AutoMapper;
using Meetup.BLL;
using Meetup.BLL.Entities;
using Meetup.Model;

namespace Meetup;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Meeting, MeetingViewModel>().ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString()));
        CreateMap<MeetingViewModel, Meeting>().ForMember(dest => dest.Date, opt => opt.MapFrom((src) => src.Date.FindDateTime()));        
    }
}
