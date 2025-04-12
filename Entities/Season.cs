using DWFCxx.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DWFCxx.Entities
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string WeatherSeason { get; set; }

        public int Year { get; set; }

        public ICollection<Match> Matches { get; set; } = new List<Match>() { };


        public Season() { }

        public Season(int id, string weatherSeason, int year)
        {
            Id = id;
            WeatherSeason = weatherSeason;
            Year = year;
        }
    }
}
