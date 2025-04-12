using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DWFCxx.Entities
{
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // so between 1-12

        [ForeignKey("SeasonId")]

        public Season? Season { get; set; }

        public int SeasonId { get; set; }

        public int Round { get; set; }

        public DateTime Date { get; set; }
        // eg 24/03/2025

        public int WhiteGoals { get; set; }

        public int BlueGoals { get; set; }

        public Match() { }

        public Match(int id, int seasonId, int round, DateTime date, int whiteGoals, int blueGoals)
        {
            Id = id;
            SeasonId = seasonId;
            Round = round;
            Date = date;
            WhiteGoals = whiteGoals;
            BlueGoals = blueGoals;
        }
    }
}
