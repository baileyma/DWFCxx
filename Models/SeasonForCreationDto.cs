namespace DWFCxx.Models
{
    public class SeasonForCreationDto
    {
        public string? WeatherSeason { get; set; }

        public int Year { get; set; }

        public ICollection<MatchDto> Matches { get; set; } = new List<MatchDto>() { };

        public int MatchesPlayed
        {
            get
            {
                return Matches.Count;
            }
        }
    }
}
