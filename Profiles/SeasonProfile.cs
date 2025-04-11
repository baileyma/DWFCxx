using AutoMapper;

namespace DWFCxx.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile()
        {
            CreateMap<Entities.Season, Models.SeasonWithoutMatchesDto>();
            CreateMap<Entities.Season, Models.SeasonDto>();
        }
    }
}
