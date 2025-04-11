using AutoMapper;
using DWFCxx.Entities;
using DWFCxx.Models;
using DWFCxx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DWFCxx.Controllers
{
    [Route("api/season/{seasonId}/matches")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private readonly ILogger<MatchController> _logger;
        private readonly IMapper _mapper;
        private readonly ISeasonInfoRepository _seasonInfoRepository;

        public MatchController(ILogger<MatchController> logger, IMapper mapper, ISeasonInfoRepository seasonInfoRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _seasonInfoRepository = seasonInfoRepository ?? throw new ArgumentNullException(nameof(seasonInfoRepository));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches(int seasonId)
        {
            if (!await _seasonInfoRepository.SeasonExistsAsync(seasonId))
            {
                _logger.LogInformation($"Season with ID {seasonId} could not be found when looking for its matches");
                return NotFound();
            }
            var matches = await _seasonInfoRepository.GetMatchesAsync(seasonId);
            return Ok(_mapper.Map<IEnumerable<MatchDto>>(matches));
        }

        [HttpGet("{matchId}", Name = "GetMatch")]

        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatch(int seasonId, int matchId)
        {
            if (!await _seasonInfoRepository.SeasonExistsAsync(seasonId))
            {
                _logger.LogInformation($"Season with ID {seasonId} could not be found when looking for its matches");
                return NotFound();
            }

            var match = _seasonInfoRepository.GetMatchAsync(seasonId, matchId);
            
            return Ok(_mapper.Map<MatchDto>(match));

        }

        [HttpPost]
        public async ActionResult<MatchDto> PostMatch(int seasonId, MatchForCreationDto matchPost)
        {

            if (!await _seasonInfoRepository.SeasonExistsAsync(seasonId))
            {
                return NotFound();
            }

            var finalMatch = _mapper.Map<Match>(matchPost);

            await _seasonInfoRepository.PostMatchAsync(seasonId, finalMatch);

            await _seasonInfoRepository.SaveChangesAsync();

            var createdMatch = _mapper.Map<MatchDto>(finalMatch);

            return CreatedAtRoute("GetMatch", new
            {
                seasonId = seasonId,
                matchId = finalMatch.Id
            },
            createdMatch);
        }

        [HttpPut("{matchId}")]

        public async Task<ActionResult> UpdateMatch(int seasonId, int matchId, MatchForUpdateDto matchUpdate)
        {
            if (!await _seasonInfoRepository.SeasonExistsAsync(seasonId))
            {
                return NotFound();
            }

            var matchEntity = await _seasonInfoRepository.GetMatchAsync(seasonId, matchId);


            if (matchEntity == null)
            {
                _logger.LogInformation($"Match with {matchId} was not identified");
                return NotFound();
            }

            _mapper.Map(matchUpdate, matchEntity);

            await _seasonInfoRepository.SaveChangesAsync();
            
            return NoContent();

        }



        [HttpDelete("{matchId}")]

        public async Task<ActionResult> DeleteMatch(int seasonId, int matchId)
        {
            if (!await _seasonInfoRepository.SeasonExistsAsync(seasonId))
            {
                return NotFound();
            }

            var matchEntity = await _seasonInfoRepository.GetMatchAsync(seasonId, matchId);

            if (matchEntity == null)
            {
                return NotFound();
            }

            _seasonInfoRepository.DeleteMatch(matchEntity);

            await _seasonInfoRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}
