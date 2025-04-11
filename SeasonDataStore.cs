using DWFCxx.Models;

namespace DWFCxx
{
    public class SeasonDataStore
    {
        public List<SeasonDto> Seasons { get; set; }

        public static SeasonDataStore NewSeasonSet { get; } = new SeasonDataStore();

        public SeasonDataStore()
        {
            Seasons = new List<SeasonDto>()
            {
                new SeasonDto()
                {
                    Id = 1,
                    WeatherSeason = "Spring",
                    Year = 2025,
                    Matches = new List<MatchDto>()
                    {
                    new MatchDto()
                    {
                        Id = 1,
                        Round = 1,
                        Date = new DateTime(2025, 3, 23),
                        WhiteGoals = 2,
                        BlueGoals = 1
                    },
                    new MatchDto()
                    {
                        Id = 2,
                        Round = 2,
                        Date = new DateTime(2025, 3, 30),
                        WhiteGoals = 2,
                        BlueGoals = 4
                    }
                    }
                },

                new SeasonDto()
                {
                    Id = 2,
                    WeatherSeason = "Summer",
                    Year = 2025
                },

                new SeasonDto()
                {
                    Id = 3,
                    WeatherSeason = "Autumn",
                    Year = 2025
                },

                new SeasonDto()
                {
                    Id = 4,
                    WeatherSeason = "Winter",
                    Year = 2026
                }

            };
        }
    }
}
