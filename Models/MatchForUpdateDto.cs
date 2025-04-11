using System.ComponentModel.DataAnnotations;

namespace DWFCxx.Models
{
    public class MatchForUpdateDto
    {
        // so between 1-12

        [Required]
        [Range(1, 12)]
        public int Round { get; set; }

        [Required]
        public DateTime Date { get; set; }
        // eg 24/03/2025

        [Required]
        [Range(0, 20)]
        public int WhiteGoals { get; set; }

        [Required]
        [Range(0, 20)]
        public int BlueGoals { get; set; }
    }
}
