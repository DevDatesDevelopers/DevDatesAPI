using AutoMapper;
using DevDates.DBModel.Data.Models;
using DevDates.Model.ViewModels;

namespace DevDatesAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Resource, Photo>()
               .ForMember(dest => dest.Uri, op => op.MapFrom(src => src.ResourceUri));

            CreateMap<Gender, SexualPreference>()
                .ForMember(dest => dest.DisplayName, op => op.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Photos, op => op.MapFrom(src => src.Resources.Where(x => x.ResourceTypeId == 1)));

            CreateMap<Resource, ConnectedService>()
                .ForMember(dest => dest.Url, op => op.MapFrom(src => src.ResourceUri))
                .ForMember(dest => dest.Name, op => op.MapFrom(src => src.ResourceType.DisplayName));

            CreateMap<DevDates.DBModel.Data.Models.Interest, DevDates.Model.ViewModels.Interest>()
              .ForMember(dest => dest.DisplayName, op => op.MapFrom(src => src.DisplayName))
              .ForMember(dest => dest.Photos, op => op.MapFrom(src => src.Resources.Where(x => x.ResourceTypeId==1)));

            CreateMap<DevDates.DBModel.Data.Models.User, DevDates.Model.ViewModels.ShortUserInfo>()
                .ForMember(dest => dest.Name, op => op.MapFrom(src => src.Name))
                .ForMember(dest => dest.Age, op => op.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Value.Year))
                .ForMember(dest => dest.SexualPreferences, op => op.MapFrom(src => src.UsersPreferences))
                .ForMember(dest => dest.Photos, op => op.MapFrom(src => src.Resources.Where(x => x.ResourceTypeId==1)))
                .ForMember(dest => dest.Gender, op => op.MapFrom(src => src.Gender));

            CreateMap<DevDates.DBModel.Data.Models.User, DevDates.Model.ViewModels.DetailedUserInfo>()
              .ForMember(dest => dest.Bio, op => op.MapFrom(src => src.Bio))
              .ForMember(dest => dest.Interests, op => op.MapFrom(src => src.Interests))
              .ForMember(dest => dest.ShortInfo, op => op.MapFrom(src => src));

            CreateMap<DevDates.DBModel.Data.Models.User, DevDates.Model.ViewModels.User>()
             .ForMember(dest => dest.ConnectedServices, op => op.MapFrom(src => src.Resources.Where(x => x.ResourceTypeId==2)))
             .ForMember(dest => dest.DetailedInfo, op => op.MapFrom(src => src))
             .ForMember(dest => dest.ShortInfo, op => op.MapFrom(src => src));

        }
    }
}
