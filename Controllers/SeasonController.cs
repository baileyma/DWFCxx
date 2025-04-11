using AutoMapper;
using DWFCxx.Models;
using DWFCxx.Services;
using Microsoft.AspNetCore.Mvc;

namespace DWFCxx.Controllers
{
    [ApiController]
    [Route("api/getSeasons")]

    public class SeasonController : ControllerBase
    {
        private readonly ISeasonInfoRepository _seasonInfoRepository;
        private readonly IMapper _mapper;

        public SeasonController(ISeasonInfoRepository seasonInfoRepository, IMapper mapper)
        {
            _seasonInfoRepository = seasonInfoRepository ?? throw new ArgumentNullException(nameof(seasonInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonWithoutMatchesDto>>> GetSeasons()
        {
            var seasonEntities = await _seasonInfoRepository.GetSeasonsAsync();

            var results = _mapper.Map<IEnumerable<SeasonWithoutMatchesDto>>(seasonEntities);
            //var results = new List<SeasonWithoutMatchesDto>();

            //foreach (var seasonEntity in seasonEntities)
            //{
            //    results.Add(new SeasonWithoutMatchesDto
            //    {
            //        Id = seasonEntity.Id,
            //        WeatherSeason = seasonEntity.WeatherSeason,
            //        Year = seasonEntity.Year
            //    });
            //}

            return Ok(results);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSeason([FromRoute] int id, bool includeMatches = false)
        {
            var season = await _seasonInfoRepository.GetSeasonAsync(id, includeMatches);

            if (season == null)
            {
                return NotFound();
            }

            if (includeMatches)
            {
                return Ok(_mapper.Map<SeasonDto>(season));
            }

            return Ok(season2);
            //return Ok(SeasonDataStore.NewSeasonSet.Seasons.FirstOrDefault(season => season.Id == id));
        }
    }
}
