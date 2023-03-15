using AutoMapper;
using DevDates.DBModel.Data.Models;
using DevDates.Model.ViewModels;

namespace DevDatesAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DevDates.DBModel.Data.Models.User, DevDates.Model.ViewModels.User>();
            CreateMap<DevDates.DBModel.Data.Models.Interest, DevDates.Model.ViewModels.Interest>();
            CreateMap<Resource, Photo>();
            CreateMap<Gender, SexualPreference>();

        }
    }
}
