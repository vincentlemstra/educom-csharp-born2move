using Microsoft.EntityFrameworkCore;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        public void AddMove(string name, string description, int sweatRate)
        {
            using (var context = new MoveContext())
            {
                var move = new Move
                {
                    Name = name,
                    Description = description,
                    SweatRate = sweatRate
                };

                context.Add(move);
                context.SaveChanges();
            }
        }

        public void AddReview(int moveId, int rating, int intensity)
        {
            using (var context = new MoveContext())
            {
                Move move = context.Moves.First(move => move.MoveId == moveId);
                var moveRating = new MoveRating
                {
                    Move = move,
                    Rating = rating,
                    Intensity = intensity
                };
                context.MoveRatings.Add(moveRating);
                context.SaveChanges();
            }
        }

        public Move GetMoveAndRatingById(int id)
        {
            throw new NotImplementedException();

            // Hoe krijg ik nu de Move met Rating + intensity erbij (?)
            // Wat ik heb geprobeerd:
                // Inlude functie: (context.Moves.Include(m => m.Reviews))
                // Inlude functie met List als return: (context.Moves.Include(m => m.Reviews).ToList())
                // Group functie: (context.Moves.GroupBy(m => m.MoveId))
                // LINQ Tabellen joinen: (.from.in.join.where.select)

            // Wat ik nog niet geprobeerd heb:
                // Lazy Loading: Proxies of de ILazyLoader gebruiken
                // Nog niet geprobeerd omdat ik idee heb dat dit niet binnen de opdracht valt
        }

        public Move GetMoveById(int moveId)
        {
            using (var context = new MoveContext())
            {
                Move move = context.Moves.Single(move => move.MoveId == moveId);
                return move;
            }
        }

        public Move GetMoveByName(string name)
        {
            using (var context = new MoveContext())
            {
                Move move = context.Moves.SingleOrDefault(move => move.Name == name);
                return move;
            }
        }

        public List<Move> GetAllMoves()
        {
            List<Move> moves = new List<Move>();
            using (var context = new MoveContext())
            {
                foreach (var move in context.Moves)
                {
                    moves.Add(new Move
                    {
                        MoveId = move.MoveId,
                        Name = move.Name,
                        Description = move.Description,
                        SweatRate = move.SweatRate
                    });
                }
                return moves;
            }
        }

        public void UpdateMove(int id, string name, string description, int sweatRate)
        {
            throw new NotImplementedException();
        }

        public void DeleteMove(int id)
        {
            throw new NotImplementedException();
        }
    }
}