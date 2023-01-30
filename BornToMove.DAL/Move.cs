using System.ComponentModel.DataAnnotations;

namespace BornToMove.DAL
{
    public class Move
    {
        public int MoveId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
        public int SweatRate { get; set; }
        public ICollection<MoveRating> Ratings { get; set; }
    }
}