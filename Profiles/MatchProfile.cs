using AutoMapper;

namespace DWFCxx.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Entities.Match, Models.MatchDto>();
            CreateMap<Models.MatchForCreationDto, Entities.Match>();
            CreateMap<Models.MatchForUpdateDto, Entities.Match>();
        }
    }
}
