using AutoMapper;
using DashboardApp.DTOs;
using DashboardApp.Data.Entity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MainTopic, MainTopicDto>().ReverseMap();
        CreateMap<SubTopic, SubTopicDto>().ReverseMap();
        CreateMap<URL, UrlDto>().ReverseMap();
        CreateMap<Info, InfoDto>().ReverseMap();
    }
}

