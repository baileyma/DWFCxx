namespace DWFCxx.Models
{
    public class MatchDto
    {
        public int Id { get; set; }


        // so between 1-12

        public int Round { get; set; }

        public DateTime Date { get; set; }
        // eg 24/03/2025

        public int WhiteGoals { get; set; }

        public int BlueGoals { get; set; }
    }
}
