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

        public MoveRating GetMoveById(int id)
        {
            using (var context = new MoveContext())
            {
                return context.Moves.Select(move => new MoveRating()
                {
                    Move = move,
                    Rating = move.Ratings.Average(r => r.Rating),
                    Intensity = move.Ratings.Average(i => i.Intensity)
                }).First(m => m.Move.MoveId == id);
            }
        }

        public Move GetMoveByName(string name)
        {
            using (var context = new MoveContext())
            {
                return context.Moves.SingleOrDefault(move => move.Name == name);
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

        public List<MoveRating> GetAllMoves2()
        {
            List<MoveRating> moves = new List<MoveRating>();
            using (var context = new MoveContext())
            {
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