using DWFCxx.Entities;

namespace DWFCxx.Services
{
    public interface ISeasonInfoRepository
    {
        Task<IEnumerable<Season>> GetSeasonsAsync();

        Task<Season?> GetSeasonAsync(int seasonId, bool includeMatches);

        Task<bool> SeasonExistsAsync(int seasonId);

        Task<IEnumerable<Match>> GetMatchesAsync(int seasonId);

        Task<Match?> GetMatchAsync(int seasonId, int matchId);

        Task PostMatchAsync(int seasonId, Match match);

        void DeleteMatch(Match match);

        Task<bool> SaveChangesAsync();
    }
}
