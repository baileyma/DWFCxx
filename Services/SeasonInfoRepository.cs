using DWFCxx.DbContexts;
using DWFCxx.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DWFCxx.Services
{
    public class SeasonInfoRepository : ISeasonInfoRepository
    {
        private SeasonInfoContext _context;

        public SeasonInfoRepository(SeasonInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SeasonExistsAsync(int seasonId)
        {
            var seasonExists = await _context.Seasons.AnyAsync(season => season.Id == seasonId);
            return seasonExists;
        }

        public async Task<Match?> GetMatchAsync(int seasonId, int matchId)
        {
            return await _context.Matches.
                Where(match => match.Id == matchId && match.SeasonId == seasonId).
                FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Match>> GetMatchesAsync(int seasonId)
        {
            return await _context.Matches.Where(match => match.SeasonId == seasonId)
                .ToListAsync();
        }

        public async Task<Season?> GetSeasonAsync(int seasonId, bool includeMatches)
        {
            if (includeMatches)
            {
                return await _context.Seasons.Include(season => season.Matches)
                    .Where(season => season.Id == seasonId).
                    FirstOrDefaultAsync();
            }

            return await _context.Seasons
                .Where(season => season.Id == seasonId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Season>> GetSeasonsAsync()
        {
            return await _context.Seasons.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task PostMatchAsync(int seasonId, Match match)
        {
            var season = await GetSeasonAsync(seasonId, false);

            if (season != null)
            {
                season.Matches.Add(match);
            }           
        }

        public void DeleteMatch(Match Match)
        {
            _context.Matches.Remove(Match);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
