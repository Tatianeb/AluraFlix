using AluraFlix.Api.ViewModels;
using AluraFlix.Business.Models;
using AutoMapper;

namespace AluraFlix.Api.Configurations
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Video, VideoViewModel>().ReverseMap();
        }
    }
}