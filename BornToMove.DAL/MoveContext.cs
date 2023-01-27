using Microsoft.EntityFrameworkCore;

namespace BornToMove.DAL
{
    public class MoveContext : DbContext
    {
        public DbSet<Move> Moves { get; set; }
        public DbSet<MoveRating> MoveRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=born2move;Trusted_Connection=True;");
        }
    }
}