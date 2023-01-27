using System.ComponentModel.DataAnnotations;

namespace BornToMove.DAL
{
    public class MoveRating
    {
        public int MoveRatingId { get; set; }
        public Move Move { get; set; }
        public double Rating { get; set; }
        public double Intensity { get; set; }
    }
}